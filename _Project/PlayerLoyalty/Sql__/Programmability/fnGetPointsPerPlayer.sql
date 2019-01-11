USE [Daily]
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetPointsPerPlayer]    Script Date: 11/19/2018 12:30:23 PM ******/
DROP FUNCTION [dbo].[fnGetPointsPerPlayer]
GO

/****** Object:  UserDefinedFunction [dbo].[fnGetPointsPerPlayer]    Script Date: 11/19/2018 12:30:23 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE function [dbo].[fnGetPointsPerPlayer]
(
    @OperatorID int,
    @StartDate datetime,
    @EndDate datetime,
    @PlayerId int = null
)
returns @PointsPerPlayer table
(
    PlayerID int,
    TotalPoints Money
)
as
-- ============================================================================
-- Description:		Will calculate and retrun Points per Player within specific date range.
-- Author:			Karlo Camacho
-- Date:			7/3/2013

-- 2014.07.11 knc: Original Implementation
-- ============================================================================
begin
;with PlayerPoints (totalPtsEarned, PlayerID) 
	as
	(
	SELECT 
	IsNull(SUM(ISNULL(TotalPtsEarned, 0) * Quantity) + SUM(ISNULL(DiscountPtsPerDollar, 0) * Quantity * ISNULL (DiscountAmount, 0)), 0),-- as totalPtsEarned,
	rr.PlayerID
	from Player p 
	join RegisterReceipt rr on p.PlayerID = rr.PlayerID
	join RegisterDetail rd on rr.RegisterReceiptID = rd.RegisterReceiptID
	left join TransactionType tt on rr.TransactiontypeID = tt.TransactiontypeID
	where
	(rr.GamingDate >= @StartDate and rr.GamingDate <= @EndDate)
	and rr.OperatorID = @OperatorID 
	--and (@PlayerID = 0 or rr.PlayerID = @PlayerID)
	and rr.TransactiontypeID in (1, 3, 12, 13, 15)
	and rr.SaleSuccess = 1
    group by rr.PlayerID
    having IsNull(SUM(ISNULL(TotalPtsEarned, 0) * Quantity) + SUM(ISNULL(DiscountPtsPerDollar, 0) * Quantity * ISNULL (DiscountAmount, 0)), 0) > 0
    
    union all
    
	SELECT 
		-1 * (IsNull(SUM(ISNULL(TotalPtsEarned, 0) * Quantity) + SUM(ISNULL(DiscountPtsPerDollar, 0) * Quantity * ISNULL (DiscountAmount, 0)), 0)), --as totalPtsEarned,
		rr.PlayerID
     from Player p 
		join RegisterReceipt rr on p.PlayerID = rr.PlayerID
		join RegisterDetail rd on rr.RegisterReceiptID = rd.VoidedRegisterReceiptID
		left join TransactionType tt on rr.TransactiontypeID = tt.TransactiontypeID
    where
    (rr.GamingDate >= @StartDate and rr.GamingDate <= @EndDate)
    and rr.OperatorID = @OperatorID 
    --and (@PlayerID = 0 or rr.PlayerID = @PlayerID)
     and rr.TransactiontypeID = 2
    group by rr.PlayerID
    having IsNull(SUM(ISNULL(TotalPtsEarned, 0) * Quantity) + SUM(ISNULL(DiscountPtsPerDollar, 0) * Quantity * ISNULL (DiscountAmount, 0)), 0) <> 0
    
    union all
    
    SELECT 
		-1 * (IsNull(SUM(ISNULL(TotalPtsEarned, 0) * Quantity) + SUM(ISNULL(DiscountPtsPerDollar, 0) * Quantity * ISNULL (DiscountAmount, 0)), 0)), --as totalPtsEarned,
		rr.PlayerID
    from Player p 
    join RegisterReceipt rr on p.PlayerID = rr.PlayerID
    join RegisterDetail rd on rr.RegisterReceiptID = rd.RegisterReceiptID
    left join TransactionType tt on rr.TransactiontypeID = tt.TransactiontypeID
    where
    (rr.GamingDate >= @StartDate and rr.GamingDate <= @EndDate)
    and rr.OperatorID = @OperatorID 
    --and (@PlayerID = 0 or rr.PlayerID = @PlayerID)
    and rr.TransactiontypeID in (10, 16)
    group by rr.PlayerID
    having IsNull(SUM(ISNULL(TotalPtsEarned, 0) * Quantity) + SUM(ISNULL(DiscountPtsPerDollar, 0) * Quantity * ISNULL (DiscountAmount, 0)), 0) <> 0
    
    union all
    
	/*
    select sum(gtdDelta), PlayerID
     from Player p
    join History.dbo.GameTrans gt on p.PlayerID = gt.gtPlayerID 
    join History.dbo.GameTransDetail gtd on gt.gtGameTransID = gtdGameTransID
    where 
    (gt.gtGamingDate >= @StartDate and gt.gtGamingDate <= @EndDate)
    and gt.gtOperatorID = @OperatorID 
   -- and (@PlayerID = 0 or gt.gtPlayerID = @PlayerID)
   and isnull(gt.gtRegisterReceiptID, 0) = 0 
    and gt.gtTransactionTypeID = 9 
    group by PlayerID
    having sum(gtdDelta) > 0
    ) 
    insert into @PointsPerPlayer (PlayerID, TotalPoints)
    select PlayerID, totalPtsEarned  from PlayerPoints order by PlayerID asc;
    */


	select sum(gtdDelta), PlayerID
     from Player p
    join dbo.GameTrans gt on p.PlayerID = gt.gtPlayerID 
    join dbo.GameTransDetail gtd on gt.gtGameTransID = gtdGameTransID
    where 
    (gt.gtGamingDate >= @StartDate and gt.gtGamingDate <= @EndDate)
    and gt.gtOperatorID = @OperatorID 
   -- and (@PlayerID = 0 or gt.gtPlayerID = @PlayerID)
   and isnull(gt.gtRegisterReceiptID, 0) = 0 
    and gt.gtTransactionTypeID = 9 
    group by PlayerID
    having sum(gtdDelta) > 0
    ) 
    insert into @PointsPerPlayer (PlayerID, TotalPoints)
    select PlayerID, totalPtsEarned  from PlayerPoints order by PlayerID asc;

	return 

	end

GO


