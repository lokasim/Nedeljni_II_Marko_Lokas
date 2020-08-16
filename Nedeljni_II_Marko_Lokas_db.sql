IF DB_ID('MedicalInstitutionNedeljni') IS NULL
CREATE DATABASE MedicalInstitutionNedeljni
GO

USE MedicalInstitutionNedeljni

ALTER DATABASE MedicalInstitutionNedeljni COLLATE Croatian_CI_AS;
GO

-- Drop Foreign Keys
IF OBJECT_ID('tblAdministrator', 'U') IS NOT NULL 
	ALTER TABLE tblAdministrator DROP CONSTRAINT FK_Admin_Gender;

IF OBJECT_ID('tblPatient', 'U') IS NOT NULL 
	ALTER TABLE tblPatient DROP CONSTRAINT FK_Patient_UniqueNumberDoctor;

IF OBJECT_ID('tblDailyMaintenance', 'U') IS NOT NULL 
	ALTER TABLE tblDailyMaintenance DROP CONSTRAINT FK_DailyMaintenance_Mainternace;

IF OBJECT_ID('tblDoctor', 'U') IS NOT NULL 
	ALTER TABLE tblDoctor DROP CONSTRAINT FK_Doctor_Gender;

IF OBJECT_ID('tblDoctor', 'U') IS NOT NULL 
	ALTER TABLE tblDoctor DROP CONSTRAINT FK_Doctor_Manager;

IF OBJECT_ID('tblManager', 'U') IS NOT NULL 
	ALTER TABLE tblManager DROP CONSTRAINT FK_Manager_Gender;

IF OBJECT_ID('tblDoctor', 'U') IS NOT NULL 
	ALTER TABLE tblDoctor DROP CONSTRAINT FK_Doctor_ShiftWorks;

IF OBJECT_ID('tblMainternace', 'U') IS NOT NULL 
	ALTER TABLE tblMainternace DROP CONSTRAINT FK_Mainternace_Gender;

IF OBJECT_ID('tblPatient', 'U') IS NOT NULL 
	ALTER TABLE tblPatient DROP CONSTRAINT FK_Patient_Gender;
	
--===================================================================

-- Drop Primary Keys 
IF OBJECT_ID('tblInstitution', 'U') IS NOT NULL 
	ALTER TABLE tblInstitution DROP CONSTRAINT PK_Institution;

IF OBJECT_ID('tblGender', 'U') IS NOT NULL 
	ALTER TABLE tblGender DROP CONSTRAINT PK_Gender;

IF OBJECT_ID('tblAdministrator', 'U') IS NOT NULL 
	ALTER TABLE tblAdministrator DROP CONSTRAINT PK_Administrator;

IF OBJECT_ID('tblMainternace', 'U') IS NOT NULL 
	ALTER TABLE tblMainternace DROP CONSTRAINT PK_Mainternace;

IF OBJECT_ID('tblManager', 'U') IS NOT NULL 
	ALTER TABLE tblManager DROP CONSTRAINT PK_Manager;

IF OBJECT_ID('tblShiftWorks', 'U') IS NOT NULL 
	ALTER TABLE tblShiftWorks DROP CONSTRAINT PK_ShiftWorks;

IF OBJECT_ID('tblDoctor', 'U') IS NOT NULL 
	ALTER TABLE tblDoctor DROP CONSTRAINT PK_Doctor;

IF OBJECT_ID('tblPatient', 'U') IS NOT NULL 
	ALTER TABLE tblPatient DROP CONSTRAINT PK_Patient;

IF OBJECT_ID('tblDailyMaintenance', 'U') IS NOT NULL 
	ALTER TABLE tblDailyMaintenance DROP CONSTRAINT PK_DailyMaintenance;
--===================================================================

-- Drop tables
IF OBJECT_ID('tblInstitution', 'U') IS NOT NULL 
	DROP TABLE tblInstitution;

IF OBJECT_ID('tblGender', 'U') IS NOT NULL 
	DROP TABLE tblGender;

IF OBJECT_ID('tblAdministrator', 'U') IS NOT NULL 
	DROP TABLE tblAdministrator;

