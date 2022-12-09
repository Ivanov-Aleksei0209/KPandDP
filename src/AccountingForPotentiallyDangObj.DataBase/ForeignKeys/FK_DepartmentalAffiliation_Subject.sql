ALTER TABLE dbo.Subject
ADD CONSTRAINT FK_DepartmentalAffiliation_Subject 
FOREIGN KEY (departmentalAffiliationId)
	REFERENCES dbo.DepartmentalAffiliation (Id)