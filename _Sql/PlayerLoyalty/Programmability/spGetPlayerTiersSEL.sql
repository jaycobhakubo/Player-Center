USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spGetPlayerTiersSEL]    Script Date: 07/20/2014 21:43:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetPlayerTiersSEL]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spGetPlayerTiersSEL]
GO

USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spGetPlayerTiersSEL]    Script Date: 07/20/2014 21:43:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[spGetPlayerTiersSEL] 

/* USAGE: EXECUTE spGetPlayerTiersSEL 
						1	-- OperatorID
						
   07/20/2014 (knc):US3407 Player Loyalty					
*/

@OperatorID		int

AS
SET NOCOUNT ON
begin
select 
PlayerClubTierId as PlayerLoyaltyTierID
,Name as TierName,
0 as TierLevel,
PointsMultiplier AS Points --this is points multiplier
from PlayerClubTier pct
join PlayerClubTierRules pcr 
on pcr.PlayerClubTierRuleId = pct.PlayerClubTierRuleId
and OperatorId = @OperatorID


--OLD
--SELECT 
--	PlayerLoyaltyTierID,
--	TierName,
--	TierLevel,
--	CONVERT (nvarchar(16), PointsPerHour) AS Points
--FROM
--	PlayerLoyaltyTier WITH (NOLOCK)
--WHERE
--	OperatorID	= @OperatorID AND
--	IsActive	= 'True'





--SELECT 
--	PLT.PlayerLoyaltyTierID,
--	PLT.TierName,
--	PLT.TierLevel,
--	CONVERT (nvarchar(16), PLTR.PointsPerHour, 2) AS Points
--
--FROM

--	PlayerLoyaltyTier PLT WITH (NOLOCK)
--		LEFT OUTER JOIN PlayerLoyaltyTierRules PLTR WITH (NOLOCK)
--			ON PLT.PlayerLoyaltyTierRulesID = PLTR.PlayerLoyaltyTierRulesID
--WHERE
--	PLT.OperatorID		= @OperatorID
--	AND PLT.IsActive	= 1

	
end

GO


