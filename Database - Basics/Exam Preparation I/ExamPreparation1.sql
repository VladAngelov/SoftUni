/*
 CREATE DATABASE Supermarket
 GO 
 USE Supermarket
 GO
*/

-- 01. DDL 

CREATE TABLE Categories
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Items
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	[Price] DECIMAL(15, 2),
	[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
)

CREATE TABLE Employees
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Phone] CHAR(12) NOT NULL,
	[Salary] DECIMAL(15, 2)
)

CREATE TABLE Orders
(
	[Id] INT PRIMARY KEY IDENTITY,
	[DateTime] DATETIME NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
)

CREATE TABLE OrderItems
(
	[OrderId] INT FOREIGN KEY REFERENCES Orders(Id) NOT NULL,
	[ItemId] INT FOREIGN KEY REFERENCES Items(Id) NOT NULL,
	[Quantity] INT CHECK(Quantity >= 1) NOT NULL

	PRIMARY KEY (OrderId, ItemId)

	-- ADD NAME OF THE CONSTRAINT
	-- CONSTRAINT PK_OrderItems PRIMARY KEY (OrderId, ItemId)
)

CREATE TABLE Shifts
(
	[Id] INT IDENTITY NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL,
	[CheckIn] DATETIME NOT NULL,
	[CheckOut] DATETIME NOT NULL

	PRIMARY KEY (Id, EmployeeId)
)
 -- ADD Check after creating both tables
ALTER TABLE Shifts
ADD CONSTRAINT CH_CheckInCheckOut  CHECK(CheckIn < CheckOut)


-- 02 INSERT
INSERT INTO Employees (FirstName, LastName, Phone, Salary) VALUES
('Stoyan', 'Petrov', '888-785-8573', 500.25),
('Stamat', 'Nikolov', '789-613-1122', 999995.25),
('Evgeni', 'Petkov', '645-369-9517', 1234.51),
('Krasimir', 'Vidolov', '321-471-9982', 50.25)

INSERT INTO Items(Name, Price, CategoryId) VALUES
('Tesla battery', 154.25, 8),
('Chess', 30.25, 8),
('Juice', 5.32, 1),
('Glasses',	10,	8),
('Bottle of water', 1, 1)


-- 03. UPDATE
	-- Make all items’ prices 27% more expensive where the category ID is either 1, 2 or 3. 
UPDATE Items
	SET Price *= 1.27
	WHERE CategoryId IN (1, 2, 3)


-- 04. DELETE
	-- Delete all order items where the order id is 48 (be careful with the relationships)
DELETE 
 FROM OrderItems
	WHERE OrderId = 48

DELETE
 FROM Orders
	WHERE Id = 48


-- 05. Richest People 
	-- Select all employees who have a salary above 6500. Order them by first name, then by employee id.
SELECT Id, FirstName
 FROM Employees
	WHERE Salary > 6500
	ORDER BY FirstName, Id


 -- 06. Cool Phone Numbers 
	-- Select all full names from employees, whose phone number start with ‘3’.
	--Order them by first name (ascending), then by phone number (ascending).
SELECT e.FirstName + ' ' + e.LastName [FullName],
	e.Phone
 FROM Employees AS e
	WHERE Phone LIKE '3%'
	ORDER BY FirstName, Phone


-- 07. Employee Statistics
	/*Select all employees who have orders with the total count of the orders they processed. 
	Order them by their orders count (descending), then by first name. 
	Select their first name, last name and total count of orders.*/
SELECT 
	  e.FirstName
	, e.LastName
	, COUNT(o.Id) AS [Count] 
 FROM Employees AS e
	JOIN Orders AS o ON o.EmployeeId = e.Id
	GROUP BY e.FirstName, e.LastName
	 ORDER BY [Count] DESC, e.FirstName


-- 08. Hard Workers Club
/*
	Select all employees whose workday is over 7 hours long on average, based on their check in/check out times. 
	Select their first, last name and average work hours.
	Order them by work hours (descending), then by employee ID.
*/
SELECT 
	  e.FirstName
	, e.LastName 
	, AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) AS WorkHours
 FROM Employees AS e
	JOIN Shifts AS s ON s.EmployeeId = e.Id
	GROUP BY e.Id, e.FirstName, e.LastName
	HAVING AVG(DATEDIFF(HOUR, s.CheckIn, s.CheckOut)) > 7
	ORDER BY WorkHours DESC, e.Id


