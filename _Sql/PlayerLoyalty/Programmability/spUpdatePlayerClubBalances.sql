USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spUpdatePlayerClubBalances]    Script Date: 07/20/2014 21:31:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdatePlayerClubBalances]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdatePlayerClubBalances]
GO

USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spUpdatePlayerClubBalances]    Script Date: 07/20/2014 21:31:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE proc [dbo].[spUpdatePlayerClubBalances]
as
-- -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
-- Description:		Updates TierSpend and Tier Points (PlayerClubBalances)for existing player.
--					and add for new player at the end of the day.
-- Author:			Karlo Camacho
-- Date Created:	7/11/2014

-- 2014.07.11 knc: Original Implementation 
-- 2014.07.15 knc: DE11873
-- =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
begin
declare @OperatorID int = (select OperatorID from Operator where IsActive = 1)
--> I am assuming they will run this SP at the end of the day after 12Midnight
declare @TodaysDate datetime =  dateadd(day, -1, dbo.GetCurrentGamingDate()) 
declare @PlayerSpendPoints as table

	--exec spGetEndGamingDate 1

(
PlayerID int,
TotalSpend money,
TotalPoints money
)

	--Lets Get the Spend 
	;with TodayPlayerSpend (PlayerID, TotalSpend)
	as
	(
	select PlayerID, TotalSpend from dbo.fnGetSpendAveragePerPlayer(@OperatorId, @TodaysDate, @TodaysDate, NULL) 
	)
	--Lets get Points
	,TodayPlayersPoint (PlayerID, TotalPoints)
	as
	(
	select playerID, TotalPoints from dbo.fnGetPointsPerPlayer(@OperatorId, @TodaysDate, @TodaysDate, NULL)
	)
	,PlayerPointsAndSpend (PlayerID,TierSpend, TierPoints)
	as
	(
	 select ISNULL(pspend.PlayerID,ppoints.PlayerID) PlayerID, isnull(pspend.TotalSpend,0) , isnull(ppoints.TotalPoints,0)   from TodayPlayersPoint ppoints 
    full outer join TodayPlayerSpend pspend on ppoints.PlayerID = pspend.PlayerID 
	) 	
	insert into @PlayerSpendPoints (PlayerID, TotalSpend, TotalPoints)
	select PlayerID,TierSpend, TierPoints  from PlayerPointsAndSpend;
	
	
	--Lets update the existing Player
	update pInfo
	set pInfo.Spend = pInfo.Spend + psp.TotalSpend, 
	pInfo.Points = pInfo.Points + psp.TotalPoints
	from PlayerClubBalances pInfo join @PlayerSpendPoints psp
	on pInfo.PlayerID = psp.PlayerID
	
	
	--lets check if theres a new player 
	if exists (select PlayerID from @PlayerSpendPoints where PlayerID not in (select PlayerID from PlayerClubBalances))
	begin
	--select PlayerID from @PlayerSpendPoints where PlayerID <> (select PlayerID from PlayerClubBalances)
	insert into PlayerClubBalances (PlayerID, Spend, Points)
	select PlayerID, TotalSpend, TotalSpend from @PlayerSpendPoints where PlayerID not in (select PlayerID from PlayerClubBalances)
	end
	

    exec spUpdatePlayerTier



end




GO


