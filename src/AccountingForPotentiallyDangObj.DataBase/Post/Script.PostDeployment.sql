-- JournalPdo
if not exists (SELECT*FROM dbo.JournalPdo WHERE Name='LiftingCranes' and JournalNumber=31)
if not exists (SELECT*FROM dbo.JournalPdo WHERE Name='Lifts' and JournalNumber=32)
if not exists (SELECT*FROM dbo.JournalPdo WHERE Name='Escalators' and JournalNumber=33)
if not exists (SELECT*FROM dbo.JournalPdo WHERE Name='Elevators' and JournalNumber=34)
if not exists (SELECT*FROM dbo.JournalPdo WHERE Name='Attractions' and JournalNumber=36)
begin
insert into dbo.JournalPdo
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
if not exists (SELECT*FROM dbo.Subject WHERE Name='OAO Delta' and UNP=490124456 and departmentalAffiliationId=8
and postalAddress='Trudovaya str, 39A, Borschovka, Rechica region' and phone='8-029-457-78-98')
if not exists (SELECT*FROM dbo.Subject WHERE Name='GP "Centralnoye"' and UNP=490000011 and departmentalAffiliationId=1
and postalAddress='Telmana st, 26A, Gomel' and phone='8-0232-50-50-02')
if not exists (SELECT*FROM dbo.Subject WHERE Name='OAO Gomselmash' and UNP=490002415 and departmentalAffiliationId=2
and postalAddress='Trudovaya st, 13, Gomel' and phone='8-0232-54-65-02')
if not exists (SELECT*FROM dbo.Subject WHERE Name='OAO Gomeldrev' and UNP=490006578 and departmentalAffiliationId=7
and postalAddress='Telmana st, 26A, Gomel' and phone='8-0232-34-50-32')
if not exists (SELECT*FROM dbo.Subject WHERE Name='GGTU im.P.O.Sukhoi' and UNP=490003657 and departmentalAffiliationId=5
and postalAddress='Oktabra pr-t, 44, Gomel' and phone='8-0232-23-78-69')
if not exists (SELECT*FROM dbo.Subject WHERE Name='StankoGomel' and UNP=490065897 and departmentalAffiliationId=2
and postalAddress='Internacionalnaya st, 8, Gomel' and phone='8-0232-65-87-21')
if not exists (SELECT*FROM dbo.Subject WHERE Name='Gomel OKB' and UNP=490087965 and departmentalAffiliationId=4
and postalAddress='Lizukovyh Brothers st, 32, Gomel' and phone='8-0232-65-87-21')
begin
insert into dbo.Subject
values
('OAO Delta', 490124456, 8, 'Trudovaya str, 39A, Borschovka, Rechica region', '8-029-457-78-98'),
('GP "Centralnoye"', 490000011, 1, 'Telmana st, 26A, Gomel', '8-0232-50-50-02'),
('OAO Gomselmash', 490002415, 2, 'Trudovaya st, 13, Gomel', '8-0232-54-65-02'),
('OAO Gomeldrev', 490006578, 7, 'Sevastopolskaya st, 15, Gomel', '8-0232-34-50-32'),
('GGTU im.P.O.Sukhoi', 490003657, 5, 'Oktabra pr-t, 44, Gomel', '8-0232-23-78-69'),
('OAO StankoGomel', 490065897, 2, 'Internacionalnaya st, 8, Gomel', '8-0232-65-87-21'),
('Gomel OKB', 490087965, 4, 'Lizukovyh Brothers st, 32, Gomel', '8-0232-65-87-21')
end
go

