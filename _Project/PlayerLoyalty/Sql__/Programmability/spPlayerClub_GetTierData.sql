USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spPlayerClub_GetTierData]    Script Date: 12/13/2018 14:23:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spPlayerClub_GetTierData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spPlayerClub_GetTierData]
GO

USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spPlayerClub_GetTierData]    Script Date: 12/13/2018 14:23:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[spPlayerClub_GetTierData]
	@tierId int
as
-- -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
-- Description: Gets the Player Club Tier Data
--
-- 2014.06.04 jkn: Original Implementation
-- =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
SET NOCOUNT ON

select PlayerClubTierId
    , PlayerClubTierRuleId
    , isnull(Color, 0) as color
    , Name
    , MinSpend
    , MinPoints
    , PointsMultiplier
    , TierImgId
from PlayerClubTier
where (PlayerClubTierId = @tierId or @tierId = 0)

SET NOCOUNT OFF

GO


