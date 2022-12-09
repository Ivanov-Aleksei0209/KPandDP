-- JournalPDO
if not exists (SELECT*FROM dbo.JournalPDO WHERE Name='LiftingCranes' and JournalNumber=31)
if not exists (SELECT*FROM dbo.JournalPDO WHERE Name='Lifts' and JournalNumber=32)
if not exists (SELECT*FROM dbo.JournalPDO WHERE Name='Escalators' and JournalNumber=33)
if not exists (SELECT*FROM dbo.JournalPDO WHERE Name='Elevators' and JournalNumber=34)
if not exists (SELECT*FROM dbo.JournalPDO WHERE Name='Attractions' and JournalNumber=36)
begin
insert into dbo.JournalPDO
values
('LiftingCranes', 31), 
('Lifts', 32), 
('Escalators', 33), 
('Elevators', 34), 
('Attractions', 36)
end
go

-- Inspector
if not exists (SELECT*FROM dbo.Inspector WHERE Name='Ivanov A.')
if not exists (SELECT*FROM dbo.Inspector WHERE Name='Koncevoi S.')
if not exists (SELECT*FROM dbo.Inspector WHERE Name='Poltorak A.')
if not exists (SELECT*FROM dbo.Inspector WHERE Name='Smolovik G.')
begin
insert into dbo.Inspector
values
('Ivanov A.'), 
('Koncevoi S.'), 
('Poltorak A.'), 
('Smolovik G.') 
end
go

-- TypeOfPdo
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name='automotive' and Abb='CA')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name='bridge' and Abb='CB')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name='gantry' and Abb='CG')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name='tower' and Abb='CT')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name='portal' and Abb='CP')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name='railway' and Abb='CR')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name='specialClass' and Abb='CSc')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name='pneumowheel' and Abb='CPw')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name='crawler' and Abb='CC')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name='passengerElectric' and Abb='LPe')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name='cargoElectric' and Abb='LCe')
if not exists (SELECT*FROM dbo.TypeOfPdo WHERE Name='hospitalElectric' and Abb='LHe')
begin
insert into dbo.TypeOfPdo
values
('automotive', 'CA'), 
('bridge', 'CB'), 
('gantry', 'CG'), 
('tower', 'CT'),
('portal', 'CP'), 
('railway', 'CR'), 
('specialClass', 'CSc'), 
('pneumowheel', 'CPw'),
('crawler', 'CC'),
('passengerElectric', 'LPe'), 
('cargoElectric', 'LCe'), 
('hospitalElectric', 'LHe')
end
go

-- PDO
if not exists (SELECT*FROM dbo.PDO WHERE JournalPdoId=1 and RegistrationNumber=0001 and TypeId=1 and DateOfRegistration='05.12.2022' and YearOfManufacture=2010 
and TechnicalSpecification='' and ServiceLife=10 and InformationAboutTheTechnicalInspection='20.10.2022' and InspectorId=1
and TechnicalConditional='' and Owner_Subject='Delta' and InstallationLocation='')
begin
insert into dbo.PDO
values
(1, 0001, 1, '05.12.2022', 2010, '', 10, '20.10.2022', 1, '', 'Delta', '') 
end
go

-- TechnicalSpecification
if not exists (SELECT*FROM dbo.TechnicalSpecification WHERE Capacity=25 and ArrowDeparture=18.0 and Speed=0 and NumberOfStops=0)
begin
insert into dbo.TechnicalSpecification
values
(25, 18.0, 0, 0)
end
go

-- Subject
if not exists (SELECT*FROM dbo.Subject WHERE Name='Delta' and UNP=490124456 and departmentalAffiliation='withoutDepartmentalAffiliation'
and postalAddress='Trudovaya str, 39A, Borschovka, Rechica region' and phone='8-029-457-78-98')
begin
insert into dbo.Subject
values
('Delta', 490124456, 'withoutDepartmentalAffiliation', 'Trudovaya str, 39A, Borschovka, Rechica region', '8-029-457-78-98')
end
go

-- TechnicalConditional
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name='OperatedBy')
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name='NotOperated')
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name='Banned')
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name='UnderRepair')
begin
insert into dbo.TechnicalConditional
values
('OperatedBy'), 
('NotOperated'), 
('Banned'), 
('UnderRepair') 
end
go

-- InstallationLocation
if not exists (SELECT*FROM dbo.InstallationLocation WHERE Name='housingStock')
if not exists (SELECT*FROM dbo.InstallationLocation WHERE Name='dormitory')
if not exists (SELECT*FROM dbo.InstallationLocation WHERE Name='healthcareInstitution')
if not exists (SELECT*FROM dbo.InstallationLocation WHERE Name='administrativeBuilding')
if not exists (SELECT*FROM dbo.InstallationLocation WHERE Name='productionBuilding')
if not exists (SELECT*FROM dbo.InstallationLocation WHERE Name='constructionSite')
begin
insert into dbo.InstallationLocation
values
('housingStock'), 
('dormitory'), 
('healthcareInstitution'), 
('institutionEducation'),
('administrativeBuilding'), 
('productionBuilding'),
('constructionSite')
end
go
