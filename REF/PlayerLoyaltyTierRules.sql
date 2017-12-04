USE [Daily]
GO

/****** Object:  Table [dbo].[PlayerLoyaltyTierRules]    Script Date: 05/30/2014 14:26:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayerLoyaltyTierRules]') AND type in (N'U'))
DROP TABLE [dbo].[PlayerLoyaltyTierRules]
GO

USE [Daily]
GO

/****** Object:  Table [dbo].[PlayerLoyaltyTierRules]    Script Date: 05/30/2014 14:26:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayerLoyaltyTierRules](
	[PlayerLoyaltyTierRulesID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[NumberOfPoints] [int] NULL,
	[NumberofVisits] [int] NULL,
	[DurationOfTime] [int] NULL,
	[AmountOfSpend] [money] NULL,
	[MinPointsPerVisit] [int] NULL,
	[MaxVisitLength] [int] NULL,
	[PointsPerHour] [int] NULL,
	[MinVisitLength] [int] NULL,
 CONSTRAINT [pk_PlayerLoyaltyTierRules] PRIMARY KEY CLUSTERED 
(
	[PlayerLoyaltyTierRulesID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


