ALTER TABLE dbo.Pdo
ADD CONSTRAINT FK_TechnicalConditional_Pdo 
FOREIGN KEY (TechnicalConditionalId)
	REFERENCES dbo.TechnicalConditional (Id)