USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spPlayerClub_SetTierData]    Script Date: 06/20/2014 12:43:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spPlayerClub_SetTierData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spPlayerClub_SetTierData]
GO

USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spPlayerClub_SetTierData]    Script Date: 06/20/2014 12:43:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[spPlayerClub_SetTierData]
	@tierId int
	, @tierRuleId int
	, @color int
	, @tierName nvarchar(64)
	, @minSpend money
	, @minPoints money
	, @multiplier money
	, @delete int
	, @staffId int
	, @machineId int
	, @operatorId int
	, @imgId int
as
-- -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
-- Description: Sets/Updates the Player Club Tier data
--
-- 2014.06.04 jkn: Original Implementation
-- 2014.06.18 jkn: Adding support for deleting a tier and auditing changes
--  that are made to tiers
-- 2014.06.20 knc(DE11809): update the PlayerClubTierRule table when a default tier is being deleted
-- 2018.12.13 knc: Added ImageId to save into the PlayerClubTier table.
-- =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

SET NOCOUNT ON

declare @log nvarchar(max)

if not exists (select 1 from PlayerClubTier where PlayerClubTierId = @tierId)
begin
    -- The tier id is not in the database so add a new one
    insert into PlayerClubTier
        (PlayerClubTierRuleId
        , Color
        , Name
        , MinSpend
        , MinPoints
        , PointsMultiplier
        ,TierImgId)
    values
        (@tierRuleId
        , @color
        , @tierName
        , @minSpend
        , @minPoints
        , @multiplier
        ,@imgId)
        
    set @tierId = scope_identity()
    

    
   -- select * from PlayerClubTier
    
end
else
begin
    declare @prevTierName nvarchar(64)
        , @prevMinSpend money
        , @prevMinPoints money
        , @prevMultiplier money
        , @prevImageId int
        
    select @prevTierName = Name
        , @prevMinSpend = MinSpend
        , @prevMinPoints = MinPoints
        , @prevMultiplier = PointsMultiplier
        , @prevImageId = TierImgId
    from PlayerClubTier
    where PlayerClubTierId = @tierId

    if (@delete = 1)
    begin
        -- Reset all of the players that had this tier
        update PlayerInformation
        set PlayerLoyaltyTierId = null
        where PlayerLoyaltyTierId = @tierId
        
        -- Remove the tier from the database
        delete from PlayerClubTier where PlayerClubTierId = @tierId
        
    
       --DE11809
        declare @DefaultTier int
        set @DefaultTier = (select DefaultTierId  from PlayerClubTierRules)
        if (@DefaultTier = @tierId)
        begin
        update PlayerClubTierRules set DefaultTierId = null --or -1 dont use 0
        end  

        
        -- Log that the Tier was removed
        set @log = N'The player tier '
                 + @prevTierName
                 + N' was deleted.';
        exec spAddAuditLogEntry 13, @staffId, @machineId, @operatorId, @log;
    end
    else
    begin
        -- The rule id was located in the database so just update the existing record
        update PlayerClubTier
        set PlayerClubTierRuleId = @tierRuleId
            , Color = @color
            , Name = @tierName
            , MinSpend = @minSpend
            , MinPoints = @minPoints
            , PointsMultiplier = @multiplier
            , TierImgId = @imgId
        where PlayerClubTierId = @tierId
        
        -- Name changed?
        if (@prevTierName != @tierName)
        begin
            set @log = N'The player tier name was changed from '
                     + @prevTierName + N' to ' + @tierName;
            exec spAddAuditLogEntry 13, @staffId, @machineId, @operatorId, @log;
        end
        
        -- Min spend changed?
        if (@prevMinSpend != @minSpend)
        begin
            set @log = N'The player tier min spend amount was changed from '
                     + cast(@prevMinSpend as nvarchar)
                     + N' to '
                     + cast(@minSpend as nvarchar)
                     + N' for ' + @tierName;
            exec spAddAuditLogEntry 13, @staffId, @machineId, @operatorId, @log;
        end
        
        -- Min Points changed?
        if (@prevMinPoints != @minPoints)
        begin
            set @log = N'The player tier min points amount was changed from '
                     + cast(@prevMinPoints as nvarchar)
                     + N' to '
                     + cast(@minPoints as nvarchar)
                     + N' for ' + @tierName;
            exec spAddAuditLogEntry 13, @staffId, @machineId, @operatorId, @log;
        end

        -- Points multiplier changed?
        if (@prevMultiplier != @multiplier)
        begin
            set @log = N'The player tier points multiplier was changed from '
                     + cast(@prevMultiplier as nvarchar)
                     + N' to '
                     + cast(@multiplier as nvarchar)
                     + N' for ' + @tierName;
            exec spAddAuditLogEntry 13, @staffId, @machineId, @operatorId, @log;
        end
        
          -- Icon Tier Image changed?
        if (@prevImageId != @imgId)
        begin
            set @log = N'The player tier Icon was changed from '
                     + cast(@prevImageId as nvarchar)
                     + N' to '
                     + cast(@imgId as nvarchar)
                     + N' for ' + @tierName;
            exec spAddAuditLogEntry 13, @staffId, @machineId, @operatorId, @log;
        end
        
    end
end

select @tierId

SET NOCOUNT OFF


GO


