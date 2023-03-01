ALTER TABLE dbo.Pdo
ADD CONSTRAINT FK_Inspector_Pdo 
FOREIGN KEY (InspectorId)
	REFERENCES dbo.Inspector (Id)