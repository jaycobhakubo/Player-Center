use daily
go



if not exists (select 1 from ModuleFeatures where ModuleFeatureName like 'Manual Points Award to Player')
begin
	--select @ModuleFeatureIdMax
	--select * from ModuleFeatures

--Lets add module group

declare @ModuleFeatureIdMax int
	declare @ModuleFeatureId int 
select @ModuleFeatureIdMax = max(ModuleFeatureID) from ModuleFeatures 



	set @ModuleFeatureId = @ModuleFeatureIdMax + 1

	set identity_insert daily.dbo.ModuleFeatures on
	
	select @ModuleFeatureId
	
	insert into ModuleFeatures(ModuleFeatureID, ModuleID, ModuleFeatureName, ModuleFeatureDescription, IsCreditFeature, IsGTIStaffFeature, SequenceNo)
	values (@ModuleFeatureId, 3, 'Manual Points Award to Player','Allow user to award points manually to a player',0,0,1)
	
	set identity_insert daily.dbo.ModuleFeatures off
end


--select * from ModuleGroup

