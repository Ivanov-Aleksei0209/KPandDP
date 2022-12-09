CREATE TABLE [dbo].[PDO]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [JournalPdoId] INT NOT NULL,
    [RegistrationNumber] INT NOT NULL, 
    [TypeId] INT NOT NULL, 
    [DateOfRegistration] DATE NULL, 
    [YearOfManufacture] INT NULL, 
    [TechnicalSpecification] NVARCHAR(50) NOT NULL, 
    [ServiceLife] INT NULL, 
    [InformationAboutTheTechnicalInspection] DATETIME NULL, 
    [InspectorId] INT NOT NULL,
    [TechnicalConditional] NVARCHAR(50) NULL,
    [Owner_Subject] NVARCHAR(50) NULL, 
    [InstallationLocation] NVARCHAR(50) NULL
)