IF OBJECT_ID('tblPatient', 'U') IS NOT NULL 
	DROP TABLE tblPatient;

IF OBJECT_ID('tblMainternace', 'U') IS NOT NULL 
	DROP TABLE tblMainternace;

IF OBJECT_ID('tblManager', 'U') IS NOT NULL 
	DROP TABLE tblManager;

IF OBJECT_ID('tblShiftWorks', 'U') IS NOT NULL 
	DROP TABLE tblShiftWorks;

IF OBJECT_ID('tblDoctor', 'U') IS NOT NULL 
	DROP TABLE tblDoctor;

IF OBJECT_ID('tblDailyMaintenance', 'U') IS NOT NULL 
	DROP TABLE tblDailyMaintenance;
--===================================================================

-- Drop View

IF OBJECT_ID('vwAdmin', 'V') IS NOT NULL 
	DROP VIEW vwAdmin;
IF OBJECT_ID('vwMainternace', 'V') IS NOT NULL 
	DROP VIEW vwMainternace;
IF OBJECT_ID('vwManager', 'V') IS NOT NULL 
	DROP VIEW vwManager;
IF OBJECT_ID('vwDoctor', 'V') IS NOT NULL 
	DROP VIEW vwDoctor;
IF OBJECT_ID('vwPatient', 'V') IS NOT NULL 
	DROP VIEW vwPatient;
IF OBJECT_ID('vwDailyMaintenance', 'V') IS NOT NULL 
	DROP VIEW vwDailyMaintenance;
--===================================================================

-- Create tables
CREATE TABLE tblInstitution(
	InstitutionID					int identity(1,1) NOT NULL,
	InstitutionName					nvarchar(70) NOT NULL,
	InstitutionOwner				nvarchar(50) NOT NULL,
	InstitutionAddress				nvarchar(100) NOT NULL,
	NumberOfFloors					int NOT NULL,
	NumberOfRoomsPerFloor			int NOT NULL,
	Terrace							int NOT NULL,
	Yard							int NOT NULL,
	NumberAPAmbulances				int NOT NULL,
	NumberAPDisabled				int
	)

CREATE TABLE tblGender(
	GenderID					int identity(1,1) NOT NULL,
	GenderSign					nvarchar(1) NOT NULL,
	Gender						nvarchar(30) NOT NULL
)

CREATE TABLE tblAdministrator(
	AdministratorID					int identity(1,1) NOT NULL,
	NameSurname						nvarchar(100) NOT NULL,
	BLK								char(9) NOT NULL,
	Gender							int NOT NULL,
	DateOfBirth						date NOT NULL,
	Citizenship						nvarchar(70) NOT NULL,
	UsernameLogin					nvarchar(50) NOT NULL,
	PasswordLogin					nvarchar(50) NOT NULL
	)

CREATE TABLE tblMainternace(
	MainternaceID					int identity(1,1) NOT NULL,
	NameSurname						nvarchar(100) NOT NULL,
	BLK								char(9) NOT NULL,
	Gender							int NOT NULL,
	DateOfBirth						date NOT NULL,
	Citizenship						nvarchar(70) NOT NULL,
	UsernameLogin					nvarchar(50) NOT NULL,
	PasswordLogin					nvarchar(50) NOT NULL,
	ExpandClinic					int NOT NULL,
	AccessibilityDisabled			int NOT NULL
	)

CREATE TABLE tblManager(
	ManagerID						int identity(1,1) NOT NULL,
	NameSurname						nvarchar(100) NOT NULL,
	BLK								char(9) NOT NULL,
	Gender							int NOT NULL,
	DateOfBirth						date NOT NULL,
	Citizenship						nvarchar(70) NOT NULL,
	UsernameLogin					nvarchar(50) NOT NULL,
	PasswordLogin					nvarchar(50) NOT NULL,
	FloorInstitution				int NOT NULL,
	MaxNumSupervising				int NOT NULL,
	MinNumRoomSupervised			int NOT NULL,
	NumOmissions					int NOT NULL
	)

