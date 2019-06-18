--1
SELECT COUNT(*) AS [Count]
	FROM WizzardDeposits


--2
SELECT MAX(MagicWandSize) AS [LongestMagicWand]
  From WizzardDeposits


--3
SELECT 
	DepositGroup 
	, MAX(MagicWandSize) AS [LongestMagicWand]
  FROM WizzardDeposits
GROUP BY DepositGroup

-- 4

SELECT TOP(2) DepositGroup 
 FROM WizzardDeposits
 GROUP BY DepositGroup
 ORDER BY AVG(MagicWandSize)

 --5
SELECT 
	DepositGroup
	, SUM(DepositAmount) AS [TotalDepositAmount]
FROM WizzardDeposits
GROUP BY DepositGroup


--6
SELECT
	DepositGroup
	, SUM(DepositAmount) AS [TotalSum]
  FROM WizzardDeposits
    WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
	
--7
SELECT
	DepositGroup
	, SUM(DepositAmount) AS [TotalSum]
  FROM WizzardDeposits
    WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
	HAVING SUM(DepositAmount) < 150000 
ORDER BY [TotalSum] DESC
	
-- 8
SELECT
	DepositGroup
	, MagicWandCreator
	, MIN(DepositCharge) AS MinDepositCharge
 FROM WizzardDeposits
 GROUP BY 
	DepositGroup
	, MagicWandCreator
 ORDER BY
	 MagicWandCreator	
	 , DepositGroup

--9
SELECT
	AgeGroupTable.AgeGroup
	, COUNT(AgeGroupTable.AgeGroup) AS [WizardCount]
  FROM
  (
	SELECT 
		CASE 
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS AgeGroup
	  FROM WizzardDeposits
  ) AS AgeGroupTable
  GROUP BY AgeGroupTable.AgeGroup

--10
SELECT	
	LEFT(FirstName, 1) AS FirstLetter
  FROM WizzardDeposits
  WHERE DepositGroup = 'Troll Chest'
 GROUP BY LEFT(FirstName, 1)

-- 11
SELECT
	DepositGroup
	, IsDepositExpired
	, AVG(DepositInterest) AS [AverageInterest]
	-- FORMAT(AVG(DepositInterest), 'N2') AS [AverageInterest]
	-- за форматиране до 2 знак след запетая
  FROM WizzardDeposits
  WHERE DepositStartDate > '01-01-1985'
  --WHERE YEAR(DepositStartDate) >= 1985
GROUP BY 
	DepositGroup
	, IsDepositExpired
ORDER BY 
	DepositGroup DESC
	, IsDepositExpired


----12
--SELECT SUM(k.Diff) AS SumDifference 
--  FROM(
--	SELECT wd.DepositAmount - (SELECT w.DepositAmount FROM WizzardDeposits AS w WHERE wd.Id = wd.Id + 1) AS Diff
--    FROM WizzardDeposits AS wd) AS k

SELECT SUM(k.SumDiff) AS SumDifference
  FROM 
(SELECT	DepositAmount - LEAD(DepositAmount, 1, 0) OVER (ORDER BY Id) AS SumDiff
  FROM WizzardDeposits ) AS k

  
SELECT SUM(k.SumDiff) AS SumDifference
  FROM 
(SELECT	DepositAmount - LEAD(DepositAmount, 1) OVER (ORDER BY Id) AS SumDiff
  FROM WizzardDeposits ) AS k


-- 13
--USE SoftUni

SELECT DepartmentID, SUM(Salary) AS TotalSum 
  FROM Employees
  GROUP By DepartmentID

  --14
SELECT 
	DepartmentID
	, MIN(Salary) AS MinimumSalary 
  FROM Employees
  WHERE DepartmentID IN (2, 5, 7)
  AND HireDate > '01-01-2000'
  GROUP By DepartmentID


   --15
SELECT * INTO NewEmployeeTable
FROM Employees
WHERE Salary > 30000

DELETE FROM NewEmployeeTable
WHERE ManagerID = 42

UPDATE NewEmployeeTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
 FROM NewEmployeeTable
 GROUP BY DepartmentID

 -- VIDEO 1:17:13