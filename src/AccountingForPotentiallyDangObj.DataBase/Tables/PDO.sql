CREATE TABLE [dbo].[PDO]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NULL, 
    [journalPDO] NVARCHAR(50) NULL,
    [registrationNumber] INT NOT NULL, 
    [type] NCHAR(10) NULL, 
    [dateOfRegistration] DATE NULL, 
    [yearOfManufacture] INT NULL, 
    [technicalSpecifications] NVARCHAR(50) NULL, 
    [serviceLife] INT NULL, 
    [informationAboutTheTechnicalInspection] DATETIME NULL, 
    [inspector] NVARCHAR(50) NULL,
    [technicalConditional] NVARCHAR(50) NULL,
    [owner_Subject] NVARCHAR(50) NULL, 
    [installationLocation] NVARCHAR(50) NULL
)