CREATE TABLE tblShiftWorks(
	ShiftWorksID					int identity(1,1) NOT NULL,
	ShiftWorks						nvarchar(50) NOT NULL
)

CREATE TABLE tblDoctor(
	DoctorID						int identity(1,1) NOT NULL,
	NameSurname						nvarchar(100) NOT NULL,
	BLK								char(9) NOT NULL,
	Gender							int NOT NULL,
	DateOfBirth						date NOT NULL,
	Citizenship						nvarchar(70) NOT NULL,
	UsernameLogin					nvarchar(50) NOT NULL,
	PasswordLogin					nvarchar(50) NOT NULL,
	UniqueNumber					int NOT NULL,
	AccountNumber					nvarchar(20) NOT NULL,
	Department						nvarchar(100) NOT NULL,
	ShiftInWhichHeWorks				int NOT NULL,
	ResponsiblePatientAdmission		int NOT NULL,
	SuperiorManager					int
	)

CREATE TABLE tblPatient(
	PatientID						int identity(1,1) NOT NULL,
	NameSurname						nvarchar(100) NOT NULL,
	BLK								char(9) NOT NULL,
	Gender							int NOT NULL,
	DateOfBirth						date NOT NULL,
	Citizenship						nvarchar(70) NOT NULL,
	UsernameLogin					nvarchar(50) NOT NULL,
	PasswordLogin					nvarchar(50) NOT NULL,
	HealthInsuranceCardNumber		nvarchar(12) NOT NULL,
	ExpirationDateHealthInsurance	date NOT NULL,
	UniqueNumberDoctor				int
	)

CREATE TABLE tblDailyMaintenance(
	DailyMaintenanceID			int identity(1,1) NOT NULL,
	DateMaintenance				date NOT NULL,
	WorkingTime					int NOT NULL,
	DescriptionMaintenance		nvarchar(250) NOT NULL,
	Maintenance					int NOT NULL
	)


--===================================================================

-- Add contraints for PK
ALTER TABLE tblInstitution
	ADD CONSTRAINT PK_Institution
	PRIMARY KEY (InstitutionID)

ALTER TABLE tblGender
	ADD CONSTRAINT PK_Gender
	PRIMARY KEY (GenderID)

ALTER TABLE tblAdministrator
	ADD CONSTRAINT PK_Administrator
	PRIMARY KEY (AdministratorID)

ALTER TABLE tblMainternace
	ADD CONSTRAINT PK_Mainternace
	PRIMARY KEY (MainternaceID)

ALTER TABLE tblManager
	ADD CONSTRAINT PK_Manager
	PRIMARY KEY (ManagerID)

ALTER TABLE tblShiftWorks
	ADD CONSTRAINT PK_ShiftWorks
	PRIMARY KEY (ShiftWorksID)

ALTER TABLE tblDoctor
	ADD CONSTRAINT PK_Doctor
	PRIMARY KEY (DoctorID)

ALTER TABLE tblPatient
	ADD CONSTRAINT PK_Patient
	PRIMARY KEY (PatientID)

ALTER TABLE tblDailyMaintenance
	ADD CONSTRAINT PK_DailyMaintenance
	PRIMARY KEY (DailyMaintenanceID)
--===================================================================

-- Add contraints for FK
ALTER TABLE tblAdministrator 
	ADD CONSTRAINT FK_Admin_Gender
	FOREIGN KEY (Gender) 
	REFERENCES tblGender (GenderID)

ALTER TABLE tblPatient 
	ADD CONSTRAINT FK_Patient_UniqueNumberDoctor
	FOREIGN KEY (UniqueNumberDoctor) 
	REFERENCES tblDoctor (DoctorID)

ALTER TABLE tblDailyMaintenance 
	ADD CONSTRAINT FK_DailyMaintenance_Mainternace
	FOREIGN KEY (Maintenance) 
	REFERENCES tblMainternace (MainternaceID)

ALTER TABLE tblDoctor 
	ADD CONSTRAINT FK_Doctor_Gender
	FOREIGN KEY (Gender) 
	REFERENCES tblGender (GenderID)