-- TechnicalSpecification
if not exists (SELECT*FROM dbo.TechnicalSpecification WHERE 
Capacity=500 and 
ArrowDeparture=0 and 
Speed=1.0 and 
NumberOfStops=9 and
Name='FirstSpecification')
if not exists (SELECT*FROM dbo.TechnicalSpecification WHERE 
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
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name=N'эксплуатируется')
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name='не эксплуатируется')
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name='запрещен')
if not exists (SELECT*FROM dbo.TechnicalConditional WHERE Name='в ремонте')
begin
insert into dbo.TechnicalConditional
values
(N'эксплуатируется'), 
('не эксплуатируется'), 
('запрещен'), 
('в ремонте') 
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
InspectorId=1 and 
TechnicalConditionalId=1 and 
SubjectId=3 and 
InstallationLocationId=6 and
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
InspectorId=1 and 
TechnicalConditionalId=1 and 
SubjectId=3 and 
InstallationLocationId=6 and
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
InspectorId=1 and 
TechnicalConditionalId=1 and 
SubjectId=4 and 
InstallationLocationId=6 and
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
TechnicalConditionalId=1 and 
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
InspectorId=1 and 
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
InstallationLocationId=6 and
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
InspectorId=1 and 
TechnicalConditionalId=1 and 
SubjectId=5 and 
InstallationLocationId=6 and
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
InspectorId=1 and 
TechnicalConditionalId=1 and 
SubjectId=7 and 
InstallationLocationId=6 and
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
InstallationLocationId=6 and
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
InspectorId=1 and 
TechnicalConditionalId=1 and 
SubjectId=1 and 
InstallationLocationId=6 and
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
InspectorId=1 and 
TechnicalConditionalId=1 and 
SubjectId=2 and 
InstallationLocationId=6 and
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
InstallationLocationId=6 and
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
InspectorId=1 and 
TechnicalConditionalId=1 and 
SubjectId=7 and 
InstallationLocationId=6 and
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
InspectorId=1 and 
TechnicalConditionalId=1 and 
SubjectId=7 and 
InstallationLocationId=6 and
WithdrawalFromRegistration=null and
Name='17')
begin
insert into dbo.Pdo
values
(2, 0001, 10, N'2022-12-15', 2022, 1, 25, N'2022-12-10', 2, 1, 2, 1, null, '01'),
(1, 0001, 1, N'2022-12-05', 2010, 2, 10, N'2022-10-20', 1, 1, 1, 6, null, '02'),
(1, 0002, 2, N'2020-02-13', 2000, 2, 10, N'2021-10-20', 1, 1, 3, 6, null, '03'),
(1, 0003, 2, N'2022-12-05', 2020, 2, 10, N'2022-10-20', 1, 1, 3, 6, null, '04'),
(1, 0004, 2, N'2022-12-05', 2010, 2, 10, N'2022-10-20', 1, 1, 4, 6, null, '05'),
(1, 0005, 1, N'2022-12-05', 2000, 2, 10, N'2022-10-20', 1, 1, 3, 6, null, '06'),
(1, 0006, 1, N'2022-12-05', 2020, 2, 10, N'2022-10-20', 1, 1, 6, 6, null, '07'),
(1, 0007, 3, N'2022-12-05', 2000, 2, 20, N'2022-10-20', 1, 1, 4, 6, null, '08'),
(2, 0002, 10, N'2022-12-05', 2010, 2, 25, N'2022-10-20', 1, 1, 5, 6, null, '09'),
(2, 0003, 12, N'2022-12-05', 1997, 2, 25, N'2022-10-20', 1, 1, 7, 6, null, '10'),
(2, 0004, 10, N'2022-12-05', 1995, 2, 25, N'2022-10-20', 1, 1, 2, 6, null, '11'),
(1, 0008, 1, N'2022-12-05', 1995, 2, 10, N'2022-10-20', 1, 1, 1, 6, N'2022-10-20', '12'),
(1, 0009, 1, N'2022-12-05', 1995, 2, 10, N'2022-10-20', 1, 1, 1, 6, null, '13'),
(2, 0005, 10, N'2022-12-05', 1995, 2, 25, N'2022-10-20', 1, 1, 2, 6, N'2023-10-20', '14'),
(2, 0006, 10, N'2022-12-05', 2023, 2, 25, N'2022-10-20', 1, 1, 2, 6, null, '15'),
(2, 0007, 12, N'2022-12-05', 2020, 2, 25, N'2022-10-20', 1, 1, 7, 6, null, '16'),
(2, 0008, 12, N'2022-12-05', 1995, 2, 25, N'2022-10-20', 1, 1, 7, 6, null, '17')
end
go