-- 09. The Most Expensive Order
/*
	Find the most expensive order. 
	Select its id and total item price. 
	Consider the item quantity when calculating the price.
*/
SELECT TOP(1)
	  oi.OrderId 
	, SUM(i.Price * oi.Quantity) AS TotalPrice
 FROM OrderItems AS oi
 JOIN Items AS i ON i.Id = oi.ItemId
 GROUP BY oi.OrderId
 ORDER BY TotalPrice DESC


-- 10. Rich Item, Poor Item
/*
	Find the top 10 most expensive and cheapest item in each order.
	Order the results by most expensive item’s price (descending), then by order id (ascending).
*/
SELECT TOP(10) 
	  o.Id
	, MAX(i.Price) AS [ExpensivePrice]
	, MIN(i.Price) AS [CheapPrice]
 FROM Orders AS o
 JOIN OrderItems AS oi ON oi.OrderId = o.Id
 JOIN Items AS i ON i.Id = oi.ItemId
 GROUP BY o.Id
ORDER BY ExpensivePrice DESC, o.Id


--11. Cashiers
/*
	Find all employees who have orders. 
	Select their id, first name and last name. Order them by employee id.
*/
SELECT 
	  e.Id
	, e.FirstName
	, e.LastName
 FROM Employees AS e
 JOIN Orders AS o ON o.EmployeeId = e.Id
 GROUP BY e.Id, e.FirstName, e.LastName
 ORDER BY e.Id


 -- 12. Lazy Employees
 /*
	Find all employees, who have below 4 work hours per day.
	Order them by employee id.
 */
 SELECT 
	  e.Id
	, e.FirstName + ' ' + e.LastName AS [FullName]
	--, DATEDIFF(HOUR, s.CheckIn, s.CheckOut)
 FROM Employees AS e
 JOIN Shifts AS s ON s.EmployeeId = e.Id
 WHERE  DATEDIFF(HOUR, s.CheckIn, s.CheckOut) < 4
 GROUP BY e.Id, e.FirstName, e.LastName
 ORDER BY e.Id	


 -- 13. Sellers
 /*
	Find the top 10 employees with their full name, orders’ total price and item count. 
	Count only orders which were ordered before 2018-06-15.
	Order them by total sum (descending), then by item count (descending)
 */
 SELECT TOP(10)
	  e.FirstName + ' ' + e.LastName AS [FullName]
	, SUM(i.Price * oi.Quantity) AS [TotalSum]
	, SUM(oi.Quantity) AS [Count]
  FROM Employees AS e
  JOIN Orders AS o ON o.EmployeeId = e.Id
  JOIN OrderItems AS oi ON oi.OrderId = o.Id
  JOIN Items AS i ON i.Id = oi.ItemId
  WHERE o.DateTime < '2018-06-15'
  GROUP BY e.FirstName, e.LastName
  ORDER BY TotalSum DESC, [Count] DESC


  -- 14. Tough Days
 /*
  Find all records of the employees who don’t have orders and who work over 12 hours. 
  Select only their full name and day of the week.
  Order the results by employee id.
  Note: By the American Standards, Sunday is the first day of week.
 */
 SELECT 
	  e.FirstName + ' ' + e.LastName AS [FullName]
	, DATENAME(WEEKDAY, s.CheckOut) AS [Day of week]
  FROM Employees AS e
   LEFT JOIN Orders AS o ON o.EmployeeId = e.Id
   JOIN Shifts AS s ON s.EmployeeId = e.Id
  WHERE o.EmployeeId IS NULL AND DATEDIFF(HOUR, s.CheckIn, s.CheckOut) > 12
  ORDER BY e.Id


  -- 15. Top Order per Employee 
/*
	Find all information of the employees who have orders. 
	Select their full name, duration of the work day (in hours) and total price of all sold products. 
	Find only the top orders (top orders with highest total price).
	Sort them by full name (ascending), work hours (descending) and total price (descending)
*/
SELECT 
      k.FullName
	, DATEDIFF(HOUR, s.CheckIn, s.CheckOut) AS [WorkHours]
	, k.TotalSum
 FROM(
	SELECT 
		  o.Id AS [OrderId]
		, e.Id AS [EmployeeId]
		, o.DateTime
		, e.FirstName + ' ' + e.LastName AS [FullName]
		, SUM(oi.Quantity * i.Price) AS [TotalSum]
		, ROW_NUMBER() OVER (PARTITION BY e.Id ORDER BY SUM(oi.Quantity * i.Price)DESC) AS [RowNumber]
	 FROM Employees AS e
		JOIN Orders AS o ON o.EmployeeId = e.Id
		JOIN OrderItems AS oi ON oi.OrderId = o.Id
		JOIN Items AS i ON i.Id = oi.ItemId
		GROUP BY o.Id, e.FirstName, e.LastName, e.Id, o.DateTime
	) AS k
		JOIN Shifts AS s ON s.EmployeeId = k.EmployeeId
	WHERE k.RowNumber = 1 AND k.DateTime BETWEEN s.CheckIn AND s.CheckOut
	ORDER BY k.FullName, WorkHours DESC, k.TotalSum DESC


