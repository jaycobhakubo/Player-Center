use Daily;

set identity_insert AuditTypes on;

if not exists (select 1 from AuditTypes where AuditTypeId = 18)
begin
    insert into AuditTypes (AuditTypeId, Name) values (18, N'Player Loyalty (Setting Changes)');
end

set identity_insert AuditTypes off


--SELECT * FROM AuditTypes