ALTER TABLE tblDoctor 
	ADD CONSTRAINT FK_Doctor_Manager
	FOREIGN KEY (SuperiorManager) 
	REFERENCES tblManager (ManagerID)

ALTER TABLE tblManager 
	ADD CONSTRAINT FK_Manager_Gender
	FOREIGN KEY (Gender) 
	REFERENCES tblGender (GenderID)

ALTER TABLE tblPatient 
	ADD CONSTRAINT FK_Patient_Gender
	FOREIGN KEY (Gender) 
	REFERENCES tblGender (GenderID)

ALTER TABLE tblDoctor 
	ADD CONSTRAINT FK_Doctor_ShiftWorks
	FOREIGN KEY (ShiftInWhichHeWorks) 
	REFERENCES tblShiftWorks (ShiftWorksID)

ALTER TABLE tblMainternace 
	ADD CONSTRAINT FK_Mainternace_Gender
	FOREIGN KEY (Gender) 
	REFERENCES tblGender (GenderID)
--===================================================================

INSERT INTO tblGender (GenderSign, Gender)
VALUES('M','Muško')
INSERT INTO tblGender (GenderSign, Gender)
VALUES('Ž','Žensko')
INSERT INTO tblGender (GenderSign, Gender)
VALUES('N','Nešto drugo')
INSERT INTO tblGender (GenderSign, Gender)
VALUES('X','Ne želim da se izjasnim')

INSERT INTO tblShiftWorks (ShiftWorks)
VALUES('Prepordnevna')
INSERT INTO tblShiftWorks (ShiftWorks)
VALUES('Popodnevna')
INSERT INTO tblShiftWorks (ShiftWorks)
VALUES('Noćna')
INSERT INTO tblShiftWorks (ShiftWorks)
VALUES('24-časovno dežurstvo')





--View


GO
CREATE VIEW vwAdmin AS
SELECT        dbo.tblAdministrator.AdministratorID, dbo.tblAdministrator.NameSurname, dbo.tblAdministrator.BLK, dbo.tblAdministrator.Gender, dbo.tblAdministrator.DateOfBirth, dbo.tblAdministrator.Citizenship, 
                         dbo.tblAdministrator.UsernameLogin, dbo.tblAdministrator.PasswordLogin, dbo.tblGender.GenderID, dbo.tblGender.GenderSign, dbo.tblGender.Gender AS Expr1
FROM            dbo.tblAdministrator INNER JOIN
                         dbo.tblGender ON dbo.tblAdministrator.Gender = dbo.tblGender.GenderID
GO

GO
CREATE VIEW vwMainternace AS
SELECT        dbo.tblMainternace.MainternaceID, dbo.tblMainternace.NameSurname, dbo.tblMainternace.BLK, dbo.tblMainternace.Gender, dbo.tblMainternace.DateOfBirth, dbo.tblMainternace.Citizenship, 
                         dbo.tblMainternace.UsernameLogin, dbo.tblMainternace.PasswordLogin, dbo.tblMainternace.ExpandClinic, dbo.tblMainternace.AccessibilityDisabled, dbo.tblGender.GenderID, dbo.tblGender.GenderSign, 
                         dbo.tblGender.Gender AS Expr1
FROM            dbo.tblMainternace INNER JOIN
                         dbo.tblGender ON dbo.tblMainternace.Gender = dbo.tblGender.GenderID
GO

GO
CREATE VIEW vwManager AS
SELECT        dbo.tblManager.ManagerID, dbo.tblManager.NameSurname, dbo.tblManager.BLK, dbo.tblManager.Gender, dbo.tblManager.DateOfBirth, dbo.tblManager.Citizenship, dbo.tblManager.UsernameLogin, 
                         dbo.tblManager.PasswordLogin, dbo.tblManager.FloorInstitution, dbo.tblManager.MaxNumSupervising, dbo.tblManager.MinNumRoomSupervised, dbo.tblManager.NumOmissions, dbo.tblGender.GenderID, 
                         dbo.tblGender.GenderSign, dbo.tblGender.Gender AS Expr1
