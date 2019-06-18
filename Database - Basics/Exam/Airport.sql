-- 01. DDL
CREATE TABLE Planes
(
	[Id]    INT PRIMARY KEY IDENTITY,
	[Name]  VARCHAR(30)  NOT NULL,
	[Seats] INT          NOT NULL,
	[Range]	INT          NOT NULL
)

CREATE TABLE Flights
(
	[Id]			INT PRIMARY KEY IDENTITY,
	[DepartureTime]	DATETIME,
	[ArrivalTime]	DATETIME,
	[Origin]	    VARCHAR(50)	  					      NOT NULL,
	[Destination]	VARCHAR(50) 						  NOT NULL,
	[PlaneId]		INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers
(
	[Id]			INT PRIMARY KEY IDENTITY,
	[FirstName]     VARCHAR(30)  NOT NULL,
	[LastName]		VARCHAR(30)  NOT NULL,
	[Age]			INT		     NOT NULL,
	[Address]		VARCHAR(30)  NOT NULL,
	[PassportId]	CHAR(11)	 NOT NULL
)

CREATE TABLE LuggageTypes
(
	[Id]			INT PRIMARY KEY IDENTITY,
	[Type]			VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages
(
	[Id]			INT PRIMARY KEY IDENTITY,
	[LuggageTypeId]	INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
	[PassengerId]	INT FOREIGN KEY REFERENCES Passengers(Id)   NOT NULL
)

CREATE TABLE Tickets
(
	[Id]			INT PRIMARY KEY IDENTITY,
	[PassengerId]	INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
	[FlightId]		INT FOREIGN KEY REFERENCES Flights(Id)	  NOT NULL,
	[LuggageId]		INT FOREIGN KEY REFERENCES Luggages(Id)   NOT NULL,
	[Price]			DECIMAL(15, 2)							  NOT NULL
)


-- 02. Insert
	/*
	 Insert some sample data into the database. 
	 Write a query to add the following records into the corresponding tables. 
	 All Ids should be auto-generated.
	*/
INSERT INTO Planes([Name], [Seats], [Range]) VALUES
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),
('Stelt 297',  254, 2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387, 1342),
('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes([Type]) VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')


-- 03. Update 
	/*
		Make all flights to "Carlsbad" 13% more expensive.
	*/
UPDATE Tickets
	SET Price *= 1.13
  WHERE FlightId IN 
	(
		SELECT Id FROM Flights WHERE Destination ='Carlsbad'
	)


-- 04. Delete 
	/*
	 Delete all flights to "Ayn Halagim".
	*/
DELETE 
  FROM Tickets
    WHERE FlightId IN(
	  SELECT Id FROM Flights
		 WHERE Destination = 'Ayn Halagim' )

DELETE 
  FROM Flights
    WHERE Destination = 'Ayn Halagim'


-- 05. Trips 
	/*
	 Select all flights from the database. 
	 Order them by origin (ascending) and destination (ascending).
	*/
SELECT 
	  Origin
	, Destination
  FROM Flights
  ORDER BY Origin, Destination


-- 06. The "Tr" Planes
	/*
	 Select all of the planes, which name contains "tr". 
	 Order them by id (ascending), name (ascending), seats (ascending) and range (ascending).
	*/
SELECT 
	  [Id]
    , [Name]
	, [Seats]
	, [Range] 
  FROM Planes
    WHERE [Name] LIKE '%tr%'
  ORDER BY [Id], [Name], [Seats], [Range]

 
 -- 07. Flight Profits 
	/*
	 Select the total profit for each flight from database. 
	 Order them by total price (descending), flight id (ascending).
	*/
SELECT 
	  f.[Id]       AS [FlightId] 
	, SUM(t.Price) AS [Price]
  FROM Flights     AS f
    JOIN Tickets   AS t ON t.FlightId = f.Id
	GROUP BY f.Id
	ORDER BY Price DESC, f.Id


-- 08. Passanger and Prices
	/*
	 Select top 10 records from passengers along with the price for their tickets. 
	 Order them by price (descending), first name (ascending) and last name (ascending).
	*/
SELECT TOP(10)
	  p.[FirstName]
	, p.[LastName]
	, t.[Price]
  FROM Passengers  AS p
    JOIN Tickets   AS t ON t.PassengerId = p.Id
	GROUP BY p.[FirstName], p.[LastName], t.Price
	ORDER BY t.[Price] DESC, p.[FirstName], p.[LastName]


-- 09. Top Luggages 
	/*
	 Select luggage type and how many times was used by persons. 
	 Sort by count (descending) and luggage type (ascending).
	*/
SELECT 
	  LT.[Type] AS [Type]
	, COUNT(L.PassengerId) AS [MostUsedLuggage]
  FROM LuggageTypes AS LT
    JOIN Luggages AS L ON L.LuggageTypeId = LT.Id
	 GROUP BY LT.[Type]
	 ORDER BY [MostUsedLuggage] DESC, LT.[Type]


-- 10. Passanger Trips !!! NOT OK !!!
	/*
	 Select the full name of the passengers with their trips (origin - destination). 
	 Order them by full name (ascending), origin (ascending) and destination (ascending).
	*/
SELECT 
	  P.[FirstName] + ' ' + P.[LastName] AS [Full Name]
	, F.[Origin]
	, F.[Destination]
  FROM Passengers     AS P
    FULL JOIN Tickets      AS T ON T.[PassengerId] = P.[Id]
     JOIN Flights	  AS F ON F.[Id] = T.FlightId 
	GROUP BY P.[FirstName] + ' ' + P.[LastName], F.[Origin], F.[Destination]
  ORDER BY [Full Name], F.[Origin], F.[Destination]


-- 11. Non Adventures People  
	/*
	 Select all people who don't have tickets. 
	 Select their first name, last name and age.
	 Order them by age (descending), first name (ascending) and last name (ascending).
	 */
SELECT 
	  P.[FirstName]
	, P.[LastName]
	, P.[Age] 
  FROM Passengers AS P
    LEFT JOIN Tickets AS T ON T.PassengerId = P.Id
	WHERE T.PassengerId IS NULL
	GROUP BY P.FirstName, P.LastName, P.Age
	ORDER BY P.Age DESC, P.FirstName, P.LastName 


-- 12. Lost Luggages
	/*
	 Select all passengers who don't have luggage's. 
	 Select their passport id and address. 
	 Order the results by passport id (ascending) and address (ascending).
	*/
SELECT 
	  P.[PassportId]
	, P.[Address]
 FROM Passengers AS P
   LEFT JOIN Luggages AS L ON L.PassengerId = P.Id
   WHERE L.PassengerId IS NULL
   GROUP BY P.[PassportId], P.[Address]
 ORDER BY P.[PassportId], P.[Address]


 -- 13. Count of Trips
	/*
	 Select all passengers and their count of trips. 
	 Select the first name, last name and count of trips. 
	 Order the results by total trips (descending), first name (ascending) and last name (ascending).
	*/
SELECT 
	  P.[FirstName]
	, P.[LastName]
	, COUNT(T.Id)   AS [Total Trips]
  FROM Passengers   AS P
      LEFT JOIN Tickets  AS T ON T.PassengerId = P.[Id]
	  GROUP BY P.[FirstName], P.[LastName]
	ORDER BY [Total Trips] DESC, P.[FirstName], P.[LastName]


-- 14. Full Info
	/*
	 Select all passengers who have trips. 
	 Select their full name (first name � last name), plane name, trip (in format {origin} - {destination}) and luggage type. 
	 Order the results by full name (ascending), name (ascending), origin (ascending), destination (ascending) and luggage type (ascending).
	*/
SELECT 
	  P.[FirstName] + ' ' + P.[LastName]    AS [Full Name]
	, PL.[Name]								AS [Plane Name]
	, F.[Origin] + ' - ' + F.[Destination]  AS [Trip]
	, LT.[Type]								AS [Luggage Type]
  FROM  Passengers    AS P
    JOIN Tickets      AS T  ON T.[PassengerId] = P.[Id]
	JOIN Luggages     AS L  ON L.Id = T.LuggageId
	JOIN LuggageTypes AS LT ON LT.[Id] = L.[LuggageTypeId]
	JOIN Flights      AS F  ON F.[Id] = T.[FlightId]
	JOIN Planes       AS PL ON PL.[Id] = F.[PlaneId]
	GROUP BY P.[FirstName], P.[LastName], PL.[Name], F.[Origin], F.[Destination], LT.[Type]
  ORDER BY [Full Name], [Plane Name], [Trip], [Luggage Type]


-- 15. Most Expesnive Trips
	/*
	 Select all passengers who have flights. 
	 Select their first name, last name, destination and price for the ticket. 
	 Take only the ticket with highest price for user. 
	 Order the results by price (descending), first name (ascending), last name (ascending) and destination (ascending).
	*/
SELECT 
	  K.[First Name]
	, K.[Last Name]
	, K.[Destination]
	, K.Price
  FROM(
	SELECT
		  P.[FirstName]   AS [First Name]
		, P.[LastName]    AS [Last Name]
		, F.[Destination] AS [Destination]
		, T.[Price]       AS [Price]
		, ROW_NUMBER() OVER (PARTITION BY P.[Id] ORDER BY T.[Price] DESC) AS [Ticket Price]
	  FROM Passengers AS P
		JOIN Tickets  AS T ON T.[PassengerId] = P.[Id]
		JOIN Flights  AS F ON F.[Id] = T.[FlightId]
		GROUP BY P.[FirstName], P.[LastName], F.[Destination], T.[Price], P.[Id]
	  ) AS K
	  WHERE K.[Ticket Price] = 1
	ORDER BY [Price] DESC, [First Name], [Last Name], [Destination]
  

-- 16. Destinations Info !! NOT WORIKING !!
	/*
	 Select all destinations and trips count to them. 
	 Sort the result by trips count (descending) and destination name (ascending).
	*/
SELECT 
	  F.Destination AS [Destination]
	  , COUNT(F.Id) AS [FilesCount]
  FROM Tickets		AS T
    FULL JOIN Flights AS F ON T.[FlightId] = F.[Id]
	GROUP BY F.[Destination]
  ORDER BY [FilesCount] DESC, F.[Destination]

	
-- 17. PSP 
	/*
	 Select all planes with their name, seats count and passengers count. 
	 Order the results by passengers count (descending), plane name (ascending) and seats (ascending) 
	*/
SELECT 
	  P.[Name]			   AS [Name]
	, P.[Seats]			   AS [Seats]
	, COUNT(L.PassengerId) AS [Passengers Count]
  FROM  Tickets AS T
   LEFT JOIN Flights  AS F ON T.FlightId = F.Id
   FULL JOIN Planes   AS P ON P.Id = F.PlaneId
   LEFT JOIN Luggages AS L ON L.Id = T.LuggageId
   GROUP BY P.[Name], P.[Seats]
  ORDER BY [Passengers Count] DESC, [Name], [Seats]

  GO
  
  
  
  -- 18. Vacation NOT WORKING

  CREATE FUNCTION udf_CalculateTickets(
      @Origin	   VARCHAR
	, @Destination VARCHAR
	, @PeopleCount INT) 
	RETURNS VARCHAR(MAX)
  BEGIN

   DECLARE @originName      VARCHAR(50) = (SELECT [Origin]      FROM Flights WHERE Origin = @Origin)
   DECLARE @destinationName VARCHAR(50) = (SELECT [Destination] FROM Flights WHERE Destination = @Destination)

	IF(@PeopleCount <= 0 )
	BEGIN
		RETURN 'Invalid people count!'
	END
	IF(@originName IS NULL OR @destinationName IS NULL)
	BEGIN
		RETURN 'Invalid flight!'
	END
	 
	 DECLARE @flightId INT = (SELECT Id FROM Flights WHERE [Origin] = @Origin AND [Destination] = @Destination) 

	 DECLARE @ticketsPrice DECIMAL(15, 2) = (SELECT [Price] FROM Tickets JOIN Flights AS F ON F.[Id] = @flightId)
	 SET @ticketsPrice = @ticketsPrice * @PeopleCount

	 RETURN 'Total price {price}' + @ticketsPrice

  END
  
  GO
  
  SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)


  DROP FUNCTION udf_CalculateTickets