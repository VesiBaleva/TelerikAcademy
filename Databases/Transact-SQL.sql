-- Task 1
-- Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and 
--Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. Write a stored procedure that selects 
--the full names of all persons.
USE AccountsDB
CREATE TABLE Persons(
	Id int IDENTITY,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	SSN nvarchar(10),
	CONSTRAINT PK_Persons PRIMARY KEY(Id)
)
GO

CREATE TABLE Accounts(
	Id int IDENTITY,
	PersonId int,
	Balance money,
	CONSTRAINT PK_Accounts PRIMARY KEY(Id),
	CONSTRAINT FK_Persons FOREIGN KEY(PersonID) REFERENCES Persons(ID)
)

INSERT INTO Persons(FirstName,LastName,SSN)
VALUES ('George', 'Georgiev', '15156582'),
	   ('Ivan', 'Petrov','85851695'),
	   ('Petar','Daskalov','82569547')

INSERT INTO Accounts(PersonId,Balance)
VALUES (1, 25.35),
	   (1,54),
	   (3,888)

GO
CREATE PROC usp_SelectPersons
AS
  SELECT  FirstName + ' ' + LastName
   FROM Persons
GO

-- Task 2
-- Create a stored procedure that accepts a number as a parameter and returns all persons
-- who have more money in their accounts than the supplied number.
USE AccountsDB
GO
CREATE PROCEDURE usp_SelectPersonsWithMoreMoney
	@balance money
AS 
	SELECT  FirstName + ' ' + LastName AS Fullname, Balance
    FROM Persons
		JOIN Accounts
		ON Persons.ID=Accounts.PersonID
	WHERE Balance>@balance
GO

EXEC usp_SelectPersonsWithMoreMoney 50

-- Task 3
-- Create a function that accepts as parameters – sum, yearly interest rate and number of months.
-- It should calculate and return the new sum. Write a SELECT to test whether the function works as expected.
USE AccountsDB
GO
ALTER FUNCTION ufn_CalcSum(@sum money,@rate float, @months smallint)
  RETURNS money
AS
BEGIN
	RETURN @sum*POWER((1+@rate/12/100),@months)
END
GO
SELECT dbo.ufn_CalcSum(200,48,5) as SUM

-- Task 4
-- Create a stored procedure that uses the function from the previous example to give an interest to 
-- a person's account for one month. It should take the AccountId and the interest rate as parameters.
USE AccountsDB
GO
CREATE PROCEDURE usp_AccountInterestRateForOneMonth
	@accountId INT, @interestRate FLOAT
AS 
	DECLARE @accountMoney MONEY = (
                SELECT Balance
                FROM Accounts
                WHERE Id = @accountId)
 
        SELECT dbo.ufn_CalcSum(@accountMoney, @interestRate, 1)
GO

EXEC usp_AccountInterestRateForOneMonth 1,5

-- Task 5
-- Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney (AccountId, money)
-- that operate in transactions.
USE AccountsDB
GO
ALTER PROCEDURE usp_WithdrawMoney
	@accountId INT, @money MONEY
AS 
	BEGIN TRAN
	DECLARE @accountMoney MONEY = (
                SELECT Balance
                FROM Accounts
                WHERE Id = @accountId)
	   IF (@accountMoney>=@money)
	   BEGIN
		   UPDATE Accounts
		   SET Balance=Balance-@money
		   WHERE Id=@accountId
		   COMMIT	
	   END
	   ELSE
	   BEGIN
			RAISERROR ('Not enough money in account',16,1)
			ROLLBACK TRAN
	   END
GO

EXEC usp_WithdrawMoney 3,800

GO
CREATE PROCEDURE usp_DepositMoney
	@accountId INT, @money MONEY
AS 
	BEGIN TRAN
	DECLARE @accountMoney MONEY = (
                SELECT Balance
                FROM Accounts
                WHERE Id = @accountId)
	   IF (@money>=0)
	   BEGIN
		   UPDATE Accounts
		   SET Balance=Balance+@money
		   WHERE Id=@accountId
		   COMMIT	
	   END
	   ELSE
	   BEGIN
			RAISERROR ('Negative sum for deposit',16,1)
			ROLLBACK TRAN
	   END
GO

EXEC usp_DepositMoney 3,800

SELECT * FROM Accounts

-- Task 6
-- Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
-- Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.

CREATE TABLE Logs(
	LogId int IDENTITY,
	AccountId int,
	OldSum money,
	NewSum money,
	CONSTRAINT PK_Logs PRIMARY KEY(LogId)
)
GO
CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS
  INSERT INTO Logs (OldSum, NewSum, AccountID)
  SELECT d.Balance, i.Balance, d.Id
	  FROM deleted AS d
	  JOIN inserted AS i
		ON d.Id = i.Id
