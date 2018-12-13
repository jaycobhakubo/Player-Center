USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[SQLSOURCECONTROL_POPULATETABLE_PhotoType]    Script Date: 12/13/2018 14:42:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SQLSOURCECONTROL_POPULATETABLE_PhotoType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SQLSOURCECONTROL_POPULATETABLE_PhotoType]
GO

USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[SQLSOURCECONTROL_POPULATETABLE_PhotoType]    Script Date: 12/13/2018 14:42:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Landerman, Lou
-- Create date: 10/19/2017
-- Description:	Populates Table PhotoType
-- =============================================
CREATE PROCEDURE [dbo].[SQLSOURCECONTROL_POPULATETABLE_PhotoType]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SET IDENTITY_INSERT [dbo].[PhotoType] ON

	IF NOT EXISTS (SELECT 1 FROM [PhotoType] WHERE [ptyPhotoTypeID] = 1)
	BEGIN
		INSERT INTO [PhotoType] ([ptyPhotoTypeID],[ptyPhotoTypeDesc])VALUES(1,'Kiosk Attract Background')
	END
	ELSE
	BEGIN
		UPDATE [PhotoType] SET [ptyPhotoTypeDesc] = 'Kiosk Attract Background' WHERE [ptyPhotoTypeID] = 1;
	END

	IF NOT EXISTS (SELECT 1 FROM [PhotoType] WHERE [ptyPhotoTypeID] = 2)
	BEGIN
		INSERT INTO [PhotoType] ([ptyPhotoTypeID],[ptyPhotoTypeDesc])VALUES(2,'Kiosk Welcome Logo')
	END
	ELSE
	BEGIN
		UPDATE [PhotoType] SET [ptyPhotoTypeDesc] = 'Kiosk Welcome Logo' WHERE [ptyPhotoTypeID] = 2;
	END

	IF NOT EXISTS (SELECT 1 FROM [PhotoType] WHERE [ptyPhotoTypeID] = 3)
	BEGIN
		INSERT INTO [PhotoType] ([ptyPhotoTypeID],[ptyPhotoTypeDesc])VALUES(3,'Hall Display Logo')
	END
	ELSE
	BEGIN
		UPDATE [PhotoType] SET [ptyPhotoTypeDesc] = 'Hall Display Logo' WHERE [ptyPhotoTypeID] = 3;
	END

	IF NOT EXISTS (SELECT 1 FROM [PhotoType] WHERE [ptyPhotoTypeID] = 4)
	BEGIN
		INSERT INTO [PhotoType] ([ptyPhotoTypeID],[ptyPhotoTypeDesc])VALUES(4,'Virtual Flashboard Logo')
	END
	ELSE
	BEGIN
		UPDATE [PhotoType] SET [ptyPhotoTypeDesc] = 'Virtual Flashboard Logo' WHERE [ptyPhotoTypeID] = 4;
	END

	IF NOT EXISTS (SELECT 1 FROM [PhotoType] WHERE [ptyPhotoTypeID] = 5)
	BEGIN
		INSERT INTO [PhotoType] ([ptyPhotoTypeID],[ptyPhotoTypeDesc])VALUES(5,'Bonanza Flashboard Logo')
	END
	ELSE
	BEGIN
		UPDATE [PhotoType] SET [ptyPhotoTypeDesc] = 'Bonanza Flashboard Logo' WHERE [ptyPhotoTypeID] = 5;
	END

	IF NOT EXISTS (SELECT 1 FROM [PhotoType] WHERE [ptyPhotoTypeID] = 6)
	BEGIN
		INSERT INTO [PhotoType] ([ptyPhotoTypeID],[ptyPhotoTypeDesc])VALUES(6,'VRBall HotBall Background')
	END
	ELSE
	BEGIN
		UPDATE [PhotoType] SET [ptyPhotoTypeDesc] = 'VRBall HotBall Background' WHERE [ptyPhotoTypeID] = 6;
	END

	IF NOT EXISTS (SELECT 1 FROM [PhotoType] WHERE [ptyPhotoTypeID] = 7)
	BEGIN
		INSERT INTO [PhotoType] ([ptyPhotoTypeID],[ptyPhotoTypeDesc])VALUES(7,'76 Extra Ball')
	END
	ELSE
	BEGIN
		UPDATE [PhotoType] SET [ptyPhotoTypeDesc] = '76 Extra Ball' WHERE [ptyPhotoTypeID] = 7;
	END

	IF NOT EXISTS (SELECT 1 FROM [PhotoType] WHERE [ptyPhotoTypeID] = 8)
	BEGIN
		INSERT INTO [PhotoType] ([ptyPhotoTypeID],[ptyPhotoTypeDesc])VALUES(8,'77 Extra Ball')
	END
	ELSE
	BEGIN
		UPDATE [PhotoType] SET [ptyPhotoTypeDesc] = '77 Extra Ball' WHERE [ptyPhotoTypeID] = 8;
	END

	IF NOT EXISTS (SELECT 1 FROM [PhotoType] WHERE [ptyPhotoTypeID] = 9)
	BEGIN
		INSERT INTO [PhotoType] ([ptyPhotoTypeID],[ptyPhotoTypeDesc])VALUES(9,'78 Extra Ball')
	END
	ELSE
	BEGIN
		UPDATE [PhotoType] SET [ptyPhotoTypeDesc] = '78 Extra Ball' WHERE [ptyPhotoTypeID] = 9;
	END

	IF NOT EXISTS (SELECT 1 FROM [PhotoType] WHERE [ptyPhotoTypeID] = 10)
	BEGIN
		INSERT INTO [PhotoType] ([ptyPhotoTypeID],[ptyPhotoTypeDesc])VALUES(10,'79 Extra Ball')
	END
	ELSE
	BEGIN
		UPDATE [PhotoType] SET [ptyPhotoTypeDesc] = '79 Extra Ball' WHERE [ptyPhotoTypeID] = 10;
	END

	IF NOT EXISTS (SELECT 1 FROM [PhotoType] WHERE [ptyPhotoTypeID] = 11)
	BEGIN
		INSERT INTO [PhotoType] ([ptyPhotoTypeID],[ptyPhotoTypeDesc])VALUES(11,'80 Extra Ball')
	END
	ELSE
	BEGIN
		UPDATE [PhotoType] SET [ptyPhotoTypeDesc] = '80 Extra Ball' WHERE [ptyPhotoTypeID] = 11;
	END

	IF NOT EXISTS (SELECT 1 FROM [PhotoType] WHERE [ptyPhotoTypeID] = 12)
	BEGIN
		INSERT INTO [PhotoType] ([ptyPhotoTypeID],[ptyPhotoTypeDesc])VALUES(12,'CBB Printer Attract')
	END
	ELSE
	BEGIN
		UPDATE [PhotoType] SET [ptyPhotoTypeDesc] = 'CBB Printer Attract' WHERE [ptyPhotoTypeID] = 12;
	END

	IF NOT EXISTS (SELECT 1 FROM [PhotoType] WHERE [ptyPhotoTypeID] = 13)
	BEGIN
		INSERT INTO [PhotoType] ([ptyPhotoTypeID],[ptyPhotoTypeDesc])VALUES(13,'Icon Player Tier')
	END
	ELSE
	BEGIN
		UPDATE [PhotoType] SET [ptyPhotoTypeDesc] = 'Icon Player Tier' WHERE [ptyPhotoTypeID] = 13;
	END

	SET IDENTITY_INSERT [dbo].[PhotoType] OFF
END


GO




