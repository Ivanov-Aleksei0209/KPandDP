-- Role
if not exists (SELECT*FROM dbo.Role WHERE Name=N'инспектор')
if not exists (SELECT*FROM dbo.Role WHERE Name=N'старший инспектор')
if not exists (SELECT*FROM dbo.Role WHERE Name=N'ведущий инспектор')
if not exists (SELECT*FROM dbo.Role WHERE Name=N'главный инспектор')
if not exists (SELECT*FROM dbo.Role WHERE Name=N'начальник отдела')
if not exists (SELECT*FROM dbo.Role WHERE Name=N'начальник управления')
if not exists (SELECT*FROM dbo.Role WHERE Name=N'нет')
begin
insert into dbo.Role
values
(N'инспектор'), 
(N'старший инспектор'), 
(N'ведущий инспектор'), 
(N'главный инспектор'),
(N'начальник отдела'),
(N'начальник управления'),
(N'нет')
end
go

-- JournalPdo
if not exists (SELECT*FROM dbo.JournalPdo WHERE Name=N'Грузоподъемные краны' and JournalNumber=31)
if not exists (SELECT*FROM dbo.JournalPdo WHERE Name=N'Лифты' and JournalNumber=32)
if not exists (SELECT*FROM dbo.JournalPdo WHERE Name=N'Эскалаторы' and JournalNumber=33)
if not exists (SELECT*FROM dbo.JournalPdo WHERE Name=N'Подъемники' and JournalNumber=34)
if not exists (SELECT*FROM dbo.JournalPdo WHERE Name=N'Аттракционы' and JournalNumber=36)
begin
insert into dbo.JournalPdo
values
(N'Грузоподъемные краны', 31), 
(N'Лифты', 32), 
(N'Эскалаторы', 33), 
(N'Подъемники', 34), 
(N'Аттракционы', 36)
end
go

-- TypeOfPdo
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'автомобильный' and Abb=N'КСА')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'мостовой' and Abb=N'КМ')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'козловой' and Abb=N'КК')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'башенный' and Abb=N'КБ')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'портальный' and Abb=N'КП')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'железнодорожный' and Abb=N'КЖД')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'спецшасси' and Abb=N'КССп')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'пневмоколесный' and Abb=N'КСПк')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'гусеничный' and Abb=N'КСГ')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'кран-манипулятор' and Abb=N'КМн')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'пассажирский' and Abb=N'ЛПэ')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'грузовой' and Abb=N'ЛГэ')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'больничный' and Abb=N'ЛБэ')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'водная горка' and Abb=N'АГВ')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'атракцион' and Abb=N'АМ')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'подъемник' and Abb=N'ПЗР')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'тележка' and Abb=N'ТГЭ')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'эскалатор' and Abb=N'ЭП')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'конвейер' and Abb=N'ПК')
begin
insert into dbo.TypeOfPdo
values
(N'автомобильный', N'КСА'), 
(N'мостовой', N'КМ'), 
(N'козловой', N'КК'), 
(N'башенный', N'КБ'),
(N'портальный', N'КП'), 
(N'железнодорожный', N'КЖД'), 
(N'спецшасси', N'КССп'), 
(N'пневмоколесный', N'КСПк'),
(N'гусеничный', N'КСГ'),
(N'кран-манипулятор', N'КМн'),
(N'пассажирский', N'ЛПэ'), 
(N'грузовой', N'ЛГэ'), 
(N'больничный', N'ЛБэ'),
(N'водная горка', N'АГВ'),
(N'аттракцион', N'АМ'),
(N'подъемник', N'ПЗР'),
(N'тележка', N'ТГЭ'),
(N'эскалатор', N'ЭП'),
(N'конвейер', N'ПК')
end
go

-- InstallationLocation
if not exists (SELECT*FROM dbo.InstallationLocation WHERE Name=N'жилой фонд')
if not exists (SELECT*FROM dbo.InstallationLocation WHERE Name=N'общежитие')
if not exists (SELECT*FROM dbo.InstallationLocation WHERE Name=N'учреждение здравоохранения')
if not exists (SELECT*FROM dbo.InstallationLocation WHERE Name=N'административное здание')
if not exists (SELECT*FROM dbo.InstallationLocation WHERE Name=N'производственное здание')
if not exists (SELECT*FROM dbo.InstallationLocation WHERE Name=N'строительная площадка')
if not exists (SELECT*FROM dbo.InstallationLocation WHERE Name=N'снят с учета')
begin
insert into dbo.InstallationLocation
values
(N'жилой фонд'), 
(N'общежитие'), 
(N'учреждение здравоохранения'), 
(N'административное здание'), 
(N'производственное здание'),
(N'строительная площадка'),
(N'снят с учета')
end
go