GO
 
EXEC dbo.usp_DepositMoney 3, 150
GO

SELECT * FROM Logs

-- Task 7
-- Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name)
-- and all town's names that are comprised of given set of letters.
-- Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.
USE TelerikAcademy
GO
CREATE FUNCTION CheckIfHasLetters (@word nvarchar(20), @letters nvarchar(20))
RETURNS BIT
AS
BEGIN

DECLARE @lettersLen int = LEN(@letters),
@matches int = 0,
@currentChar nvarchar(1)

WHILE(@lettersLen > 0)
BEGIN
	SET @currentChar = SUBSTRING(@letters, @lettersLen, 1)
	IF(CHARINDEX(@currentChar, @word, 0) > 0)
		BEGIN
			SET @matches += 1
			SET @lettersLen -= 1
		END
	ELSE
		SET @lettersLen -= 1
END

IF(@matches >= LEN(@word) OR @matches >= LEN(@letters))
	RETURN 1

RETURN 0
END

GO

CREATE FUNCTION NamesAndTowns(@letters nvarchar(20))
RETURNS @ResultTable TABLE
(
Name varchar(50) NOT NULL
)
AS
BEGIN

INSERT INTO @ResultTable
SELECT LastName  FROM Employees

INSERT INTO @ResultTable
SELECT FirstName FROM Employees

INSERT INTO @ResultTable
SELECT towns.Name FROM Towns towns

DELETE FROM @ResultTable
WHERE dbo.CheckIfHasLetters(Name, @letters) = 0

RETURN
END

GO

SELECT * FROM dbo.NamesAndTowns('oistmiahf')

-- Task 8
-- Using database cursor write a T-SQL script that scans all employees and their addresses and 
-- prints all pairs of employees that live in the same town.
DECLARE empCursor CURSOR READ_ONLY FOR
	SELECT a.FirstName, a.LastName, t1.Name, b.FirstName, b.LastName
	FROM Employees a
	JOIN Addresses adr
	ON a.AddressID = adr.AddressID
	JOIN Towns t1
	ON adr.TownID = t1.TownID,
	 Employees b
	JOIN Addresses ad
	ON b.AddressID = ad.AddressID
	JOIN Towns t2
	ON ad.TownID = t2.TownID
	WHERE t1.Name = t2.Name
	  AND a.EmployeeID <> b.EmployeeID
	ORDER BY a.FirstName, b.FirstName

OPEN empCursor
DECLARE @firstName1 nvarchar(50), @lastName1 nvarchar(50), @town nvarchar(50), @firstName2 nvarchar(50), @lastName2 nvarchar(50)
FETCH NEXT FROM empCursor INTO @firstName1, @lastName1, @town, @firstName2, @lastName2

WHILE @@FETCH_STATUS = 0
  BEGIN
    PRINT @firstName1 + ' ' + @lastName1 + ' ' + @town + ' ' + @firstName2 + ' ' + @lastName2
    FETCH NEXT FROM empCursor 
    INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
  END

CLOSE empCursor
DEALLOCATE empCursor

-- Task 9
-- * Write a T-SQL script that shows for each town a list of all employees that live in it. Sample output:
-- Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
-- Ottawa -> Jose Saraiva
USE TelerikAcademy
DECLARE empCursor CURSOR READ_ONLY FOR
SELECT Name FROM Towns
OPEN empCursor
DECLARE @townName VARCHAR(50), @userNames VARCHAR(MAX)
FETCH NEXT FROM empCursor INTO @townName
 
 
WHILE @@FETCH_STATUS = 0
  BEGIN
                BEGIN
                DECLARE nameCursor CURSOR READ_ONLY FOR
                SELECT a.FirstName, a.LastName
                FROM Employees a
                JOIN Addresses adr
                ON a.AddressID = adr.AddressID
                JOIN Towns t1
                ON adr.TownID = t1.TownID
                WHERE t1.Name = @townName
                OPEN nameCursor
               
                DECLARE @firstName VARCHAR(50), @lastName VARCHAR(50)
                FETCH NEXT FROM nameCursor INTO @firstName,  @lastName
                WHILE @@FETCH_STATUS = 0
                        BEGIN
                                SET @userNames = CONCAT(@userNames, @firstName, ' ', @lastName, ', ')
                                FETCH NEXT FROM nameCursor
                                INTO @firstName,  @lastName
                        END
        CLOSE nameCursor
        DEALLOCATE nameCursor
                END
                SET @userNames = LEFT(@userNames, LEN(@userNames) - 1)
    PRINT @townName + ' -> ' + @userNames
    FETCH NEXT FROM empCursor
    INTO @townName
  END
CLOSE empCursor
DEALLOCATE empCursor
GO



