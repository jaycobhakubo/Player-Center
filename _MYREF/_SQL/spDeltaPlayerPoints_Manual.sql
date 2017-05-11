USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spDeltaPlayerPoints_Manual]    Script Date: 5/11/2017 11:34:13 AM ******/
DROP PROCEDURE [dbo].[spDeltaPlayerPoints_Manual]
GO

/****** Object:  StoredProcedure [dbo].[spDeltaPlayerPoints_Manual]    Script Date: 5/11/2017 11:34:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spDeltaPlayerPoints_Manual]
--=============================================================================
-- 2017.05.08 US2100 Adding support for being able to manually delta player's points.
-- US2001:(20170511-knc) Insert points awarded to PlayerClubPoints table.
--=============================================================================
	 @playerId int
	,@operatorId int
	,@staffId int
	,@machineId int
	,@pointDelta money
	,@sharePoints int
AS
SET NOCOUNT ON

DECLARE @CurGamingDate smalldatetime
       ,@playerLoyaltyTierId int
       ,@pointBalancesId int
       ,@creditBalancesId int
       ,@now datetime
       ,@gamingSession tinyint
       ,@gameTransID int
       ,@detailResult int
       ,@previousPoints money
       ,@postPoints money
       ,@result int

SET @curGamingDate = dbo.GetCurrentGamingDate()
SET @gamingSession = NULL
	
SELECT @playerLoyaltyTierID = 0
      ,@pointBalancesID = 0
      ,@creditBalancesId = 0
      ,@now = GetDate()
      ,@detailResult = 0
      ,@previousPoints = 0
      ,@postPoints = 0
      ,@result = 0 -- success

IF @playerID > 0 AND NOT EXISTS (SELECT 1 FROM PlayerInformation (NOLOCK)
						         WHERE PlayerID = @playerId and OperatorID = @operatorId)
BEGIN
    SET @result = -26 -- Player Not Found
END
ELSE
BEGIN
    SELECT @PlayerLoyaltyTierID = ISNULL(info.PlayerLoyaltyTierID, 0)
          ,@PointBalancesID = info.PointBalancesID
          ,@previousPoints = pb.pbPointsBalance
          ,@postPoints = pb.pbPointsBalance + @pointDelta
    FROM PlayerInformation info (NOLOCK)
        JOIN PointBalances pb (NOLOCK) ON info.PointBalancesId = pb.pbPointBalancesId
    WHERE info.PlayerID = @playerId
        AND info.OperatorID = @operatorId

    --Has the player elevated to a new tier? Tier 1 is the best.
    SELECT @playerLoyaltyTierId = PlayerLoyaltyTierID
    FROM PlayerLoyaltyTier (nolock)
    WHERE OperatorID = @OperatorID
        AND IsActive = 1
        AND TierLevel = (SELECT MIN(TierLevel) FROM PlayerLoyaltyTier (NOLOCK)
                         WHERE OperatorID = @operatorID
	            		    AND IsActive = 1 
			                AND NumberOfPoints <= @postPoints)

    BEGIN TRY
    BEGIN TRAN

	    UPDATE PointBalances
	    SET pbPointsBalance = @postPoints
	    WHERE pbPointBalancesID = @PointBalancesID	

	    --insert GameTrans record
	    EXEC spSetGameTrans @gtCreditBalancesID = -1,
					    @gtOperatorID = @OperatorID,
					    @gtTransactionTypeID = 9,
					    @gtPlayerID = @PlayerID,
					    @gtMachineID = @MachineID,
					    @gtTransTotal = @PointDelta,
					    @gtGamingDate = @CurGamingDate,
					    @gtGamingSession = @GamingSession,
					    @gtPointBalancesID = @PointBalancesID,
					    @OutGameTransID = @GameTransID OUTPUT

	    --insert GameTransDetail record
	    EXEC spSetGameTransDetail @gtdGameTransID = @GameTransID,
					    @gtdTransCatID = 2,				--NONREFUNDABLE
					    @gtdCurrencyID = 4,				--POINTS
					    @gtdDelta = @PointDelta,
					    @gtdPrevious = @PreviousPoints,
					    @gtdPost = @PostPoints,
					    @gtdPending = 0,
					    @gtdCreationUserID = @PlayerID,
					    @OutResult = @DetailResult OUTPUT

	    UPDATE PlayerInformation
	    SET PlayerLoyaltyTierID = @playerLoyaltyTierId
	    WHERE PlayerID = @playerId AND OperatorID = @operatorId

	    If @GameTransID > 0 and @DetailResult > 0
	    Begin
		    COMMIT TRAN
			--US2100(knc) Send @pointdelta to playerclubpoints
			--If this sql script is Committed then run this -> 
			DECLARE @playermagCardNo nvarchar(32);
			SELECT @playermagCardNo = ISNULL(MagneticCardNo,'') FROM Daily.dbo.PlayerMagCards WHERE PlayerID = @playerId--Get player magcard no
			EXEC spPlayerClubPoints_AddAdjustment @playerId, @playermagCardNo, @pointDelta,0,0,0,NULL,0 
	    End
	    Else
	    Begin
		    select @PointDelta = 0.00

		    IF @@TRANCOUNT > 0
		    BEGIN
			    ROLLBACK TRAN

			    --get original PlayerLoyaltyTierID
			    select @PlayerLoyaltyTierID = ISNULL(PlayerLoyaltyTierID, 0)
			    from PlayerInformation (nolock)
			    where PlayerID = @PlayerID
			    and OperatorID = @OperatorID
		    END 
	    End			
    END TRY
    BEGIN CATCH
	    select @PointDelta = 0.00

	    IF @@TRANCOUNT > 0
	    BEGIN
			    ROLLBACK TRAN

			    --get original PlayerLoyaltyTierID
			    select @PlayerLoyaltyTierID = ISNULL(PlayerLoyaltyTierID, 0)
			    from PlayerInformation (nolock)
			    where PlayerID = @PlayerID
			    and OperatorID = @OperatorID
		    END 
    END CATCH
    
END

SELECT @result AS result

SET NOCOUNT OFF

GO


