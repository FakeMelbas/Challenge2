CREATE TABLE [dbo].[Treatment]
(
	[treatmentID] NVARCHAR(50) NOT NULL PRIMARY KEY,
	[petName] NVARCHAR(100) NOT NULL,
	[ownerID] INT NOT NULL,
	[procedureID] INT NOT NULL,
	[date] DATE NOT NULL,
	[notes] NVARCHAR(200) NOT NULL,
	[price] MONEY NOT NULL,
	CONSTRAINT FK_TREATMENT_ProcID FOREIGN KEY (procedureID) REFERENCES [dbo].[Procedure](procedureID)
)
