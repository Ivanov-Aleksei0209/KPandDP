CREATE TABLE [dbo].[Subject]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [UNP] INT NOT NULL, 
    [departmentalAffiliationId] INT NOT NULL, 
    [postalAddress] NVARCHAR(MAX) NOT NULL, 
    [phone] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_DepartmentalAffiliation_Subject] FOREIGN KEY ([departmentalAffiliationId]) REFERENCES [DepartmentalAffiliation]([Id])
)
