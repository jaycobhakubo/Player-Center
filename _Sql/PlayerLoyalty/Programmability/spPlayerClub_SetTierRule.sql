USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spPlayerClub_SetTierRule]    Script Date: 06/04/2014 09:35:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spPlayerClub_SetTierRule]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spPlayerClub_SetTierRule]
GO

USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spPlayerClub_SetTierRule]    Script Date: 06/04/2014 09:35:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spPlayerClub_SetTierRule]
	@ruleId int,
	@operatorId int,
	@defaultTierId int,
	@downgradeToDefault bit,
	@startDate smalldatetime,
	@endDate smalldatetime
as
-- -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
-- Description: Sets/Updates the Player Club Tier Rules for an operator.
--
-- 2014.06.04 jkn: Original Implementation
-- =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
SET NOCOUNT ON

if not exists (select 1 from PlayerClubTierRules where PlayerClubTierRuleId = @ruleId)
begin
    -- The rule id is not in the database so add a new one
    insert into PlayerClubTierRules
        (OperatorId
        , StartDate
        , EndDate
        , DefaultTierId
        , DowngradeToDefault)
    values
        (@operatorId
        , @startDate
        , @endDate
        , @defaultTierId
        , @downgradeToDefault)
        
    set @ruleId = scope_identity()
end
else
begin
    -- The rule id was located in the database so just update the existing record
    update PlayerClubTierRules
    set OperatorId = @operatorId
        , StartDate = @startDate
        , EndDate = @endDate
        , DefaultTierId = @defaultTierId
        , DowngradeToDefault = @downgradeToDefault
    where PlayerClubTierRuleId = @ruleId
    
end

select @ruleId

SET NOCOUNT OFF
GO


