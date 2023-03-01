ALTER TABLE dbo.Pdo
ADD CONSTRAINT FK_TechnicalSpecification_Pdo 
FOREIGN KEY (TechnicalSpecificationId)
	REFERENCES dbo.TechnicalSpecification (Id)