-- DepartmentalAffiliation
if not exists (SELECT*FROM dbo.DepartmentalAffiliation WHERE Name=N'Облисполком')
if not exists (SELECT*FROM dbo.DepartmentalAffiliation WHERE Name=N'Минпром')
if not exists (SELECT*FROM dbo.DepartmentalAffiliation WHERE Name=N'Минэнергетики')
if not exists (SELECT*FROM dbo.DepartmentalAffiliation WHERE Name=N'Минздрав')
if not exists (SELECT*FROM dbo.DepartmentalAffiliation WHERE Name=N'Минобр')
if not exists (SELECT*FROM dbo.DepartmentalAffiliation WHERE Name=N'Белнефтехим')
if not exists (SELECT*FROM dbo.DepartmentalAffiliation WHERE Name=N'Беллесбумпром')
if not exists (SELECT*FROM dbo.DepartmentalAffiliation WHERE Name=N'без ведомственной подчиненности')
begin
insert into dbo.DepartmentalAffiliation
values
(N'Облисполком'), 
(N'Минпром'), 
(N'Минэнергетики'), 
(N'Минздрав'),
(N'Минобр'), 
(N'Белнефтехим'),
(N'Беллесбумпром'),
(N'без ведомственной подчиненности')
end
go

-- Inspector
if not exists (SELECT*FROM dbo.Inspector WHERE Name=N'Иванов А.А.' and RoleId=2)
if not exists (SELECT*FROM dbo.Inspector WHERE Name=N'Концевой С.Н.' and RoleId=2)
if not exists (SELECT*FROM dbo.Inspector WHERE Name=N'Полторак А.С.' and RoleId=4)
if not exists (SELECT*FROM dbo.Inspector WHERE Name=N'Смоловик Г.В.' and RoleId=3)
if not exists (SELECT*FROM dbo.Inspector WHERE Name=N'снят с учета' and RoleId=null)
begin
insert into dbo.Inspector
values
(N'Иванов А.А.', 2), 
(N'Концевой С.Н.', 2), 
(N'Полторак А.С.', 4), 
(N'Смоловик Г.В.', 3),
(N'Рафальский Д.С.', 1),
(N'снят с учета', null)
end
go

-- Subject
if not exists (SELECT*FROM dbo.Subject WHERE Name=N'ОАО "БК "Дельта"' and UNP=490124456 and departmentalAffiliationId=8
and postalAddress=N'ул. Трудовая, 39А, д. Борщевка, Речицкий р-н' and phone='8-029-457-78-98')

begin
insert into dbo.Subject
values
(N'ОАО "БК "Дельта"', 490124456, 8, N'ул. Трудовая, 39А, д. Борщевка, Речицкий р-н', '8-029-457-78-98')

end
go

-- TechnicalSpecification

if not exists (SELECT*FROM dbo.TechnicalSpecification WHERE 
Capacity=25 and 
ArrowDeparture=18.5 and 
Speed=0 and 
NumberOfStops=0 and
Name='02')
begin
insert into dbo.TechnicalSpecification
values
(25, 18.5, 0, 0, '02')
end
go

-- TechnicalConditional
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name=N'исправен')
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name=N'не эксплуатируется')
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name=N'запрещен')
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name=N'в ремонте')
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name=N'не пров. ТО')
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name=N'законсервирован')
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name=N'снят с учета')
begin
insert into dbo.TechnicalConditional
values
(N'исправен'), 
(N'не эксплуатируется'), 
(N'запрещен'), 
(N'в ремонте'),
(N'не пров. ТО'),
(N'законсервирован'),
(N'снят с учета')
end
go

-- Pdo

if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=2 and 
RegistrationNumber=9999 and 
TypeId=12 and 
DateOfRegistration=N'2022-12-05' and 
TechnicalSpecificationId=1 and 
ServiceLife=25 and
InspectorId=3 and 
TechnicalConditionalId=1 and
SubjectId=1 and
InstallationLocationId=1 and
InstallationLocationAddress=N'Борщевка' and
YearOfManufacture=1995 and 
YearOfCommissioning=1995 and
ModelName=N'Model' and
SerialNumber=N'12457n' and
Manufacturer=N'ОАО Могилевлифтмаш' and
InformationAboutTheLastSurvey=null and
InformationAboutTheTechnicalInspection=N'2022-10-20' and 
InformationAboutTheTechnicalDiagnostic=null and
WithdrawalFromRegistration=null and
Note=null and
Name='17')
begin
insert into dbo.Pdo
values

(2, 9999, 12, N'2022-12-05', 1, 25, 3, 1, 1, 1, N'Борщевка', 1995, 1995, N'Model', N'12457n', N'ОАО Могилевлифтмаш', null, N'2022-10-20', null, null, null, N'17')
end
go

