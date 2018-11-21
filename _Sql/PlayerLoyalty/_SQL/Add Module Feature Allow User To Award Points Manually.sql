use daily
go
if exists (select 1 from ModuleFeatures where ModuleFeatureID = 48 /*ModuleFeatureName like 'Manual Points Award to Player'*/)
begin 
   --Delete any row referencing to the ModuleFeatures table
	delete from FeaturePermissions where ModuleFeatureID = 48

	delete from daily.dbo.ModuleFeatures where ModuleFeatureID = 48
end


if not exists (select 1 from ModuleGroup where mgModuleID = 3 and mgSequenceNo = 1)
begin 
	insert into ModuleGroup 
	values(3,1,'Player Center',1)
end

set identity_insert daily.dbo.ModuleFeatures on				
insert into ModuleFeatures(ModuleFeatureID, ModuleID, ModuleFeatureName, ModuleFeatureDescription, IsCreditFeature, IsGTIStaffFeature, SequenceNo)
values (48, 3, 'Manual Points Award to Player','Award Points to Player',0,0,1)		
set identity_insert daily.dbo.ModuleFeatures off



