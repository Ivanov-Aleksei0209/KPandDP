CREATE TABLE [dbo].[Pdo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [JournalPdoId] INT NOT NULL,
    [RegistrationNumber] INT NOT NULL, 
    [TypeId] INT NOT NULL, 
    [DateOfRegistration] DATE NOT NULL, 
    [YearOfManufacture] INT NULL, 
    [TechnicalSpecificationId] INT NULL, 
    [ServiceLife] INT NULL, 
    [InformationAboutTheTechnicalInspection] DATE NULL, 
    [InspectorId] INT NULL,
    [TechnicalConditionalId] INT NOT NULL,
    [SubjectId] INT NULL, 
    [InstallationLocationId] INT NULL, 
    [WithdrawalFromRegistration] DATE NULL, 
    [InstallationLocationAddress] NVARCHAR(MAX) NULL, 
    [Name] NCHAR(10) NULL
)
