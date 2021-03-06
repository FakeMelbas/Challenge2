﻿/*
Deployment script for Challenge2

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar LoadTestData "true"
:setvar DatabaseName "Challenge2"
:setvar DefaultFilePrefix "Challenge2"
:setvar DefaultDataPath ""
:setvar DefaultLogPath ""

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
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
GO

GO
PRINT N'Update complete.';


GO
