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

-- DepartmentalAffiliation
if not exists (SELECT*FROM dbo.DepartmentalAffiliation WHERE Name='GomelRegionalExecutiveCommittee')
if not exists (SELECT*FROM dbo.DepartmentalAffiliation WHERE Name='MinistryOfIndustry')
if not exists (SELECT*FROM dbo.DepartmentalAffiliation WHERE Name='MinistryOfEnergy')
if not exists (SELECT*FROM dbo.DepartmentalAffiliation WHERE Name='MinistryOfHealth')
if not exists (SELECT*FROM dbo.DepartmentalAffiliation WHERE Name='MinistryOfEducation')
if not exists (SELECT*FROM dbo.DepartmentalAffiliation WHERE Name='Belneftekhim')
if not exists (SELECT*FROM dbo.DepartmentalAffiliation WHERE Name='Bellesbumprom')
if not exists (SELECT*FROM dbo.DepartmentalAffiliation WHERE Name='withoutDepartmentalSubordination')
begin
insert into dbo.DepartmentalAffiliation
values
('GomelRegionalExecutiveCommittee'), 
('MinistryOfIndustry'), 
('MinistryOfEnergy'), 
('MinistryOfHealth'),
('MinistryOfEducation'), 
('Belneftekhim'),
('Bellesbumprom'),
('withoutDepartmentalSubordination')
end
go

-- Subject
if not exists (SELECT*FROM dbo.Subject WHERE Name='Delta' and UNP=490124456 and departmentalAffiliationId=7
and postalAddress='Trudovaya str, 39A, Borschovka, Rechica region' and phone='8-029-457-78-98')
if not exists (SELECT*FROM dbo.Subject WHERE Name='Centralnoye' and UNP=490000011 and departmentalAffiliationId=1
and postalAddress='Telmana st, 26A, Gomel' and phone='8-0232-50-50-02')
begin
insert into dbo.Subject
values
('Delta', 490124456, 7, 'Trudovaya str, 39A, Borschovka, Rechica region', '8-029-457-78-98'),
('Centralnoye', 490000011, 1, 'Telmana st, 26A, Gomel', '8-0232-50-50-02')
end
go

-- TechnicalSpecification
if not exists (SELECT*FROM dbo.TechnicalSpecification WHERE 
Capacity=500 and 
ArrowDeparture=0 and 
Speed=1.0 and 
NumberOfStops=9 and
Name='FirstSpecification')
(SELECT*FROM dbo.TechnicalSpecification WHERE 
Capacity=25 and 
ArrowDeparture=18.5 and 
Speed=0 and 
NumberOfStops=0 and
Name='SecondSpecification')
begin
insert into dbo.TechnicalSpecification
values
(500, 0, 1.0, 9, 'FirstSpecification'),
(25, 18.5, 0, 0, 'SecondSpecification')
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

-- PDO
if not exists (SELECT*FROM dbo.PDO WHERE 
JournalPdoId=2 and 
RegistrationNumber=0001 and 
TypeId=10 and 
DateOfRegistration='15.12.2022' and 
YearOfManufacture=2022 and 
TechnicalSpecificationId=1 and 
ServiceLife=25 and 
InformationAboutTheTechnicalInspection='10.12.2022' and 
InspectorId=2 and 
TechnicalConditionalId=1 and 
SubjectId=2 and 
InstallationLocationId=1 and
Name='First')
if not exists (SELECT*FROM dbo.PDO WHERE 
JournalPdoId=1 and 
RegistrationNumber=0001 and 
TypeId=1 and 
DateOfRegistration='05.12.2022' and 
YearOfManufacture=2010 and 
TechnicalSpecificationId=2 and 
ServiceLife=10 and 
InformationAboutTheTechnicalInspection='20.10.2022' and 
InspectorId=1 and 
TechnicalConditionalId=1 and 
SubjectId=1 and 
InstallationLocationId=6 and
Name='Second')
begin
insert into dbo.PDO
values
(2, 0001, 10, '15.12.2022', 2022, 1, 25, '10.12.2022', 2, 1, 2, 1, 'First'),
(1, 0001, 1, '05.12.2022', 2010, 2, 10, '20.10.2022', 1, 1, 1, 6, 'Second') 
end
go

