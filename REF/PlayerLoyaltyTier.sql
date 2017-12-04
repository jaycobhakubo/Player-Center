USE [Daily]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Operator_PlayerLoyaltyTier_OperatorID]') AND parent_object_id = OBJECT_ID(N'[dbo].[PlayerLoyaltyTier]'))
ALTER TABLE [dbo].[PlayerLoyaltyTier] DROP CONSTRAINT [FK_Operator_PlayerLoyaltyTier_OperatorID]
GO

USE [Daily]
GO

/****** Object:  Table [dbo].[PlayerLoyaltyTier]    Script Date: 05/30/2014 14:25:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayerLoyaltyTier]') AND type in (N'U'))
DROP TABLE [dbo].[PlayerLoyaltyTier]
GO

USE [Daily]
GO

/****** Object:  Table [dbo].[PlayerLoyaltyTier]    Script Date: 05/30/2014 14:25:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayerLoyaltyTier](
	[PlayerLoyaltyTierID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[OperatorID] [int] NOT NULL,
	[TierName] [nvarchar](32) NULL,
	[TierLevel] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[NumberOfVisits] [int] NULL,
	[DurationOfTime] [int] NULL,
	[NumberOfPoints] [money] NULL,
	[AmountOfSpend] [money] NULL,
	[MinPointsPerVisit] [money] NULL,
	[PointsPerHour] [money] NULL,
	[MaxVisitLen] [int] NULL,
	[MinVisitLength] [int] NULL,
 CONSTRAINT [pk_PlayerLoyaltyTier] PRIMARY KEY CLUSTERED 
(
	[PlayerLoyaltyTierID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PlayerLoyaltyTier]  WITH NOCHECK ADD  CONSTRAINT [FK_Operator_PlayerLoyaltyTier_OperatorID] FOREIGN KEY([OperatorID])
REFERENCES [dbo].[Operator] ([OperatorID])
GO

ALTER TABLE [dbo].[PlayerLoyaltyTier] CHECK CONSTRAINT [FK_Operator_PlayerLoyaltyTier_OperatorID]
GO


