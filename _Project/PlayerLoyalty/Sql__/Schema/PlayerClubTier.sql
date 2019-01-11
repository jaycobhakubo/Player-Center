    Use Daily 
    Go

--Add column TierImgId

if not exists(select 1 from sys.columns a  join sys.tables b on b.object_id = a.object_id 
			where a.name = 'TierImgId' and b.name = 'PlayerClubTier')
begin
    alter table PlayerClubTier
    add TierImgId int
end
    

