ALTER TABLE dbo.PDO
ADD CONSTRAINT FK_InstallationLocation_PDO 
FOREIGN KEY (InstallationLocationId)
	REFERENCES dbo.InstallationLocation (Id)