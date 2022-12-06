CREATE TABLE [dbo].[Subjects]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [UNP] INT NOT NULL, 
    [departmentalAffiliation] NVARCHAR(MAX) NOT NULL, 
    [postalAddress] NVARCHAR(MAX) NOT NULL, 
    [phone] NVARCHAR(50) NOT NULL
)
