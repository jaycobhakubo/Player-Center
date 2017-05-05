USE [Daily]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__PlayerRaf__DateD__542254F0]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PlayerRafflePrizesHistoryLog] DROP CONSTRAINT [DF__PlayerRaf__DateD__542254F0]
END

GO

USE [Daily]
GO

/****** Object:  Table [dbo].[PlayerRafflePrizesHistoryLog]    Script Date: 03/13/2015 13:11:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayerRafflePrizesHistoryLog]') AND type in (N'U'))
DROP TABLE [dbo].[PlayerRafflePrizesHistoryLog]
GO

USE [Daily]
GO

/****** Object:  Table [dbo].[PlayerRafflePrizesHistoryLog]    Script Date: 03/13/2015 13:11:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PlayerRafflePrizesHistoryLog](
	[RaffleName] [varchar](100) NULL,
	[DateDeleted] [datetime] NULL,
	[RaffleNOfWinners] [int] NULL,
	[RafflePrizeDescription] [varchar](max) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[PlayerRafflePrizesHistoryLog] ADD  DEFAULT (getdate()) FOR [DateDeleted]
GO


