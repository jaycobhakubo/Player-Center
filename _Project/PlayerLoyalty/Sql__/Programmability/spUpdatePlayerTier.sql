USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spUpdatePlayerTier]    Script Date: 07/20/2014 21:35:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUpdatePlayerTier]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUpdatePlayerTier]
GO

USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spUpdatePlayerTier]    Script Date: 07/20/2014 21:35:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[spUpdatePlayerTier]
as
-- -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
-- Description:		Updates Tier level of a player in the end of the day.

-- Author:			Karlo Camacho
-- Date Created:	7/11/2014

-- 2014.07.11 knc: Original Implementation
-- =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

--> Do we have available tier
if exists (select top 1 1 from PlayerClubTier)
begin
--> Lets us store the availble Tier from Highest spend to the lowest into a variable
	declare @SpendPoints as table (PlayerTierID int, Spend money, Points money)
	insert into @SpendPoints (PlayerTierID, Spend, Points)
	select PlayerClubTierId, MinSpend, MinPoints from PlayerClubTier order by MinSpend desc
	
--> Let us delare a variable that will hold a single value 
	declare @PlayerClubTierID int,
			@Spend money, 
			@Points money

--> Let us declare a variable that will hold the highest value per loop
	declare @HighestSpend money = 0;	
	declare @HighestPoints money;
	declare @NextHighestPoints money;
			
--> Let us loop every single of this Tier using a cursor
	declare PlayerClubTier_Cursor cursor for 
	Select PlayerTierID, Spend, Points from @SpendPoints
	open PlayerClubTier_Cursor
	fetch next from PlayerClubTier_Cursor 
	into @PlayerClubTierID, @Spend, @Points
	
	while @@FETCH_STATUS = 0
	begin
		if (@HighestSpend = 0 and @Spend <> -1)--it means its the very first tier
		begin
			--> 
			if (@Points <> -1)
			begin 
				set @NextHighestPoints = (select top 1 minpoints from PlayerClubTier where MinPoints > @Points order by MinSpend desc) --This is the formula for the highest
				if (@NextHighestPoints is null)--this is the highest point
				begin
					update pInfo
					set pInfo.PlayerLoyaltyTierID = @PlayerClubTierID 
					from PlayerInformation pInfo 
					join PlayerClubBalances pc on pc.PlayerID = pInfo.PlayerID
					where pc.Spend >= @Spend -->if @Spend = 0 and its the only record we have
					and pc.Points >= @Points
				end
				else 
				begin
					update pInfo
					set pInfo.PlayerLoyaltyTierID = @PlayerClubTierID 
					from PlayerInformation pInfo 
					join PlayerClubBalances pc on pc.PlayerID = pInfo.PlayerID
					where pc.Spend >= @Spend -->if @Spend = 0 and its the only record we have
					and (pc.Points >= @Points and pc.Points < @NextHighestPoints)
				end
			end
			else 
			begin
				update pInfo
				set pInfo.PlayerLoyaltyTierID = @PlayerClubTierID 
				from PlayerInformation pInfo 
				join PlayerClubBalances pc on pc.PlayerID = pInfo.PlayerID
				where pc.Spend >= @Spend -->if @Spend = 0 and its the only record we have
			end
		end
		else if (@HighestSpend != 0 and @Spend <> -1)
		Begin
			if (@Points <> -1)
			begin 
				set @NextHighestPoints = (select top 1 minpoints from PlayerClubTier where MinPoints > @Points order by MinSpend desc) --This is the formula for the highest		
				if (@NextHighestPoints is null)--this is the highest point
				begin
					update pInfo
					set pInfo.PlayerLoyaltyTierID = @PlayerClubTierID 
					from PlayerInformation pInfo 
					join PlayerClubBalances pc on pc.PlayerID = pInfo.PlayerID
					where pc.Spend >= @Spend  and pc.Spend < @HighestSpend -->if @Spend = 0 and its the only record we have
					and pc.Points >= @Points
				end
				else 
				begin
					update pInfo
					set pInfo.PlayerLoyaltyTierID = @PlayerClubTierID 
					from PlayerInformation pInfo 
					join PlayerClubBalances pc on pc.PlayerID = pInfo.PlayerID
					where pc.Spend >= @Spend  and pc.Spend < @HighestSpend -->if @Spend = 0 and its the only record we have
					and (pc.Points >= @Points and pc.Points < @NextHighestPoints)
				end
			end
			else 
			begin
				update pInfo
				set pInfo.PlayerLoyaltyTierID = @PlayerClubTierID 
				from PlayerInformation pInfo 
				join PlayerClubBalances pc on pc.PlayerID = pInfo.PlayerID
				where pc.Spend >= @Spend  and pc.Spend < @HighestSpend-->if @Spend = 0 and its the only record we have	
			end
		end	
		set @HighestSpend = @Spend
		
		fetch next from PlayerClubTier_Cursor 
		into @PlayerClubTierID, @Spend, @Points
	end
end
else  --If no tiers is set up then set the tier to null
begin
	update PlayerInformation
	set PlayerLoyaltyTierID = null
end


GO


