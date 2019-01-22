use Daily 
go
declare @startDate varchar(12) , @EndDate varchar(12)
set @startDate = '1/1/' + cast(YEAR(getdate()) as varchar(4))
set @EndDate = '1/1/' + cast ((YEAR(GETDATE()) + 1 ) as varchar(4)) 
declare @operatorID int = 0;
select @operatorID = OperatorID from Operator where IsActive = 1



if exists (select 1 from PlayerClubTierRules)
begin
--truncate table player
delete  PlayerClubTierRules
end


INSERT INTO [PlayerClubTierRules] ([OperatorId],[StartDate],[EndDate],[DefaultTierId],[DowngradeToDefault])
VALUES(@operatorID,@startDate,@EndDate,NULL,0) 

