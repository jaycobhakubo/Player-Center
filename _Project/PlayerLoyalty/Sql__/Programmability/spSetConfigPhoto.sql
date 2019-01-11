USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spSetConfigPhoto]    Script Date: 12/13/2018 14:38:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSetConfigPhoto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSetConfigPhoto]
GO

USE [Daily]
GO

/****** Object:  StoredProcedure [dbo].[spSetConfigPhoto]    Script Date: 12/13/2018 14:38:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spSetConfigPhoto]
	@PhotoTypeID int,
	@OperatorID int,
	@PhotoBLOB varbinary(max) = NULL
as
--In order for C++ to handle the varbinary(max) field, the server will first 
--insert or update a record making cpPhotoBLOB equal to NULL, then the binary value
--for the photo will be entered through a secondary C++ routine.
SET NOCOUNT ON

Declare @ConfigPhotoID int

if exists (select 1 from ConfigPhoto (nolock) where (cpOperatorID = @OperatorID
			and cpPhotoTypeID = @PhotoTypeID)and cpPhotoTypeID != 13 )
begin
	update ConfigPhoto
	set cpPhotoBLOB = @PhotoBLOB
	where cpOperatorID = @OperatorID
	and cpPhotoTypeID = @PhotoTypeID

	select @ConfigPhotoID = cpConfigPhotoID
	from ConfigPhoto (nolock)
	where cpOperatorID = @OperatorID
	and cpPhotoTypeID = @PhotoTypeID
end
else
begin
	select @ConfigPhotoID = ISNULL(MAX(cpConfigPhotoID), 0) + 1 from ConfigPhoto (nolock) 

	insert ConfigPhoto (
		cpConfigPhotoID,
		cpOperatorID,
		cpPhotoTypeID,
		cpPhotoBLOB)
	values (
		@ConfigPhotoID,
		@OperatorID,
		@PhotoTypeID,
		@PhotoBLOB)
end

select ConfigPhotoID = @ConfigPhotoID

SET NOCOUNT OFF




GO


