CREATE TABLE [dbo].[Pdo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [JournalPdoId] INT NOT NULL,
    [RegistrationNumber] INT NOT NULL, 
    [TypeId] INT NOT NULL, 
    [DateOfRegistration] DATE NOT NULL, 
    [TechnicalSpecificationId] INT NULL, 
    [ServiceLife] INT NULL, 
    [InspectorId] INT NULL,
    [TechnicalConditionalId] INT NOT NULL,
    [SubjectId] INT NULL, 
    [InstallationLocationId] INT NULL, 
    [InstallationLocationAddress] NVARCHAR(MAX) NULL, 
    [YearOfManufacture] INT NULL,
    [YearOfCommissioning] INT NULL,
    [ModelName] NVARCHAR(50) NULL,
    [SerialNumber] NVARCHAR(50) NULL, 
    [Manufacturer] NVARCHAR(MAX) NULL, 
    [InformationAboutTheLastSurvey] DATE NULL, 
    [InformationAboutTheTechnicalInspection] DATE NULL,
    [InformationAboutTheTechnicalDiagnostic] DATE NULL,
    [WithdrawalFromRegistration] DATE NULL,
    [Note] NVARCHAR(MAX) NULL,    
    [Name] NCHAR(10) NULL
    
)
