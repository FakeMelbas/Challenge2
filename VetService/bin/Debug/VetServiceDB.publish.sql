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
IF EXISTS (SELECT 1
           FROM   [sys].[databases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [sys].[databases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
PRINT N'Creating [dbo].[Owner]...';


GO
CREATE TABLE [dbo].[Owner] (
    [OwnerID]   INT            NOT NULL,
    [Surname]   NVARCHAR (100) NOT NULL,
    [GivenName] NVARCHAR (100) NOT NULL,
    [Phone]     NVARCHAR (15)  NOT NULL,
    PRIMARY KEY CLUSTERED ([OwnerID] ASC)
);


GO
PRINT N'Creating [dbo].[Pet]...';


GO
CREATE TABLE [dbo].[Pet] (
    [PetID]   NVARCHAR (50)  NOT NULL,
    [Name]    NVARCHAR (100) NOT NULL,
    [Type]    NVARCHAR (30)  NOT NULL,
    [ownerID] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([PetID] ASC)
);


GO
PRINT N'Creating [dbo].[Procedure]...';


GO
CREATE TABLE [dbo].[Procedure] (
    [procedureID] INT            NOT NULL,
    [description] NVARCHAR (200) NOT NULL,
    [price]       MONEY          NOT NULL,
    PRIMARY KEY CLUSTERED ([procedureID] ASC)
);


GO
PRINT N'Creating [dbo].[Treatment]...';


GO
CREATE TABLE [dbo].[Treatment] (
    [treatmentID] NVARCHAR (50)  NOT NULL,
    [petName]     NVARCHAR (100) NOT NULL,
    [ownerID]     INT            NOT NULL,
    [procedureID] INT            NOT NULL,
    [date]        DATE           NOT NULL,
    [notes]       NVARCHAR (200) NOT NULL,
    [price]       MONEY          NOT NULL,
    PRIMARY KEY CLUSTERED ([treatmentID] ASC)
);


GO
PRINT N'Creating [dbo].[FK_PET_ownID]...';


GO
ALTER TABLE [dbo].[Pet] WITH NOCHECK
    ADD CONSTRAINT [FK_PET_ownID] FOREIGN KEY ([ownerID]) REFERENCES [dbo].[Owner] ([OwnerID]);


GO
PRINT N'Creating [dbo].[FK_TREATMENT_ProcID]...';


GO
ALTER TABLE [dbo].[Treatment] WITH NOCHECK
    ADD CONSTRAINT [FK_TREATMENT_ProcID] FOREIGN KEY ([procedureID]) REFERENCES [dbo].[Procedure] ([procedureID]);


GO
PRINT N'Creating [dbo].[OwnerVIEW]...';


GO
CREATE VIEW [dbo].[OwnerVIEW]
	AS SELECT [OwnerID], [Surname], [GivenName], [Phone] FROM [Owner];
GO
PRINT N'Creating [dbo].[PetVIEW]...';


GO
CREATE VIEW [dbo].[PetVIEW]
	AS SELECT [PetID], [Name], [Type], [ownerID] FROM [Pet]
GO
PRINT N'Creating [dbo].[ProcedureVIEW]...';


GO
CREATE VIEW [dbo].[ProcedureVIEW]
	AS SELECT [procedureID], [description], [price] FROM [Procedure]
GO
PRINT N'Creating [dbo].[TreatmentVIEW]...';


GO
CREATE VIEW [dbo].[TreatmentVIEW]
	AS SELECT [treatmentID], [petName], [ownerID], [procedureID], [date], [notes], [price] FROM [Treatment]
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

INSERT INTO Treatment(treatmentID, petName, ownerID, procedureID, date, notes, price) VALUES
('T1', 'Buster', 1, 01, '20/Jun/2017', 'Routine Vaccination', $22.00),
('T2', 'Buster', 1, 01, '15/May/2018', 'Booster Shot', $24.00),
('T3', 'Fluffy', 1, 10, '10/May/2018', 'Wounds sustained in apparent cat fight', $30.00),
('T4', 'Stew', 2, 10, '10/May/2018', 'Wounds sustained during attempt to cook the stew', $30.00),
('T5', 'Pooper', 3, 05, '18/May/2018', 'Routine Test', $25.00);

INSERT INTO Pet(PetID, [Name], [Type], ownerID) VALUES
('P1', 'Buster', 'Dog', 1),
('P2', 'Fluffy', 'Cat', 1),
('P3', 'Stew', 'Rabbit', 2),
('P4', 'Buster', 'Dog', 3),
('P5', 'Pooper', 'Dog', 3);

INSERT INTO [dbo].[Procedure](procedureID, [description], price) VALUES
(01, 'Rabies Vaccination', $24.00),
(10, 'Examine and Treat Wound', $30.00),
(05, 'Heart Worm Test', $25.00),
(08, 'Tetnus Vaccination', $17.00);

INSERT INTO [dbo].[Owner](OwnerID, Surname, GivenName, Phone) VALUES
(1, 'Sinatra', 'Frank', '0400 111 222'),
(2, 'Ellington', 'Duke', '0400 222 333'),
(3, 'Fitzgerald', 'Ella', '0400 333 444');



END;
GO

GO
