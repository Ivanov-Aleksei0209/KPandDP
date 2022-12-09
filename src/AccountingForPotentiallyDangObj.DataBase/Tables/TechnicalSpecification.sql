CREATE TABLE [dbo].[TechnicalSpecification]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Capacity] FLOAT NOT NULL, 
    [ArrowDeparture] FLOAT NULL, 
    [Speed] FLOAT NULL, 
    [NumberOfStops] INT NULL
)
