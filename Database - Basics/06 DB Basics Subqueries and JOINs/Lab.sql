SELECT 
	*
  FROM 
	Employees AS e 
  JOIN Departments AS d ON e.DepartmentID = d.DepartmentID

SELECT * 
  FROM Employees AS e
  LEFT JOIN Departments AS d
  ON e.DepartmentID = d.DepartmentID

  
SELECT * 
  FROM Employees AS e
  RIGHT JOIN Departments AS d
  ON e.DepartmentID = d.DepartmentID
  
-- 02 Addresses with Towns
SELECT TOP(50)
	 e.FirstName
	 , e.LastName
	 , t.[Name] AS [Town]
	 , AddressText
  FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY
	 e.FirstName
	 , e.LastName


SELECT 
	e.EmployeeID
	, e.FirstName
	, e.LastName
	, d.[Name] AS [DepartmentName] 
  FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID AND d.[Name] = 'Sales'
--WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID 


SELECT 
	  e.FirstName
	, e.LastName
	, e.HireDate
	, d.[Name] AS [DeptName] 
  FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID --AND d.[Name] = 'Sales'
WHERE e.HireDate > '1999-01-01' AND d.[Name] IN ('Sales', 'Finance')   --(d.[Name] = 'Sales' OR d.[Name] = 'Finance')
ORDER BY e.EmployeeID


-- 10 Employees Summary
SELECT TOP(50) 
	e.EmployeeID
	, CONCAT(e.FirstName, ' ', e.LastName) AS [EmployeeName]
	, CONCAT(m.FirstName, ' ', m.LastName) AS [ManagerName]
	, d.[Name] AS [DepartmentName] 
  FROM Employees AS e
  JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
  LEFT JOIN Employees AS m ON e.ManagerID = m.EmployeeID 
  ORDER BY e.EmployeeID


  SELECT MIN(dt.avgs) FROM
  (SELECT AVG(Salary) AS [Avgs]
    FROM Employees
	GROUP BY DepartmentID) AS dt
	-- second way
SELECT TOP(1) AVG(Salary) AS [Avgs]
    FROM Employees
	GROUP BY DepartmentID
	ORDER BY Avgs
	-------------------


WITH Employees_CTE (FirstName, LastName, DepartmentName)
  AS
	(
		SELECT e.FirstName, e.LastName, d.[Name]
		  FROM Employees AS e
		LEFT JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	)

SELECT FirstName, LastName, DepartmentName
  FROM Employees_CTE	

  
	CREATE TABLE #Employees
	(
		Id INT PRIMARY KEY
		, FirstName VARCHAR(50) NOT NULL
		, LastName VARCHAR(50) NOT NULL
		, Department VARCHAR(50) NOT NULL
	)	  
	SELECT * FROM #Employees

	INSERT INTO #Employees SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name]
		  FROM Employees AS e
		JOIN Departments AS d ON d.DepartmentID = e.DepartmentID