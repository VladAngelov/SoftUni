-- 01. DDL
CREATE TABLE Cities
(
	[Id]			INT PRIMARY KEY IDENTITY,
	[Name]			NVARCHAR(20) NOT NULL,
	[CountryCode]	CHAR(2)		 NOT NULL
)

CREATE TABLE Hotels
(
	[Id]			INT PRIMARY KEY IDENTITY,	
	[Name]			NVARCHAR(30)   NOT NULL,
	[CityId]		INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	[EmployeeCount]	INT			   NOT NULL,
	[BaseRate]		DECIMAL(15, 2) NOT NULL	
)

CREATE TABLE Rooms
(
	[Id]			INT PRIMARY KEY IDENTITY,	
	[Price]			DECIMAL(15, 2) NOT NULL,
	[Type]			NVARCHAR(20)   NOT NULL,
	[Beds]			INT			   NOT NULL,
	[HotelId]		INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips
(
	[Id]			INT PRIMARY KEY IDENTITY,	
	[RoomId]		INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	[BookDate]		DATE NOT NULL,
	[ArrivalDate]	DATE NOT NULL,
	[ReturnDate]	DATE NOT NULL,
	[CancelDate]	DATE,

	CONSTRAINT CH_BookDate CHECK(BookDate < ArrivalDate), -- [BookDate] must be before [ArrivalDate]
	CONSTRAINT CH_ArrivaLDate CHECK(ArrivalDate < ReturnDate) -- [ArrivalDate] must be before [ReturnDate]
)

CREATE TABLE Accounts
(
	[Id]			INT PRIMARY KEY IDENTITY,	
	[FirstName]		NVARCHAR(50)  NOT NULL,
	[MiddleName]	NVARCHAR(20),
	[LastName]		NVARCHAR(50)  NOT NULL,
	[CityId]		INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
	[BirthDate]		DATE	 	  NOT NULL,
	[Email]			NVARCHAR(100) NOT NULL UNIQUE -- ?? NVARCAR / VARCHAR ??
)

CREATE TABLE AccountsTrips
(
	[AccountId]	INT FOREIGN KEY REFERENCES Accounts(Id) NOT	NULL,
	[TripId]	INT FOREIGN KEY REFERENCES Trips(Id)	NOT NULL,
	[Luggage]	INT NOT	NULL CHECK(Luggage >= 0)-- must be at least 0

	PRIMARY KEY (AccountId, TripId)
)


-- 02. Insert
	/* Insert some sample data into the database. 
	   Write a query to add the following records into the corresponding tables.
	   All Ids should be auto-generated.
	*/
INSERT INTO Accounts VALUES
	('John',	  'Smith',	   'Smith',	    34,	'1975-07-21', 'j_smith@gmail.com'),
	('Gosho',	   NULL,       'Petrov',    11, '1978-05-16', 'g_petrov@gmail.com'),
	('Ivan',	  'Petrovich', 'Pavlov',    59,	'1849-09-26', 'i_pavlov@softuni.bg'),
	('Friedrich', 'Wilhelm',   'Nietzsche', 2,  '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips VALUES
	(101, '2015-04-12',	'2015-04-14', '2015-04-20',	'2015-02-02' ),
	(102, '2015-07-07',	'2015-07-15', '2015-07-22',	'2015-04-29' ),
	(103, '2013-07-17',	'2013-07-23', '2013-07-24',	 NULL	     ),
	(104, '2012-03-17',	'2012-03-31', '2012-04-01',	'2012-01-10' ),
	(109, '2017-08-07',	'2017-08-28', '2017-08-29',	 NULL	     )
						

-- 03. Update
	/*
	  Make all rooms’ prices 14% more expensive where the hotel ID is either 5, 7 or 9.
	*/
UPDATE Rooms
	SET Price *= 1.14 
	WHERE HotelId IN (5, 7, 9)			
	
	
-- 04. Delete
	/*
	 Delete all of Account ID 47’s account’s trips from the mapping table.
	*/  
DELETE 
	FROM AccountsTrips
	WHERE AccountId = 47


-- 05. Bulgarian Cities
	/* 
	 Select all cities in Bulgaria. 
	 Order them by city name.
	*/
SELECT 
	  C.[Id]
	, C.[Name]
  FROM Cities AS C
	WHERE CountryCode = 'BG'
  ORDER BY C.[Name]


-- 06. People Born After 1991
	/*
	 Select all full names and birth years from accounts, who are born after 1991.
	 Order them by birth year (descending), then by first name (ascending).
	 Keep in mind that middle names can be NULL 
	*/
SELECT 
	  CONCAT([FirstName],' ', ISNULL([MiddleName] + ' ', ''), [LastName]) AS [Full Name]
	  --YEAR(BirthDate) AS [BirthYear]
	, DATEPART(YEAR,BirthDate) AS [BirthYear]
  FROM Accounts
    WHERE YEAR(BirthDate) > 1991
  ORDER BY BirthYear DESC, FirstName	  


-- 07. EEE-Mails
	/*
	 Select accounts whose emails start with the letter “e”. 
	 Select their first and last name, their birthdate in the format "MM-dd-yyyy", and their city name.
	 Order them by city name (descending)
	*/
SELECT 
      a.[FirstName]
	, a.[LastName]
	, FORMAT(a.[BirthDate], 'MM-dd-yyyy') AS [BirthDate]
	, c.[Name]  AS [Hometown]
	, a.[Email] AS [Email]
  FROM Accounts AS a
	JOIN Cities AS c ON c.Id = a.CityId
    WHERE Email LIKE('e%') 
  ORDER BY c.[Name] DESC


-- 08. City Statistics
	/*
	 Select all cities with the count of hotels in them. 
	 Order them by the hotel count (descending), then by city name. 
	 Include cities, which have no hotels in them as well.
	*/
SELECT 
	  c.[Name]    AS [City]
	, COUNT(h.Id) AS [Hotels]
  FROM Cities     AS c
    LEFT JOIN Hotels   AS h ON h.CityId = c.Id
	GROUP BY c.[Name]
  ORDER BY [Hotels] DESC, c.[Name]


-- 09. Expensive First Class Rooms
	/*
	 Find all First-Class rooms and select the Id, Price, Hotel name and City name. 
	 Order them by Price (descending), then by Room ID.
	 */
SELECT 
	  r.[Id]    AS [Id]
	, r.[Price] AS [Price]
	, h.[Name]  AS [Hotel]
	, c.[Name]  AS [City]
  FROM Rooms    AS r
    JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS c ON c.Id = h.CityId
	WHERE r.[Type] = 'First Class'
  ORDER BY r.[Price] DESC, r.[Id]


-- 10. Longest and Shortest Trips
	/*
	 Find the longest and shortest trip for each account, in days. 
	 Filter the results to accounts with no middle name and trips, which aren’t cancelled (CancelDate is null).
	 Order the results by Longest Trip days (descending), then by Account ID.
	 */
SELECT 
	  a.[Id]
	, a.[FirstName] + ' ' + a.[LastName] AS [FullName]
	, MAX(DATEDIFF(DAY, t.[ArrivalDate], t.[ReturnDate])) AS [LongestTrip]
	, MIN(DATEDIFF(DAY, t.[ArrivalDate], t.[ReturnDate])) AS [ShortestTrip]
  FROM Accounts		   AS a
    JOIN AccountsTrips AS [at] ON [at].AccountId = a.Id 
	JOIN Trips		   AS t ON t.Id = [at].TripId
	WHERE a.[MiddleName] IS NULL AND t.CancelDate IS NULL
  GROUP BY a.[Id], a.[FirstName] + ' ' + a.[LastName] 
  ORDER BY LongestTrip DESC, a.[Id]


-- 11. Metropolis
	/*
	 Find the top 5 cities, which have the most registered accounts in them. 
	 Order them by the count of accounts (descending).
	*/
SELECT TOP(5) 
	  c.[Id]
	, c.[Name] AS [City]
	, c.[CountryCode] AS [Country]
	, COUNT(a.Id) AS [Accounts]
  FROM Cities AS c
    JOIN Accounts AS a ON a.CityId = c.Id 
	GROUP BY c.[Id], c.[Name], c.[CountryCode]
  ORDER BY [Accounts] DESC


-- 12. Romantic Getaways
	/*
	 Find all accounts, which have had one or more trips to a hotel in their hometown.
	 Order them by the trips count (descending), then by Account ID.
	*/
SELECT 
	  a.[Id]
	, a.[Email]
	, c.[Name]
	, COUNT(t.Id)     AS [TripsCount]
  FROM Accounts       AS a
   JOIN AccountsTrips AS [at] ON [at].AccountId = a.Id
   JOIN Trips         AS t ON t.Id = [at].TripId
   JOIN Rooms         AS r ON r.Id = t.RoomId
   JOIN Hotels        AS h ON h.Id = r.HotelId
   JOIN Cities        AS c ON c.Id = h.CityId
  WHERE a.CityId = h.CityId
   GROUP BY a.[Id], a.[Email], c.[Name]
  ORDER BY [TripsCount] DESC, a.Id


-- 13. Lucrative Destinations
	/*
	 Find the top 10 cities’ Total Revenue Sum (Hotel Base Rate + Room Price) and trip count.
	 Count only trips, which were booked in 2016.
	 Order them by Total Revenue (descending), then by Trip count (descending)
	*/
SELECT TOP(10) 
	c.Id
	, c.Name
	, SUM(h.BaseRate + r.Price) AS TotalRevenue
	, COUNT(t.Id) AS TripCount
  FROM Cities AS c
    JOIN Hotels AS h ON h.CityId = c.Id
	JOIN Rooms AS r ON r.HotelId = h.Id
	JOIN Trips AS t ON t.RoomId = r.Id
	WHERE DATEPART(YEAR, t.BookDate) = 2016
	GROUP BY c.Id, c.Name
	ORDER BY TotalRevenue DESC, TripCount DESC


-- 14. Trip Revenues
	/*
	 Find all trips’ revenue (hotel base rate + room price). 
	 If a trip is canceled, its revenue is always 0. 
	 Extract the trip’s ID, the hotel’s name, the room type and the revenue.
	 Order the results by Room type, then by the Trip ID.
	*/
SELECT 
	  t.Id
	, h.Name
	, r.Type
  , CASE
      WHEN t.CancelDate IS NULL 
		THEN SUM(h.BaseRate + r.Price) 
	  ELSE 0.00
	END AS [Revenue]
  FROM Trips AS t
    JOIN AccountsTrips AS at ON at.TripId = t.Id
    JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId	 
	GROUP BY t.Id, h.Name, r.Type, t.CancelDate
	ORDER BY r.Type, t.Id


-- 15. Top Travelers
	/*
	 Find the top traveler for each country. 
	 The top traveler is the account, which has the most trips to that country.
	 Order the results by the count of trips (descending), then by Account ID.
	*/
SELECT 
	  Temp.Id
	, Temp.Email
	, Temp.CountryCode
	, Temp.Trips
  FROM(
	SELECT 
		  a.Id
		, a.Email
		, c.CountryCode
		, COUNT(t.Id) AS Trips
		, DENSE_RANK() OVER (PARTITION BY c.CountryCode ORDER BY COUNT(t.Id) DESC, a.Id) AS TripsRank
	  FROM Accounts AS a
		JOIN AccountsTrips AS at ON at.AccountId = a.Id
		JOIN Trips  AS t ON t.Id = at.TripId
		JOIN Rooms  AS r ON r.Id = t.RoomId
		JOIN Hotels AS h ON h.Id = r.HotelId
		JOIN Cities AS c ON c.Id = h.CityId
		GROUP BY  a.Id, a.Email, c.CountryCode
) AS Temp
WHERE Temp.TripsRank = 1
ORDER BY Temp.Trips DESC, Temp.Id


-- 16. Luggage Fees
	/*
	 Apart from its base rate and room price, each hotel also has a hidden “luggage fee”. 
	 It’s in the terms and conditions, but nobody reads those…
	 The luggage fee only comes into action if a trip has more than 5 items of luggage and it’s equal to the number of luggage items, multiplied by 5.
	 Take into account only trips, which have more than 0 luggage. 
	 Order the results by the count of luggage (descending)
   */
SELECT 
	  at.TripId
	, SUM(at.Luggage) AS Luggage
	, CASE
		WHEN SUM(Luggage) > 5 THEN CONCAT('$', SUM(Luggage) * 5)
		ELSE '$0'
	  END AS Fee
  FROM AccountsTrips AS at
    GROUP BY TripId
	HAVING SUM(Luggage) > 0
	ORDER BY Luggage DESC


-- 17. GDPR Violation
	/*
	 Retrieve the following information about each trip:
	- Trip ID
	- Account Full Name
	- From – Account hometown
	- To – Hotel city
	- Duration – the duration between the arrival date and return date in days. If a trip is cancelled, the value is “Canceled”
	Order the results by full name, then by Trip ID.
	*/
SELECT 
	  t.Id
	, a.FirstName + ' ' + ISNULL(a.MiddleName + ' ', '') + a.LastName AS [FullName]
	, ac.Name AS [From]
	, c.Name AS [To]
	, CASE
		WHEN t.CancelDate IS NULL THEN CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' days')
		ELSE 'Canceled'
	 END AS Duration
  FROM Trips AS t
    JOIN AccountsTrips AS at ON at.TripId = t.Id
	JOIN Accounts AS a ON a.Id = at.AccountId
	JOIN Cities AS ac ON ac.Id = a.CityId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS c ON c.Id = h.CityId
	ORDER BY FullName, t.Id


-- 18. Available Room
