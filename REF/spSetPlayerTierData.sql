USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spSetPlayerTierData]    Script Date: 05/30/2014 14:29:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSetPlayerTierData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSetPlayerTierData]
GO

USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spSetPlayerTierData]    Script Date: 05/30/2014 14:29:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spSetPlayerTierData] 

/* USAGE: EXECUTE spSetPlayerTierData 
	1,			-- @OperatorID				
	1,			-- @PlayerTierCalcTypeID	
	5,			-- @PlayerLoyaltyTierID	
	4,			-- @TierLevel				
	0,			-- @NumberOfVisits			
	0,			-- @DurationOfTime			
	0,			-- @MaxVisitLen			
	0,			-- @MinVisitLen			
	1,			-- @IsActive				
	'Uber Metal',		-- @TierName				
	'1000',		-- @NumberOfPoints			
	'',			-- @AmountOfSpend			
	'',			-- @MinPointsPerVisit		
	''			-- @PointsPerHour			
*/

@OperatorID				int,
@PlayerTierCalcTypeID	int,
@PlayerLoyaltyTierID	int,
@TierLevel				int,
@NumberOfVisits			int,
@DurationOfTime			int,
@MaxVisitLen			int,
@MinVisitLen			int,
@IsActive				bit,
@TierName				nvarchar (32),
@NumberOfPoints			nvarchar (16),
@AmountOfSpend			nvarchar (16),
@MinPointsPerVisit		nvarchar (16),
@PointsPerHour			nvarchar (16)

AS
SET NOCOUNT ON

UPDATE
	Operator
SET
	PlayerTierCalcTypeID = @PlayerTierCalcTypeID
WHERE
	OperatorID = @OperatorID
	
--
IF (@PlayerTierCalcTypeID = 1)
BEGIN
	SET @NumberOfVisits	= NULL
	SET @AmountOfSpend	= NULL
END
ELSE IF (@PlayerTierCalcTypeID = 2 OR @PlayerTierCalcTypeID = 3)
BEGIN
	SET @NumberOfVisits		= NULL
	SET @MaxVisitLen		= NULL
	SET @MinVisitLen		= NULL
	SET @NumberOfPoints		= NULL
	SET @MinPointsPerVisit	= NULL
	SET @PointsPerHour		= NULL
END
ELSE
BEGIN
	SET @MaxVisitLen		= NULL
	SET @MinVisitLen		= NULL
	SET @NumberOfPoints		= NULL
	SET @AmountOfSpend		= NULL
	SET @MinPointsPerVisit	= NULL
	SET @PointsPerHour		= NULL
END		
	

IF (@PlayerLoyaltyTierID > 0 AND EXISTS (SELECT PlayerLoyaltyTierID FROM PlayerLoyaltyTier WITH (NOLOCK) WHERE PlayerLoyaltyTierID = @PlayerLoyaltyTierID))
BEGIN
	UPDATE
		PlayerLoyaltyTier
	SET
		OperatorID			= @OperatorID,
		TierName			= @TierName,
		TierLevel			= @TierLevel,
		IsActive			= @IsActive,
		NumberOfVisits		= @NumberOfVisits,
		DurationOfTime		= @DurationOfTime,
		NumberOfPoints		= @NumberOfPoints,
		AmountOfSpend		= @AmountOfSpend,
		MinPointsPerVisit	= @MinPointsPerVisit,
		PointsPerHour		= @PointsPerHour,
		MaxVisitLen			= @MaxVisitLen,
		MinVisitLength		= @MinVisitLen
	WHERE
		PlayerLoyaltyTierID	= @PlayerLoyaltyTierID
END
ELSE
BEGIN
	INSERT 
		INTO PlayerLoyaltyTier
			(OperatorID,
			 TierName,
			 TierLevel,
			 IsActive,
			 NumberOfVisits,
			 DurationOfTime,
			 NumberOfPoints,
			 AmountOfSpend,
			 MinPointsPerVisit,
			 PointsPerHour,
			 MaxVisitLen,
			 MinVisitLength	)
		 VALUES
			(@OperatorID,
			 @TierName,
			 @TierLevel,
			 @IsActive,
			 @NumberOfVisits,
			 @DurationOfTime,
			 @NumberOfPoints,
			 @AmountOfSpend,
			 @MinPointsPerVisit,
			 @PointsPerHour,
			 @MaxVisitLen,
			 @MinVisitLen	)
END











GO


