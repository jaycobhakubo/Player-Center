USE [Daily]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PlayerClubTierRules_Operator]') AND parent_object_id = OBJECT_ID(N'[dbo].[PlayerClubTierRules]'))
ALTER TABLE [dbo].[PlayerClubTierRules] DROP CONSTRAINT [FK_PlayerClubTierRules_Operator]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_PlayerClubTier_PlayerClubTierRules]') AND parent_object_id = OBJECT_ID(N'[dbo].[PlayerClubTier]'))
ALTER TABLE [dbo].[PlayerClubTier] DROP CONSTRAINT [FK_PlayerClubTier_PlayerClubTierRules]
GO

/****** Object:  Table [dbo].[PlayerClubTierRules]    Script Date: 06/03/2014 10:49:54 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayerClubTierRules]') AND type in (N'U'))
DROP TABLE [dbo].[PlayerClubTierRules]
GO

/****** Object:  Table [dbo].[PlayerClubTier]    Script Date: 06/03/2014 10:49:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayerClubTier]') AND type in (N'U'))
DROP TABLE [dbo].[PlayerClubTier]
GO

/****** Object:  Table [dbo].[PlayerClubTierRules]    Script Date: 06/03/2014 10:49:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayerClubTierRules](
	[PlayerClubTierRuleId] [int] IDENTITY(1,1) NOT NULL,
	[OperatorId] [int] NOT NULL,
	[StartDate] [smalldatetime] NOT NULL,
	[EndDate] [smalldatetime] NOT NULL,
	[DefaultTierId] [int] NULL,
	[DowngradeToDefault] [bit] NOT NULL,
 CONSTRAINT [PK_PlayerClubTierRules] PRIMARY KEY CLUSTERED 
(
	[PlayerClubTierRuleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PlayerClubTierRules]  WITH CHECK ADD  CONSTRAINT [FK_PlayerClubTierRules_Operator] FOREIGN KEY([OperatorId])
REFERENCES [dbo].[Operator] ([OperatorID])
GO

ALTER TABLE [dbo].[PlayerClubTierRules] CHECK CONSTRAINT [FK_PlayerClubTierRules_Operator]
GO

/****** Object:  Table [dbo].[PlayerClubTier]    Script Date: 06/03/2014 10:49:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayerClubTier](
	[PlayerClubTierId] [int] IDENTITY(1,1) NOT NULL,
	[PlayerClubTierRuleId] [int] NOT NULL,
	[Color] [int] NULL,
	[Name] [nvarchar](64) NOT NULL,
	[MinSpend] [money] NULL,
	[MinPoints] [money] NULL,
	[PointsMultiplier] [money] NULL,
 CONSTRAINT [PK_PlayerClubTier] PRIMARY KEY CLUSTERED 
(
	[PlayerClubTierId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PlayerClubTier]  WITH CHECK ADD  CONSTRAINT [FK_PlayerClubTier_PlayerClubTierRules] FOREIGN KEY([PlayerClubTierRuleId])
REFERENCES [dbo].[PlayerClubTierRules] ([PlayerClubTierRuleId])
GO

ALTER TABLE [dbo].[PlayerClubTier] CHECK CONSTRAINT [FK_PlayerClubTier_PlayerClubTierRules]
GO


