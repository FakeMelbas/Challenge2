﻿CREATE TABLE [dbo].[Pet]
(
	[PetID] NVARCHAR(50) NOT NULL PRIMARY KEY,
	[Name] NVARCHAR(100) NOT NULL,
	[Type] NVARCHAR(30) NOT NULL,
	[ownerID] INT NOT NULL,
	CONSTRAINT FK_PET_ownID FOREIGN KEY (ownerID) REFERENCES Owner(OwnerID)
)