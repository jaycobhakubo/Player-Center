USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spPlayerClub_GetTierRule]    Script Date: 01/21/2019 04:36:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spPlayerClub_GetTierRule]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spPlayerClub_GetTierRule]
GO

USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spPlayerClub_GetTierRule]    Script Date: 01/21/2019 04:36:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[spPlayerClub_GetTierRule]
	@operatorId int
as
-- -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
-- Description: Gets the Player Club Tier Rules for an operator.
--
-- 2014.06.04 jkn: Original Implementation
-- =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
SET NOCOUNT ON

select PlayerClubTierRuleId
    , OperatorId
    , DefaultTierId
    , CONVERT(int, DowngradeToDefault) DowngradeToDefault
    , CONVERT(nvarchar(24),StartDate,101) as StartDate
    , CONVERT(nvarchar(24),EndDate,101) as EndDate
from PlayerClubTierRules
where OperatorId = @operatorId

SET NOCOUNT OFF

GO


