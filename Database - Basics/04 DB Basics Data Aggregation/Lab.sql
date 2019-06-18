SELECT
	DepartmentID
	, AVG(Salary) AS [Average Salary]
 FROM Employees
 GROUP BY DepartmentID
 ORDER BY [Average Salary] DESC

SELECT
	DepartmentID
	, COUNT(*) AS [Emplyees Number]
	, COUNT(MiddleName) AS [Emp]
  FROM Employees
GROUP BY DepartmentID

SELECT
	ManagerID
	, SUM(Salary) AS [Total SaLary]
  FROM Employees
  WHERE DepartmentID IN (1)
GROUP BY ManagerID

SELECT
	DepartmentID
	, ManagerID
	, MAX(Salary) AS [Max Salary]
	, MIN(Salary)AS [Min Salary]
	, MAX(Salary) - MIN(Salary) AS [Diff]
	, COUNT(EmployeeID) AS [Employees Count]
	, AVG(Salary) AS [Avg Salary]
  FROM Employees
  --WHERE DepartmentID IN (1)
GROUP BY ManagerID, DepartmentID

SELECT
	DepartmentID
	, ManagerID
	, MAX(Salary) AS [Max Salary]
	, MIN(Salary)AS [Min Salary]
	, MAX(Salary) - MIN(Salary) AS [Diff]
	, COUNT(EmployeeID) AS [Employees Count]
	, AVG(Salary) AS [Avg Salary]
	, STRING_AGG(Salary, ', ')--CHAR(13)) -- CHAR(13) => Enter(ASCII)
  FROM Employees
  --WHERE DepartmentID IN (1)
GROUP BY ManagerID, DepartmentID


SELECT
	DepartmentID
	, ManagerID
	, MAX(Salary) AS [Max Salary]
	, MIN(Salary)AS [Min Salary]
	, MAX(Salary) - MIN(Salary) AS [Diff]
	, COUNT(EmployeeID) AS [Employees Count]
	, AVG(Salary) AS [Avg Salary]
	, STRING_AGG(Salary, CHAR(13)) WITHIN GROUP (ORDER BY Salary DESC)
  FROM Employees
  --WHERE DepartmentID IN (1)
GROUP BY ManagerID, DepartmentID

SELECT 
	e.DepartmentID
	, SUM(e.Salary) AS [Total Salary]
 FROM Employees AS e
 WHERE 
	e.DepartmentID IN (1, 3, 15)
GROUP BY 
	e.DepartmentID
  HAVING SUM(e.Salary) >= 15000


SELECT
	 'Average Salary' AS Department
	,[1], [7], [16]
  FROM 
	(SELECT 
		DepartmentID
		, Salary 
	  FROM 
		Employees) AS dt
  PIVOT
  (
	  AVG(Salary)
	  FOR DepartmentID IN ([1], [7], [16])	
  ) AS PivotTable

SELECT
	 d.[Name]
	 , Salary
	FROM
	 Employees AS e
	 JOIN Departments AS d
	 ON e.DepartmentID = d.DepartmentID
		
