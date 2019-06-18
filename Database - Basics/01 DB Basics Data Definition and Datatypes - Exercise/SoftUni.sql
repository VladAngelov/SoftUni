CREATE DATABASE SoftUni
go
CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(20) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	AddressText VARCHAR(20) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)
CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30),
	MiddleName VARCHAR(30),
	LastName VARCHAR(30),
	JobTitle VARCHAR(30),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATETIME,
	Salary DECIMAL(15, 2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Towns(Name)
	VALUES ('Sofia'),
		   ('Plovdiv'),
		   ('Varna'),
		   ('Burgas')

INSERT INTO Departments(Name)
	VALUES('Engineering'),
		('Sales'),
		('Marketing'),
		('Software Development'),
		('Quality Assurance')

INSERT INTO Employees(FirstName, JobTitle, DepartmentId, HireDate, Salary)
	VALUES ('Ivan Ivanov Ivanov', '.NET Developer', 4, '01/02/2013', 3500.00),
		   ('Petar Petrov Petrov', 'Senior Engineer', 1, '02/03/2004', 4000.00),
		   ('Maria Petrova Ivanova', 'Intern', 5, '28/08/2016', 525.25),
		   ('Georgi Teziev Ivanov', 'CEO', 2, '09/12/2007', 3000.00),
		   ('Peter Pan Pan', 'Intern', 3, '28/08/2016', 599.88)
/*
SELECT Name FROM Towns
ORDER BY Name
SELECT Name FROM Departments
ORDER BY Name
SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC
*/

UPDATE Employees
SET Salary = Salary*1.1
SELECT Salary FROM Employees

/*
task - 23:

UPDATE Payments
SET TaxRate -= TaxRate *0.03
SELECT TaxRate FROM Payments
*/

TRUNCATE TABLE Towns


CREATE TABLE People(
	Id INT PRIMARY KEY,
	Name VARCHAR(200),
	Height FLOAT,
	Weight FLOAT,
	Gender VARCHAR(1),
	Birthdate DATETIME NOT NULL,
	Biography NTEXT
)


insert into People(Picture) 
SELECT BulkColumn FROM Openrowset( Bulk '"C:\Users\vladi\Pictures\Saved Pictures\70.jpg"', Single_Blob) as img
	


