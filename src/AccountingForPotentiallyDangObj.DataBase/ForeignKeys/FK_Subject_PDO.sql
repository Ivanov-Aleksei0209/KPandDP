﻿ALTER TABLE dbo.Pdo
ADD CONSTRAINT FK_Subject_Pdo 
FOREIGN KEY (SubjectId)
	REFERENCES dbo.Subject (Id)