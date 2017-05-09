USE [Daily]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF__PlayerRaf__IsEna__5145E845]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PlayerRafflesPrizes] DROP CONSTRAINT [DF__PlayerRaf__IsEna__5145E845]
END

GO

USE [Daily]
GO

/****** Object:  Table [dbo].[PlayerRafflesPrizes]    Script Date: 03/13/2015 14:16:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayerRafflesPrizes]') AND type in (N'U'))
DROP TABLE [dbo].[PlayerRafflesPrizes]
GO

USE [Daily]
GO

/****** Object:  Table [dbo].[PlayerRafflesPrizes]    Script Date: 03/13/2015 14:16:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PlayerRafflesPrizes](
	[RaffleID] [int] IDENTITY(1,1) NOT NULL,
	[RaffleName] [varchar](100) NOT NULL,
	[RaffleNOfWinners] [int] NOT NULL,
	[RafflePrizeDescription] [varchar](max) NOT NULL,
	[IsEnable] [bit] NULL,
 CONSTRAINT [Unique_RaffleName] UNIQUE NONCLUSTERED 
(
	[RaffleName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[PlayerRafflesPrizes] ADD  DEFAULT ((1)) FOR [IsEnable]
GO


