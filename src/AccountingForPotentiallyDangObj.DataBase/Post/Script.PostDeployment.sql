--- JournalPDO
if not exists (SELECT*FROM dbo.JournalPDO WHERE Name='Грузоподъемные краны' and JournalNumber=31)
begin
insert into dbo.JournalPDO
values
('Грузоподъемные краны', 31)
end
go

