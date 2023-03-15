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

-- Inspector
if not exists (SELECT*FROM dbo.Inspector WHERE Name=N'Иванов А.А.')
if not exists (SELECT*FROM dbo.Inspector WHERE Name=N'Концевой С.Н.')
if not exists (SELECT*FROM dbo.Inspector WHERE Name=N'Полторак А.С.')
if not exists (SELECT*FROM dbo.Inspector WHERE Name=N'Смоловик Г.В.')
if not exists (SELECT*FROM dbo.Inspector WHERE Name=N'снят с учета')
begin
insert into dbo.Inspector
values
(N'Иванов А.А.'), 
(N'Концевой С.Н.'), 
(N'Полторак А.С.'), 
(N'Смоловик Г.В.'),
(N'снят с учета')
end
go

-- TypeOfPdo
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'автомобильный' and Abb=N'КСА')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'мостовой' and Abb=N'КМ')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'козловой' and Abb=N'КК')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'башенный' and Abb=N'КБ')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'портальный' and Abb=N'КП')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'железнодорожный' and Abb=N'КЖд')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'на спец. шасси' and Abb=N'КСп')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'пневмоколесный' and Abb=N'КПк')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'гусеничный' and Abb=N'КГ')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'пассажирский' and Abb=N'ЛПэ')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'грузовой' and Abb=N'ЛГэ')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name=N'больничный' and Abb=N'ЛБэ')
begin
insert into dbo.TypeOfPdo
values
(N'автомобильный', N'КСА'), 
(N'мостовой', N'КМ'), 
(N'козловой', N'КК'), 
(N'башенный', N'КБ'),
(N'портальный', N'КП'), 
(N'железнодорожный', N'КЖд'), 
(N'на спец. шасси', N'КСп'), 
(N'пневмоколесный', N'КПн'),
(N'гусеничный', N'КГ'),
(N'пассажирский', N'ЛПэ'), 
(N'грузовой', N'ЛГэ'), 
(N'больничный', N'ЛБэ')
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

-- Subject
if not exists (SELECT*FROM dbo.Subject WHERE Name=N'ОАО "Буровая компания "Дельта"' and UNP=490124456 and departmentalAffiliationId=8
and postalAddress=N'ул. Трудовая, 39А, д. Борщевка, Речицкий р-н' and phone='8-029-457-78-98')
if not exists (SELECT*FROM dbo.Subject WHERE Name=N'ГП "Центральное"' and UNP=490000011 and departmentalAffiliationId=1
and postalAddress=N'ул. Тельмана, 26А, г. Гомель' and phone='8-0232-50-50-02')
if not exists (SELECT*FROM dbo.Subject WHERE Name=N'ОАО "Гомсельмаш"' and UNP=490002415 and departmentalAffiliationId=2
and postalAddress=N'ул. Трудовая, 13, г. Гомель' and phone='8-0232-54-65-02')
if not exists (SELECT*FROM dbo.Subject WHERE Name=N'ОАО "Гомельдрев"' and UNP=490006578 and departmentalAffiliationId=7
and postalAddress=N'ул. Севастопольская, 15, г. Гомель' and phone='8-0232-34-50-32')
if not exists (SELECT*FROM dbo.Subject WHERE Name=N'УО "ГГТУ им. П.О.Сухого"' and UNP=490003657 and departmentalAffiliationId=5
and postalAddress=N'пр-т Октября, 48, г. Гомель' and phone='8-0232-23-78-69')
if not exists (SELECT*FROM dbo.Subject WHERE Name='ОАО "СтанкоГомель"' and UNP=490065897 and departmentalAffiliationId=2
and postalAddress='ул. Интернациональная, 8, г. Гомель' and phone='8-0232-65-87-21')
if not exists (SELECT*FROM dbo.Subject WHERE Name=N'УЗ "Гомельская ОКБ"' and UNP=490087965 and departmentalAffiliationId=4
and postalAddress=N'ул. Бр.Лизюковых, 32, г. Гомель' and phone='8-0232-65-87-21')
begin
insert into dbo.Subject
values
(N'ОАО "Буровая компания "Дельта"', 490124456, 8, N'ул. Трудовая, 39А, д. Борщевка, Речицкий р-н', '8-029-457-78-98'),
(N'ГП "Центральное"', 490000011, 1, N'ул. Тельмана, 26А, г. Гомель', '8-0232-50-50-02'),
(N'ОАО "Гомсельмаш"', 490002415, 2, N'ул. Трудовая, 13, г. Гомель', '8-0232-54-65-02'),
(N'ОАО "Гомельдрев"', 490006578, 7, N'ул. Севастопольская, 15, г. Гомель', '8-0232-34-50-32'),
(N'УО "ГГТУ им. П.О.Сухого"', 490003657, 5, N'пр-т Октября, 48, г. Гомель', '8-0232-23-78-69'),
(N'ОАО "СтанкоГомель"', 490065897, 2, N'ул. Интернациональная, 8, г. Гомель', '8-0232-65-87-21'),
(N'УЗ "Гомельская ОКБ"', 490087965, 4, N'ул. Бр.Лизюковых, 32, г. Гомель', '8-0232-65-87-21')
end
go

