ALTER TABLE dbo.PDO
ADD CONSTRAINT FK_TechnicalConditional_PDO 
FOREIGN KEY (TechnicalConditionalId)
	REFERENCES dbo.TechnicalConditional (Id)