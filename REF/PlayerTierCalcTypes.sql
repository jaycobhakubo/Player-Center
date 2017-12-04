USE [Daily]
GO

/****** Object:  Table [dbo].[PlayerTierCalcTypes]    Script Date: 05/30/2014 14:27:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PlayerTierCalcTypes]') AND type in (N'U'))
DROP TABLE [dbo].[PlayerTierCalcTypes]
GO

USE [Daily]
GO

/****** Object:  Table [dbo].[PlayerTierCalcTypes]    Script Date: 05/30/2014 14:27:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlayerTierCalcTypes](
	[PlayerTierCalcTypeID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerTierCalcTypeName] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_PlayerTierCalcTypes] PRIMARY KEY CLUSTERED 
(
	[PlayerTierCalcTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


