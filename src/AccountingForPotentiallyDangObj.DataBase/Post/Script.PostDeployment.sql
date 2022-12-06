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

-- PDO
if not exists (SELECT*FROM dbo.PDO WHERE Name='crane' and JournalPdoId=1 and RegistrationNumber=0001 and Type='' and DateOfRegistration='05.12.2022' and YearOfManufacture=2010 
and TechnicalSpecifications='' and ServiceLife=10 and InformationAboutTheTechnicalInspection='20.10.2022' and Inspector='Ivanov A.'
and TechnicalConditional='' and Owner_Subject='Delta' and InstallationLocation='')
begin
insert into dbo.PDO
values
('crane', 1, 0001, '', '05.12.2022', 2010, '', 10, '20.10.2022', 'Ivanov A.', '', 'Delta', '') 
end
go

-- TechnicalSpecifications
if not exists (SELECT*FROM dbo.TechnicalSpecifications WHERE Name='Capacity')
if not exists (SELECT*FROM dbo.TechnicalSpecifications WHERE Name='ArrowDeparture')
if not exists (SELECT*FROM dbo.TechnicalSpecifications WHERE Name='Speed')
if not exists (SELECT*FROM dbo.TechnicalSpecifications WHERE Name='NumberOfStops')
begin
insert into dbo.TechnicalSpecifications
values
('Capacity'), 
('ArrowDeparture'), 
('Speed'), 
('NumberOfStops') 
end
go

-- TypesOfLiftingCranes
if not exists (SELECT*FROM dbo.TypesOfLiftingCranes WHERE Name='automotive' and Abb='CA')
if not exists (SELECT*FROM dbo.TypesOfLiftingCranes WHERE Name='bridge' and Abb='CB')
if not exists (SELECT*FROM dbo.TypesOfLiftingCranes WHERE Name='gantry' and Abb='CG')
if not exists (SELECT*FROM dbo.TypesOfLiftingCranes WHERE Name='tower' and Abb='CT')
if not exists (SELECT*FROM dbo.TypesOfLiftingCranes WHERE Name='portal' and Abb='CP')
if not exists (SELECT*FROM dbo.TypesOfLiftingCranes WHERE Name='railway' and Abb='CR')
if not exists (SELECT*FROM dbo.TypesOfLiftingCranes WHERE Name='specialClass' and Abb='CSc')
if not exists (SELECT*FROM dbo.TypesOfLiftingCranes WHERE Name='pneumowheel' and Abb='CPw')
if not exists (SELECT*FROM dbo.TypesOfLiftingCranes WHERE Name='crawler' and Abb='CC')
begin
insert into dbo.TypesOfLiftingCranes
values
('automotive', 'CA'), 
('bridge', 'CB'), 
('gantry', 'CG'), 
('tower', 'CT'),
('portal', 'CP'), 
('railway', 'CR'), 
('specialClass', 'CSc'), 
('pneumowheel', 'CPw'),
('crawler', 'CC')
end
go

-- TypesOfLifts
if not exists (SELECT*FROM dbo.TypesOfLifts WHERE Name='passengerElectric' and Abb='LPe')
if not exists (SELECT*FROM dbo.TypesOfLifts WHERE Name='cargoElectric' and Abb='LCe')
if not exists (SELECT*FROM dbo.TypesOfLifts WHERE Name='hospitalElectric' and Abb='LHe')
begin
insert into dbo.TypesOfLifts
values
('passengerElectric', 'LPe'), 
('cargoElectric', 'LCe'), 
('hospitalElectric', 'LHe') 
end
go

-- Inspectors
if not exists (SELECT*FROM dbo.Inspectors WHERE Name='Ivanov A.')
if not exists (SELECT*FROM dbo.Inspectors WHERE Name='Koncevoi S.')
if not exists (SELECT*FROM dbo.Inspectors WHERE Name='Poltorak A.')
if not exists (SELECT*FROM dbo.Inspectors WHERE Name='Smolovik G.')
begin
insert into dbo.Inspectors
values
('Ivanov A.'), 
('Koncevoi S.'), 
('Poltorak A.'), 
('Smolovik G.') 
end
go

-- Subjects
if not exists (SELECT*FROM dbo.Subjects WHERE Name='Delta' and UNP=490124456 and departmentalAffiliation='withoutDepartmentalAffiliation'
and postalAddress='Trudovaya str, 39A, Borschovka, Rechica region' and phone='8-029-457-78-98')
begin
insert into dbo.Subjects
values
('Delta', 490124456, 'withoutDepartmentalAffiliation', 'Trudovaya str, 39A, Borschovka, Rechica region', '8-029-457-78-98')
end
go

-- JournalPdoToTs
if not exists (SELECT*FROM dbo.JournalPdoToTs WHERE JournalNumber=31 and KeyTS=1)
if not exists (SELECT*FROM dbo.JournalPdoToTs WHERE JournalNumber=31 and KeyTS=2)
if not exists (SELECT*FROM dbo.JournalPdoToTs WHERE JournalNumber=32 and KeyTS=1)
if not exists (SELECT*FROM dbo.JournalPdoToTs WHERE JournalNumber=32 and KeyTS=3)
if not exists (SELECT*FROM dbo.JournalPdoToTs WHERE JournalNumber=32 and KeyTS=4)
begin
insert into dbo.JournalPdoToTs
values
(31, 1), 
(31, 2), 
(32, 1),
(32, 3), 
(32, 4) 
end
go