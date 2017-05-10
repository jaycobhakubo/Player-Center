USE [Daily]
GO

/****** Object:  Trigger [trigLogRafflePrize]    Script Date: 03/13/2015 13:36:29 ******/
IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trigLogRafflePrize]'))
DROP TRIGGER [dbo].[trigLogRafflePrize]
GO

USE [Daily]
GO

/****** Object:  Trigger [dbo].[trigLogRafflePrize]    Script Date: 03/13/2015 13:36:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create trigger [dbo].[trigLogRafflePrize]
on [dbo].[PlayerRafflesPrizes]
for delete 
as
declare @RaffleID int , @Rafflename varchar(100), @NoOfWinners int, @PrizeDescription varchar(max)
select @RaffleID = RaffleID, @Rafflename = RaffleName, @NoOfWinners = RaffleNOfWinners, @PrizeDescription = RafflePrizeDescription from deleted

insert into PlayerRafflePrizesHistoryLog (RaffleName ,
RaffleNOfWinners ,
RafflePrizeDescription )
values (@Rafflename, @NoOfWinners, @PrizeDescription)



GO


