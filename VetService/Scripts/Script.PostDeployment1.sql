/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF '$(LoadTestData)' = 'true'

BEGIN
DELETE FROM [Treatment];
DELETE FROM [Pet];
DELETE FROM [Procedure];
DELETE FROM [Owner];


INSERT INTO [dbo].[Procedure](procedureID, [description], price) VALUES
(01, 'Rabies Vaccination', $24.00),
(10, 'Examine and Treat Wound', $30.00),
(05, 'Heart Worm Test', $25.00),
(08, 'Tetnus Vaccination', $17.00);

INSERT INTO [dbo].[Owner](OwnerID, Surname, GivenName, Phone) VALUES
(1, 'Sinatra', 'Frank', '0400 111 222'),
(2, 'Ellington', 'Duke', '0400 222 333'),
(3, 'Fitzgerald', 'Ella', '0400 333 444');

INSERT INTO Pet(PetID, [Name], [Type], ownerID) VALUES
('P1', 'Buster', 'Dog', 1),
('P2', 'Fluffy', 'Cat', 1),
('P3', 'Stew', 'Rabbit', 2),
('P4', 'Buster', 'Dog', 3),
('P5', 'Pooper', 'Dog', 3);

INSERT INTO Treatment(treatmentID, petName, ownerID, procedureID, date, notes, price) VALUES
('T1', 'Buster', 1, 01, '20/Jun/17', 'Routine Vaccination', $22.00),
('T2', 'Buster', 1, 01, '15/May/18', 'Booster Shot', $24.00),
('T3', 'Fluffy', 1, 10, '10/May/18', 'Wounds sustained in apparent cat fight', $30.00),
('T4', 'Stew', 2, 10, '10/May/18', 'Wounds sustained during attempt to cook the stew', $30.00),
('T5', 'Pooper', 3, 05, '18/May/18', 'Routine Test', $25.00);


END;