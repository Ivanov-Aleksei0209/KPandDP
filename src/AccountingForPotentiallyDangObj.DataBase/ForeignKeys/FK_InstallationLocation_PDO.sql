ALTER TABLE dbo.Pdo
ADD CONSTRAINT FK_InstallationLocation_Pdo 
FOREIGN KEY (InstallationLocationId)
	REFERENCES dbo.InstallationLocation (Id)