﻿ALTER TABLE dbo.PDO
ADD CONSTRAINT FK_Inspectors_PDO 
FOREIGN KEY (InspectorId)
	REFERENCES dbo.Inspectors (Id)