CREATE VIEW [dbo].[TreatmentVIEW]
	AS SELECT [treatmentID],[PetID] [petName], [ownerID], [procedureID], [date], [notes], [price] FROM [Treatment]
