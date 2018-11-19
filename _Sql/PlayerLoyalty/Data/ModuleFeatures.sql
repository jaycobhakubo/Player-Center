use Daily;


if not exists (select 1 from ModuleGroup where mgModuleId = 3)
begin
    insert into ModuleGroup
        (mgModuleId
        , mgSequenceNo
        , mgModuleGroupName
        , mgIsActive)
    values
        (3
        , 1
        , N'Player Center'
        , 1)
end

--set identity_insert ModuleFeatures on;
--select * from ModuleFeatures where ModuleFeatureId = 38
if not exists (select 1 from ModuleFeatures where ModuleFeatureName = 'Player Loyalty')
begin
    insert into ModuleFeatures
        (/*ModuleFeatureId*/
         ModuleId
        , ModuleFeatureName
        , ModuleFeatureDescription
        , IsCreditFeature
        , IsGTIStaffFeature
        , SequenceNo)
    values
        ( 3 -- Player Center
        , N'Player Loyalty'
        , N'Allows the user the ability to add, edit, and delete Player Loyalty Tiers'
        , 0
        , 1
        , 1)
end

--set identity_insert ModuleFeatures off;


Select * from ModuleFeatures
//=================================================
use Daily;

if exists (select * from ModuleFeatures where ModuleFeatureId = 8)
begin
    update ModuleFeatures set SequenceNo = 1 where ModuleFeatureId = 8;
end

--Not sure if this is part of the project. Not executed
