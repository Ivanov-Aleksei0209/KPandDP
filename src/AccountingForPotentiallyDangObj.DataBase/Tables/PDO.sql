CREATE TABLE [dbo].[PDO]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [JournalPdoId] INT NOT NULL,
    [RegistrationNumber] INT NOT NULL, 
    [TypeId] INT NOT NULL, 
    [DateOfRegistration] DATE NOT NULL, 
    [YearOfManufacture] INT NOT NULL, 
    [TechnicalSpecificationId] INT NOT NULL, 
    [ServiceLife] INT NOT NULL, 
    [InformationAboutTheTechnicalInspection] DATE NULL, 
    [InspectorId] INT NULL,
    [TechnicalConditionalId] INT NOT NULL,
    [SubjectId] INT NOT NULL, 
    [InstallationLocationId] INT NOT NULL
)
