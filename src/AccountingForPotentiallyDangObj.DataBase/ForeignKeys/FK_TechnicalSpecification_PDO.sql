ALTER TABLE dbo.PDO
ADD CONSTRAINT FK_TechnicalSpecification_PDO 
FOREIGN KEY (TechnicalSpecificationId)
	REFERENCES dbo.TechnicalSpecification (Id)