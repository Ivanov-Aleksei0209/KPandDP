CREATE TABLE [dbo].[TechnicalSpecification]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Capacity] FLOAT NULL, 
    [ArrowDeparture] FLOAT NULL, 
    [Speed] FLOAT NULL, 
    [NumberOfStops] INT NULL, 
    [Name] NVARCHAR(MAX) NULL
)
