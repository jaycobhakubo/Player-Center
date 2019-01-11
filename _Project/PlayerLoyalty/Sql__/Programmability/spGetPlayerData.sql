USE [Daily]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spGetPlayerData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spGetPlayerData]
GO

USE [Daily]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[spGetPlayerData]
-- ============================================================================
-- Author:		GameTech
-- Description:	Retrieves the requested player data
--
-- ????.??.?? - InitialImplementation
-- 2013.09.13 jkn: Use the player spend function for consistency (DE11207)
-- 2014.07.15 jkn: Adding support for pulling the player club points
--=============================================================================
     @PlayerID int
    ,@OperatorID int
as

select FirstName = isnull(p.FirstName, '')
    , MiddleInitial = isnull(p.MiddleInitial, '')
    , LastName = isnull(p.LastName, '')
    , GovIssuedIDNum = isnull(p.GovIssuedIDNum, '')
    , BirthDate = convert(nvarchar(24), p.BirthDate, 101)
    , EMail = isnull(p.EMail, '')
    , PlayerIdent = isnull(p.PlayerIdent, '')
    , Phone = isnull(p.Phone, '')
    , Gender = isnull(p.Gender, '')
    , PinNumber = p.PinNumber
    , Address1 = isnull(a.Address1, '')
    , Address2 = isnull(a.Address2, '')
    , City = isnull(a.City, '')
    , 'State' = isnull(a.State, '')
    , Zip = isnull(a.Zip, '')
    , Country = isnull(a.Country, '')
    , FirstVisitDate = isnull(info.FirstVisitDate, '')
    , LastVisitDate = isnull(info.LastVisitDate, '')
    , PointsBalance = isnull(pbPointsBalance, '')
    , VisitCount = isnull(info.VisitCount, 0)
    , Comment = isnull(info.Comment, '')
    , MagCard = isnull(pmc.MagneticCardNo, '')
    , PlayerLoyaltyTierID = isnull(info.PlayerLoyaltyTierID, '')
    , TotalSpentAmt = (select TotalSpend from dbo.fnGetSpendAveragePerPlayer(@OperatorId, '1/1/1900', getdate(), @PlayerId))
    , IsLoggedIn = isnull(info.IsLoggedIn, 0)
    , PlayerClubPoints = isnull(pcb.Points, '')
    , PlayerClubSpend = isnull(pcb.Spend, '')
from Player p
    join PlayerInformation info on p.PlayerID = info.PlayerID
    left join [Address] a  on p.AddressID = a.AddressID 
    left join PlayerMagCards pmc on p.PlayerID = pmc.PlayerID
    left join PointBalances on info.PointBalancesID = pbPointBalancesID
    left join PlayerClubBalances pcb on p.PlayerId = pcb.PlayerId
where p.PlayerID = @PlayerID
    and info.OperatorID = @OperatorID

GO


