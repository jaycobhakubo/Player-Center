/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2008 R2 (10.50.2500)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [Daily]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[spSetConfigPhoto]
--=============================================================================
-- ????.??.?? - Initial implementation
-- 2019.01.23 jkn: Adding support for using the config photo id 
--
-- In order for C++ to handle the varbinary(max) field, the server will first 
-- insert or update a record making cpPhotoBLOB equal to NULL, then the binary value
-- for the photo will be entered through a secondary C++ routine.
--=============================================================================
	@PhotoTypeId int,
    @ConfigPhotoId int,
	@OperatorId int
as
SET NOCOUNT ON

IF EXISTS (SELECT 1 FROM ConfigPhoto (NOLOCK) WHERE cpOperatorID = @OperatorId
			AND cpPhotoTypeID = @PhotoTypeId
            AND cpConfigPhotoID = @ConfigPhotoId)
BEGIN
	UPDATE ConfigPhoto
	SET cpPhotoBLOB = NULL
	WHERE cpOperatorId = @OperatorId
	    AND cpPhotoTypeId = @PhotoTypeId
        AND cpConfigPhotoId = @ConfigPhotoId
END
ELSE
BEGIN
	-- This is being done due to the ConfigPhoto table not having an autoincrement setting
    --  on the PK_ConfigPhoto constraint
    SELECT @ConfigPhotoID = ISNULL(MAX(cpConfigPhotoID), 0) + 1 FROM ConfigPhoto (NOLOCK) 

	INSERT ConfigPhoto (
		cpConfigPhotoID,
		cpOperatorID,
		cpPhotoTypeID,
		cpPhotoBLOB)
	VALUES (
		@ConfigPhotoId,
		@OperatorId,
		@PhotoTypeId,
		NULL)
END

SELECT ConfigPhotoID = @ConfigPhotoId

SET NOCOUNT OFF
