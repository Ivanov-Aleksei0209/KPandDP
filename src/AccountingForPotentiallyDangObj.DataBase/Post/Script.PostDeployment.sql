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

-- PDO
if not exists (SELECT*FROM dbo.PDO WHERE Name='crane' and JournalPdoId=1 and RegistrationNumber=0001 and Type='' and DateOfRegistration='05.12.2022' and YearOfManufacture=2010 
and TechnicalSpecification='' and ServiceLife=10 and InformationAboutTheTechnicalInspection='20.10.2022' and InspectorId=1
and TechnicalConditional='' and Owner_Subject='Delta' and InstallationLocation='')
begin
insert into dbo.PDO
values
('crane', 1, 0001, '', '05.12.2022', 2010, '', 10, '20.10.2022', 1, '', 'Delta', '') 
end
go

-- TechnicalSpecification
if not exists (SELECT*FROM dbo.TechnicalSpecification WHERE Name='Capacity')
if not exists (SELECT*FROM dbo.TechnicalSpecification WHERE Name='ArrowDeparture')
if not exists (SELECT*FROM dbo.TechnicalSpecification WHERE Name='Speed')
if not exists (SELECT*FROM dbo.TechnicalSpecification WHERE Name='NumberOfStops')
begin
insert into dbo.TechnicalSpecification
values
('Capacity'), 
('ArrowDeparture'), 
('Speed'), 
('NumberOfStops') 
end
go

-- TypeOfLiftingCrane
if not exists (SELECT*FROM dbo.TypeOfLiftingCrane WHERE Name='automotive' and Abb='CA')
if not exists (SELECT*FROM dbo.TypeOfLiftingCrane WHERE Name='bridge' and Abb='CB')
if not exists (SELECT*FROM dbo.TypeOfLiftingCrane WHERE Name='gantry' and Abb='CG')
if not exists (SELECT*FROM dbo.TypeOfLiftingCrane WHERE Name='tower' and Abb='CT')
if not exists (SELECT*FROM dbo.TypeOfLiftingCrane WHERE Name='portal' and Abb='CP')
if not exists (SELECT*FROM dbo.TypeOfLiftingCrane WHERE Name='railway' and Abb='CR')
if not exists (SELECT*FROM dbo.TypeOfLiftingCrane WHERE Name='specialClass' and Abb='CSc')
if not exists (SELECT*FROM dbo.TypeOfLiftingCrane WHERE Name='pneumowheel' and Abb='CPw')
if not exists (SELECT*FROM dbo.TypeOfLiftingCrane WHERE Name='crawler' and Abb='CC')
begin
insert into dbo.TypeOfLiftingCrane
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

-- TypeOfLift
if not exists (SELECT*FROM dbo.TypeOfLift WHERE Name='passengerElectric' and Abb='LPe')
if not exists (SELECT*FROM dbo.TypeOfLift WHERE Name='cargoElectric' and Abb='LCe')
if not exists (SELECT*FROM dbo.TypeOfLift WHERE Name='hospitalElectric' and Abb='LHe')
begin
insert into dbo.TypeOfLift
values
('passengerElectric', 'LPe'), 
('cargoElectric', 'LCe'), 
('hospitalElectric', 'LHe') 
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