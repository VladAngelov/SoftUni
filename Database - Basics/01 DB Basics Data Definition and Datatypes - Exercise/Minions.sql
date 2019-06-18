CREATE DATABASE Minions

USE Minions

CREATE TABLE Minions(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Age INT
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
)

ALTER TABLE Minions
	ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

SET IDENTITY_INSERT Towns OFF
	
INSERT INTO Towns(Id, Name)
	VALUES(1, 'Sofia'),
		  (2, 'Plovdiv'),
		  (3, 'Varna')
 
SET IDENTITY_INSERT Minions ON

INSERT INTO Minions(Id, Name, Age, TownId)
	VALUES (1, 'Kevin', 22, 1),
		   (2, 'Bob', 15, 3),
		   (3, 'Steward', NULL, 2)

