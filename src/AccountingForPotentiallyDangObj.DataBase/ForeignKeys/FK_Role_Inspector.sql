ALTER TABLE dbo.Inspector
	ADD CONSTRAINT FK_Role_Inspector
	FOREIGN KEY ([RoleId])
	REFERENCES dbo.[Role] (Id)