FROM            dbo.tblManager INNER JOIN
                         dbo.tblGender ON dbo.tblManager.Gender = dbo.tblGender.GenderID
GO

GO
CREATE VIEW vwDoctor AS
SELECT        dbo.tblDoctor.DoctorID, dbo.tblDoctor.NameSurname, dbo.tblDoctor.BLK, dbo.tblDoctor.Gender, dbo.tblDoctor.DateOfBirth, dbo.tblDoctor.Citizenship, dbo.tblDoctor.UsernameLogin, dbo.tblDoctor.PasswordLogin, 
                         dbo.tblDoctor.UniqueNumber, dbo.tblDoctor.AccountNumber, dbo.tblDoctor.Department, dbo.tblDoctor.ShiftInWhichHeWorks, dbo.tblDoctor.SuperiorManager, dbo.tblDoctor.ResponsiblePatientAdmission, 
                         dbo.tblShiftWorks.ShiftWorksID, dbo.tblShiftWorks.ShiftWorks, dbo.tblGender.GenderID, dbo.tblGender.GenderSign, dbo.tblGender.Gender AS Expr1, dbo.tblManager.ManagerID, dbo.tblManager.NameSurname AS Expr2, 
                         dbo.tblManager.FloorInstitution, dbo.tblManager.MaxNumSupervising, dbo.tblManager.NumOmissions, dbo.tblManager.MinNumRoomSupervised
FROM            dbo.tblDoctor INNER JOIN
                         dbo.tblManager ON dbo.tblDoctor.SuperiorManager = dbo.tblManager.ManagerID INNER JOIN
                         dbo.tblGender ON dbo.tblDoctor.Gender = dbo.tblGender.GenderID INNER JOIN
                         dbo.tblShiftWorks ON dbo.tblDoctor.ShiftInWhichHeWorks = dbo.tblShiftWorks.ShiftWorksID
GO


GO
CREATE VIEW vwPatient AS
SELECT        dbo.tblPatient.PatientID, dbo.tblPatient.NameSurname, dbo.tblPatient.BLK, dbo.tblPatient.Gender, dbo.tblPatient.DateOfBirth, dbo.tblPatient.Citizenship, dbo.tblPatient.UsernameLogin, dbo.tblPatient.PasswordLogin, 
                         dbo.tblPatient.HealthInsuranceCardNumber, dbo.tblPatient.ExpirationDateHealthInsurance, dbo.tblPatient.UniqueNumberDoctor, dbo.tblDoctor.DoctorID, dbo.tblDoctor.NameSurname AS Expr1, dbo.tblDoctor.UniqueNumber, 
                         dbo.tblDoctor.AccountNumber, dbo.tblDoctor.Department, dbo.tblDoctor.ShiftInWhichHeWorks, dbo.tblDoctor.ResponsiblePatientAdmission, dbo.tblDoctor.SuperiorManager, dbo.tblGender.GenderID, dbo.tblGender.GenderSign, 
                         dbo.tblGender.Gender AS Expr2
FROM            dbo.tblPatient INNER JOIN
                         dbo.tblGender ON dbo.tblPatient.Gender = dbo.tblGender.GenderID INNER JOIN
                         dbo.tblDoctor ON dbo.tblPatient.UniqueNumberDoctor = dbo.tblDoctor.DoctorID
GO

CREATE VIEW vwDailyMaintenance AS
SELECT        dbo.tblDailyMaintenance.DailyMaintenanceID, dbo.tblDailyMaintenance.DateMaintenance, dbo.tblDailyMaintenance.WorkingTime, dbo.tblDailyMaintenance.DescriptionMaintenance, dbo.tblDailyMaintenance.Maintenance, 
                         dbo.tblMainternace.MainternaceID, dbo.tblMainternace.NameSurname, dbo.tblMainternace.BLK, dbo.tblMainternace.DateOfBirth
FROM            dbo.tblDailyMaintenance INNER JOIN
                         dbo.tblMainternace ON dbo.tblDailyMaintenance.Maintenance = dbo.tblMainternace.MainternaceID
GO