-- TechnicalSpecification
if not exists (SELECT*FROM dbo.TechnicalSpecification WHERE 
Capacity=500 and 
ArrowDeparture=0 and 
Speed=1.0 and 
NumberOfStops=9 and
Name='01')
if not exists (SELECT*FROM dbo.TechnicalSpecification WHERE 
Capacity=25 and 
ArrowDeparture=18.5 and 
Speed=0 and 
NumberOfStops=0 and
Name='02')
begin
insert into dbo.TechnicalSpecification
values
(500, 0, 1.0, 9, '01'),
(25, 18.5, 0, 0, '02')
end
go

-- TechnicalConditional
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name=N'эксплуатируется')
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name=N'не эксплуатируется')
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name=N'запрещен')
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name=N'в ремонте')
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name=N'снят с учета')
begin
insert into dbo.TechnicalConditional
values
(N'эксплуатируется'), 
(N'не эксплуатируется'), 
(N'запрещен'), 
(N'в ремонте'),
(N'снят с учета')
end
go

-- Pdo
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=2 and 
RegistrationNumber=0001 and 
TypeId=10 and 
DateOfRegistration=N'2022-12-15' and 
YearOfManufacture=2022 and 
TechnicalSpecificationId=1 and 
ServiceLife=25 and 
InformationAboutTheTechnicalInspection=N'2022-12-10' and 
InspectorId=2 and 
TechnicalConditionalId=1 and 
SubjectId=2 and 
InstallationLocationId=1 and
WithdrawalFromRegistration=null and
Name='01')
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=1 and 
RegistrationNumber=0001 and 
TypeId=1 and 
DateOfRegistration=N'2022-12-05' and 
YearOfManufacture=2010 and 
TechnicalSpecificationId=2 and 
ServiceLife=10 and 
InformationAboutTheTechnicalInspection=N'2022-10-20' and 
InspectorId=1 and 
TechnicalConditionalId=1 and 
SubjectId=1 and 
InstallationLocationId=6 and
WithdrawalFromRegistration=null and
Name='02')
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=1 and 
RegistrationNumber=0002 and 
TypeId=2 and 
DateOfRegistration=N'2020-02-13' and 
YearOfManufacture=2000 and 
TechnicalSpecificationId=2 and 
ServiceLife=10 and 
InformationAboutTheTechnicalInspection=N'2021-10-20' and 
InspectorId=2 and 
TechnicalConditionalId=2 and 
SubjectId=3 and 
InstallationLocationId=5 and
WithdrawalFromRegistration=null and
Name='03')
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=1 and 
RegistrationNumber=0003 and 
TypeId=2 and 
DateOfRegistration=N'2022-12-05' and 
YearOfManufacture=2020 and 
TechnicalSpecificationId=2 and 
ServiceLife=10 and 
InformationAboutTheTechnicalInspection=N'2022-10-20' and 
InspectorId=3 and 
TechnicalConditionalId=3 and 
SubjectId=3 and 
InstallationLocationId=5 and
WithdrawalFromRegistration=null and
Name='04')
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=1 and 
RegistrationNumber=0004 and 
TypeId=2 and 
DateOfRegistration=N'2022-12-05' and 
YearOfManufacture=2010 and 
TechnicalSpecificationId=2 and 
ServiceLife=10 and 
InformationAboutTheTechnicalInspection=N'2022-10-20' and 
InspectorId=4 and 
TechnicalConditionalId=1 and 
SubjectId=4 and 
InstallationLocationId=5 and
WithdrawalFromRegistration=null and
Name='05')
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=1 and 
RegistrationNumber=0005 and 
TypeId=1 and 
DateOfRegistration=N'2022-12-05' and 
YearOfManufacture=2000 and 
TechnicalSpecificationId=2 and 
ServiceLife=10 and 
InformationAboutTheTechnicalInspection=N'2022-10-20' and 
InspectorId=1 and 
TechnicalConditionalId=4 and 
SubjectId=3 and 
InstallationLocationId=6 and
WithdrawalFromRegistration=null and
Name='06')
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=1 and 
RegistrationNumber=0006 and 
TypeId=1 and 
DateOfRegistration=N'2022-12-05' and 
YearOfManufacture=2020 and 
TechnicalSpecificationId=2 and 
ServiceLife=10 and 
InformationAboutTheTechnicalInspection=N'2022-10-20' and 
InspectorId=2 and 
TechnicalConditionalId=1 and 
SubjectId=6 and 
InstallationLocationId=6 and
WithdrawalFromRegistration=null and
Name='07')
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=1 and 
RegistrationNumber=0007 and 
TypeId=3 and 
DateOfRegistration=N'2022-12-05' and 
YearOfManufacture=2000 and 
TechnicalSpecificationId=2 and 
ServiceLife=20 and 
InformationAboutTheTechnicalInspection=N'2022-10-20' and 
InspectorId=1 and 
TechnicalConditionalId=1 and 
SubjectId=4 and 
InstallationLocationId=5 and
WithdrawalFromRegistration=null and
Name='08')
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=2 and 
RegistrationNumber=0002 and 
TypeId=10 and 
DateOfRegistration=N'2022-12-05' and 
YearOfManufacture=2010 and 
TechnicalSpecificationId=2 and 
ServiceLife=25 and 
InformationAboutTheTechnicalInspection=N'2022-10-20' and 
InspectorId=3 and 
TechnicalConditionalId=1 and 
SubjectId=5 and 
InstallationLocationId=2 and
WithdrawalFromRegistration=null and
Name='09')
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=2 and 
RegistrationNumber=0003 and 
TypeId=12 and 
DateOfRegistration=N'2022-12-05' and 
YearOfManufacture=1997 and 
TechnicalSpecificationId=2 and 
ServiceLife=25 and 
InformationAboutTheTechnicalInspection=N'2022-10-20' and 
InspectorId=4 and 
TechnicalConditionalId=1 and 
SubjectId=7 and 
InstallationLocationId=3 and
WithdrawalFromRegistration=null and
Name='10')
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=2 and 
RegistrationNumber=0004 and 
TypeId=10 and 
DateOfRegistration=N'2022-12-05' and 
YearOfManufacture=1995 and 
TechnicalSpecificationId=2 and 
ServiceLife=25 and 
InformationAboutTheTechnicalInspection=N'2022-10-20' and 
InspectorId=1 and 
TechnicalConditionalId=1 and 
SubjectId=2 and 
InstallationLocationId=1 and
WithdrawalFromRegistration=null and
Name='11')
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=1 and 
RegistrationNumber=0008 and 
TypeId=1 and 
DateOfRegistration=N'2022-12-05' and 
YearOfManufacture=1995 and 
TechnicalSpecificationId=2 and 
ServiceLife=10 and 
InformationAboutTheTechnicalInspection=N'2022-10-20' and 
InspectorId=5 and 
TechnicalConditionalId=5 and 
SubjectId=1 and 
InstallationLocationId=7 and
WithdrawalFromRegistration=N'2022-10-20' and
Name='12')
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=1 and 
RegistrationNumber=0009 and 
TypeId=1 and 
DateOfRegistration=N'2022-12-05' and 
YearOfManufacture=1995 and 
TechnicalSpecificationId=2 and 
ServiceLife=10 and 
InformationAboutTheTechnicalInspection=N'2022-10-20' and 
InspectorId=1 and 
TechnicalConditionalId=1 and 
SubjectId=1 and 
InstallationLocationId=6 and
WithdrawalFromRegistration=null and
Name='13')
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=2 and 
RegistrationNumber=0005 and 
TypeId=10 and 
DateOfRegistration=N'2022-12-05' and 
YearOfManufacture=1995 and 
TechnicalSpecificationId=2 and 
ServiceLife=25 and 
InformationAboutTheTechnicalInspection=N'2022-10-20' and 
InspectorId=5 and 
TechnicalConditionalId=5 and 
SubjectId=2 and 
InstallationLocationId=7 and
WithdrawalFromRegistration=N'2023-10-20' and
Name='14')
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=2 and 
RegistrationNumber=0006 and 
TypeId=10 and 
DateOfRegistration=N'2022-12-05' and 
YearOfManufacture=2023 and 
TechnicalSpecificationId=2 and 
ServiceLife=25 and 
InformationAboutTheTechnicalInspection=N'2022-10-20' and 
InspectorId=1 and 
TechnicalConditionalId=1 and 
SubjectId=2 and 
InstallationLocationId=1 and
WithdrawalFromRegistration=null and
Name='15')
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=2 and 
RegistrationNumber=0007 and 
TypeId=12 and 
DateOfRegistration=N'2022-12-05' and 
YearOfManufacture=2020 and 
TechnicalSpecificationId=2 and 
ServiceLife=25 and 
InformationAboutTheTechnicalInspection=N'2022-10-20' and 
InspectorId=2 and 
TechnicalConditionalId=1 and 
SubjectId=7 and 
InstallationLocationId=3 and
WithdrawalFromRegistration=null and
Name='16')
if not exists (SELECT*FROM dbo.Pdo WHERE 
JournalPdoId=2 and 
RegistrationNumber=0008 and 
TypeId=12 and 
DateOfRegistration=N'2022-12-05' and 
YearOfManufacture=1995 and 
TechnicalSpecificationId=2 and 
ServiceLife=25 and 
InformationAboutTheTechnicalInspection=N'2022-10-20' and 
InspectorId=3 and 
TechnicalConditionalId=1 and 
SubjectId=7 and 
InstallationLocationId=3 and
WithdrawalFromRegistration=null and
Name='17')
begin
insert into dbo.Pdo
values
(2, 0001, 10, N'2022-12-15', 2022, 1, 25, N'2022-12-10', 2, 1, 2, 1, null, '01'),
(1, 0001, 1, N'2022-12-05', 2010, 2, 10, N'2022-10-20', 1, 1, 1, 6, null, '02'),
(1, 0002, 2, N'2020-02-13', 2000, 2, 10, N'2021-10-20', 2, 2, 3, 6, null, '03'),
(1, 0003, 2, N'2022-12-05', 2020, 2, 10, N'2022-10-20', 3, 3, 3, 5, null, '04'),
(1, 0004, 2, N'2022-12-05', 2010, 2, 10, N'2022-10-20', 4, 1, 4, 5, null, '05'),
(1, 0005, 1, N'2022-12-05', 2000, 2, 10, N'2022-10-20', 1, 4, 3, 6, null, '06'),
(1, 0006, 1, N'2022-12-05', 2020, 2, 10, N'2022-10-20', 2, 1, 6, 6, null, '07'),
(1, 0007, 3, N'2022-12-05', 2000, 2, 20, N'2022-10-20', 1, 1, 4, 5, null, '08'),
(2, 0002, 10, N'2022-12-05', 2010, 2, 25, N'2022-10-20', 3, 1, 5, 2, null, '09'),
(2, 0003, 12, N'2022-12-05', 1997, 2, 25, N'2022-10-20', 4, 1, 7, 3, null, '10'),
(2, 0004, 10, N'2022-12-05', 1995, 2, 25, N'2022-10-20', 1, 1, 2, 1, null, '11'),
(1, 0008, 1, N'2022-12-05', 1995, 2, 10, N'2022-10-20', 5, 5, 1, 7, N'2022-10-20', '12'),
(1, 0009, 1, N'2022-12-05', 1995, 2, 10, N'2022-10-20', 1, 1, 1, 6, null, '13'),
(2, 0005, 10, N'2022-12-05', 1995, 2, 25, N'2022-10-20', 5, 5, 2, 7, N'2023-10-20', '14'),
(2, 0006, 10, N'2022-12-05', 2023, 2, 25, N'2022-10-20', 1, 1, 2, 1, null, '15'),
(2, 0007, 12, N'2022-12-05', 2020, 2, 25, N'2022-10-20', 2, 1, 7, 3, null, '16'),
(2, 0008, 12, N'2022-12-05', 1995, 2, 25, N'2022-10-20', 3, 1, 7, 3, null, '17'),
(2, 0028, 12, N'2022-12-05', 1995, 2, 25, N'2022-10-20', 3, 1, 7, 3, null, '18'),
(2, 0208, 12, N'2022-12-05', 1995, 2, 25, N'2022-10-20', 3, 1, 7, 3, null, '19'),
(2, 3008, 12, N'2022-12-05', 1995, 2, 25, N'2022-10-20', 3, 1, 7, 3, null, '20')
end
go

