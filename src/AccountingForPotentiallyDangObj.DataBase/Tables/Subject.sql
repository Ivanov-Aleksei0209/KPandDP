CREATE TABLE [dbo].[Subject]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [UNP] INT NULL, 
    [departmentalAffiliationId] INT NULL, 
    [postalAddress] NVARCHAR(MAX) NULL, 
    [phone] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_DepartmentalAffiliation_Subject] FOREIGN KEY ([departmentalAffiliationId]) REFERENCES [DepartmentalAffiliation]([Id])
)