-- 16. Average Profit per Day
/*
	Find the average profit for each day.
	Select the day of month and average daily profit of sold products.
	Sort them by day of month (ascending) and format the profit to the second digit after the decimal point.
*/
SELECT 
	  DATEPART(DAY, o.DateTime) AS  [Day]
	, FORMAT(AVG(oi.Quantity * i.Price), 'N2') AS [Total profit]
	--CAST(AVG(oi.Quantity * i.Price), 'N2') AS DECIMAL(15, 2) AS [Total profit]
 FROM Orders AS o
    JOIN OrderItems AS oi ON oi.OrderId = o.Id
	JOIN Items AS i ON i.Id = oi.ItemId
 GROUP BY DATEPART(DAY, o.DateTime)
 ORDER BY [Day]


 -- 17. Top Products 
/*
	Find information about all products. 
	Select their name, category, how many of them were sold and the total profit they produced.
	Sort them by total profit (descending) and their count (descending)
*/
SELECT 
	  i.Name AS [Item]
	, c.Name AS [Category]
	, SUM(oi.Quantity) AS [Count]
	, SUM(oi.Quantity * i.Price) AS [TotalPrice]
 FROM Items AS i
   JOIN Categories AS c ON c.Id = i.CategoryId
   LEFT JOIN OrderItems AS oi ON oi.ItemId = i.Id
   GROUP BY i.Name, c.Name
   ORDER BY [TotalPrice] DESC, [Count] DESC


-- 18. Promotion Days 
CREATE FUNCTION udf_GetPromotedProducts(
@CurrentDate DATETIME, @StartDate DATETIME, @EndDate DATETIME, 
@Discount DECIMAL, @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
RETURNS VARCHAR(MAX)
BEGIN
	DECLARE @firstItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @FirstItemId)
	DECLARE @secondItemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @SecondItemId)
	DECLARE @thirdtemName VARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @ThirdItemId)

	IF(@firstItemName IS NULL OR @secondItemName IS NULL OR @thirdtemName IS NULL)
	BEGIN
		RETURN 'One of the items does not exists!'
	END

	IF(@CurrentDate NOT BETWEEN @StartDate AND @EndDate)
	BEGIN
		RETURN 'The current date is not within the promotion dates!'
	END

	DECLARE @firstItemPrice DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @FirstItemId)
	DECLARE @secondItemPrice DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @SecondItemId)
	DECLARE @thirdtemPrice DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @ThirdItemId)

	SET @firstItemPrice = @firstItemPrice - (@firstItemPrice * (@Discount / 100))
	SET @secondItemPrice = @secondItemPrice - (@secondItemPrice * (@Discount / 100))
	SET @thirdtemPrice = @thirdtemPrice - (@thirdtemPrice * (@Discount / 100))

	RETURN @firstItemName + ' price: ' + CAST(@firstItemPrice AS VARCHAR(10)) + ' <-> ' + @secondItemName + ' price: ' + CAST(@secondItemPrice AS varchar(10)) + ' <-> ' + @thirdtemName + ' price: ' + CAST(@thirdtemPrice AS varchar(10))
	
END

SELECT dbo.udf_GetPromotedProducts('2018-08-02', '2018-08-01', '2018-08-03',13, 3,4,5)


-- 19. Cancel Order 
CREATE PROCEDURE usp_CancelOrder(@OrderId INT, @CancelDate DATETIME)
AS

DECLARE @targetOrder INT = (SELECT Id FROM Orders WHERE Id = @OrderId)

IF	(@targetOrder IS NULL)
BEGIN
	RAISERROR('The order does not exist!', 16, 1)
	RETURN
END

DECLARE @orderDateTime DATETIME = (SELECT [DateTime] FROM Orders WHERE Id = @OrderId)

IF (DATEDIFF(DAY, @orderDateTime, @CancelDate) > 3)
BEGIN
	RAISERROR('You cannot cancel the order!', 16, 2)
	RETURN
END


-- 20. Deleted Orders 
DELETE FROM OrderItems
WHERE OrderId = @OrderId

DELETE FROM Orders
WHERE Id = @OrderId


EXEC usp_CancelOrder 1, '2018-06-02'
SELECT COUNT(*) FROM Orders
SELECT COUNT(*) FROM OrderItems