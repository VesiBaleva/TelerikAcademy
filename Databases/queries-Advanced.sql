--Task 1
-- Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. 
-- Use a nested SELECT statement.
USE TelerikAcademy
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees)

--Task 2
--Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher 
--than the minimal salary for the company.
USE TelerikAcademy
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary <= 
  (SELECT MIN(Salary)*1.1 FROM Employees)

--Task 3
-- Write a SQL query to find the full name, salary and department of the employees that take the minimal salary
-- in their department. Use a nested SELECT statement.
USE TelerikAcademy
SELECT FirstName + ' ' +LastName as [Full Name], Salary,e.DepartmentID
FROM Employees e
WHERE Salary=
  (SELECT MIN(Salary) FROM Employees d
  WHERE d.DepartmentID = e.DepartmentID)

--Task 4
--Write a SQL query to find the average salary in the department #1.
USE TelerikAcademy
SELECT e.DepartmentID, Avg(Salary) as [Average Salary]
FROM Employees e
WHERE e.DepartmentID = 1
GROUP BY e.DepartmentID

--Task 5
--Write a SQL query to find the average salary  in the "Sales" department.
USE TelerikAcademy
SELECT d.Name, Avg(Salary) as [Average Salary]
FROM Employees e
  JOIN Departments d
  on e.DepartmentID=d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name


--Task 6
--Write a SQL query to find the number of employees in the "Sales" department.
USE TelerikAcademy
SELECT d.Name, Count(*) as [Count Empl]
FROM Employees e
  JOIN Departments d
  on e.DepartmentID=d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name  

--Task 7
--Write a SQL query to find the number of all employees that have manager.
USE TelerikAcademy
SELECT Count(*) as [Count Empl]
FROM Employees e
WHERE not e.ManagerID is null

--Task 8
--Write a SQL query to find the number of all employees that have no manager.
USE TelerikAcademy
SELECT Count(*) as [Count Empl]
FROM Employees e
WHERE e.ManagerID is null

--Task 9
--Write a SQL query to find all departments and the average salary for each of them.
USE TelerikAcademy
SELECT d.Name, Avg(Salary) as [Avg Salary]
FROM Employees e
  JOIN Departments d
  on e.DepartmentID=d.DepartmentID
GROUP BY d.Name  

--Task 10
--Write a SQL query to find the count of all employees in each department and for each town.
USE TelerikAcademy
SELECT t.Name as Town, d.Name as Department,  Avg(Salary) as [Avg Salary]
FROM Employees e
  JOIN Departments d
  on e.DepartmentID=d.DepartmentID
  JOIN Addresses Ad
  on e.AddressID=Ad.AddressID
  JOIN Towns t
  on t.TownID=Ad.TownID
GROUP BY t.Name,d.Name
ORDER BY t.Name, d.Name

--Task 11
--Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
USE TelerikAcademy
SELECT m.FirstName,m.LastName, count(e.ManagerID) as [Five Empl]
FROM Employees e
	JOIN Employees m
	on m.EmployeeID=e.ManagerID
GROUP BY m.FirstName,m.LastName
HAVING count(e.ManagerID)=5

--Task 12
--Write a SQL query to find all employees along with their managers. 
--For employees that do not have manager display the value "(no manager)".
USE TelerikAcademy
SELECT m.FirstName + ' ' + m.LastName as [Full Name], RTRIM(COALESCE(e.FirstName,'no manager') + ' ' + COALESCE(e.LastName,'')) as [Manager Full Name]
FROM Employees e
	RIGHT JOIN Employees m
	on e.EmployeeID=m.ManagerID

--Task 13
--Write a SQL query to find the names of 
--all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
USE TelerikAcademy
SELECT e.FirstName, e.LastName as [5 length]
FROM Employees e
WHERE LEN(e.LastName)=5

--Task 14
--Write a SQL query to display the current date and time in the following format "day.month.year 
--hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server.
USE TelerikAcademy
SELECT CONVERT(VARCHAR(10), GETDATE(), 104) + ' ' + CONVERT(VARCHAR(12), GETDATE(), 114) as [Now]

--Task 15
--Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
--Choose appropriate data types for the table fields. 
--Define a primary key column with a primary key constraint. 
--Define the primary key column as identity to facilitate inserting records. 
--Define unique constraint to avoid repeating usernames. 
--Define a check constraint to ensure the password is at least 5 characters long.
USE TelerikAcademy
CREATE TABLE Users (
  UserID int IDENTITY,
  Username nvarchar(15) NOT NULL,
  [Password] nvarchar(15) NOT NULL,
  FullName nvarchar(30) NOT NULL,
  LastLogin datetime NOT NULL DEFAULT GETDATE(),  
  CONSTRAINT PK_Users PRIMARY KEY(UserID),
  CONSTRAINT UK_Username UNIQUE (Username),
  CONSTRAINT UK_Password CHECK (len([Password])>=5)
)
GO

--Task 16
--Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
--Test if the view works correctly.
USE TelerikAcademy
GO
CREATE VIEW [Users in system today] AS
SELECT FullName, Username, [Password] FROM Users
WHERE CONVERT(Date,LastLogin)=CONVERT(date,GETDATE())
GO

--Task 17
--Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). 
--Define primary key and identity column.
USE TelerikAcademy
GO
CREATE TABLE Groups (
  GroupID int IDENTITY,
  GroupName nvarchar(30),
  CONSTRAINT PK_Groups PRIMARY KEY (GroupID),
  CONSTRAINT UK_GroupName UNIQUE (GroupName)
)
GO

--Task 18
--Write a SQL statement to add a column GroupID to the table Users.
--Fill some data in this new column and as well in the Groups table.
--Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
USE TelerikAcademy
ALTER TABLE Users
ADD GroupID int

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
	FOREIGN KEY (GroupID)
	REFERENCES Groups(GroupID)

--Task 19
--Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Users(Username,[Password],FullName,[GroupID])
VALUES ('niki1','nikimoto','Nikolay Kostov',1),
       ('niki2','nikimoto','Nikolay Kostov',2),
	   ('anna','aniba','Anna Ivanova',4),
	   ('toshka','to4ka','Toshka Ivanova',4)

INSERT INTO Groups(GroupName)
VALUES ('Protesti'),
	   ('Vafli')

SELECT * FROM Groups

INSERT INTO Users(Username,[Password],FullName,[GroupID])
VALUES ('niki4','nikimoto','Nikolay Kostov',5)

SELECT * FROM Users

-- Task 20
--Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Groups
SET GroupName='Seminari'
WHERE GroupID=4

SELECT * FROM Groups

SELECT * FROM Users

UPDATE Users
SET GroupID=5
WHERE GroupID=1

UPDATE Users
SET [Password]=[Password] + 'parola'
where LastLogin<CONVERT(date,GETDATE())

-- Task 21
--Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE FullName like '%kosto%'

SELECT * FROM Users

SELECT * FROM Groups

DELETE FROM Groups
WHERE GroupID=2

-- Task 22
-- Write SQL statements to insert in the Users table the names of all employees from the Employees table.
-- Combine the first and last names as a full name.
-- For username use the first letter of the first name + the last name (in lowercase).
-- Use the same for the password, and NULL for last login time.
USE TelerikAcademy
GO
--First disabling all constraints
ALTER TABLE Users NOCHECK CONSTRAINT ALL
ALTER TABLE Users DROP CONSTRAINT UK_Username

GO
--Insert data from Employees
INSERT INTO Users(Username, [Password], FullName, LastLogin)
SELECT LOWER(LEFT(FirstName,1) + LastName),
	   LOWER(LEFT(FirstName,1) + LastName),
	   FirstName + ' ' + LastName,
	   NULL
FROM Employees
GO

--Enable all Constraints after inserting
ALTER TABLE Users CHECK CONSTRAINT ALL
GO

-- Task 23
-- Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010

UPDATE Users
SET LastLogin=CONVERT(date,'20100305')
WHERE LEFT(FullName,1)='R'

UPDATE Users
SET LastLogin=CONVERT(date,'20100309')
WHERE LEN(Username)=5

SELECT * from Users

ALTER TABLE Users
ALTER COLUMN [Password] NVARCHAR(30) NULL

UPDATE Users
SET [Password]=NULL
WHERE CONVERT(Date,LastLogin)<CONVERT(Date,'10.03.2010')

--Task 24
-- Write a SQL statement that deletes all users without passwords (NULL password).
DELETE Users
WHERE [Password] IS NULL 

-- Task 25
-- Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name as [Department Name], e.JobTitle, Avg(Salary) AS [Average Salary]
FROM Employees e
	JOIN Departments d
  ON e.DepartmentID=d.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY d.Name, [Average Salary]

-- Task 26
-- Write a SQL query to display the minimal employee salary by department and job title
-- along with the name of some of the employees that take it.
USE TelerikAcademy
SELECT d.Name as [Department Name], e.JobTitle,MIN(e.FirstName),MIN(e.LastName),e.Salary AS [Min Salary]
FROM Employees e
	JOIN Departments d
  ON e.DepartmentID=d.DepartmentID
WHERE e.Salary=
	(SELECT MIN(Salary)
	 FROM Employees em	
	 WHERE em.DepartmentID = e.DepartmentID
	       AND
		   em.JobTitle = e.JobTitle)
GROUP BY d.Name, e.JobTitle,e.Salary

-- Task 27
-- Write a SQL query to display the town where maximal number of employees work.
USE TelerikAcademy
SELECT t.Name, COUNT(*) AS [Max Cnt]
FROM Employees e
	JOIN Addresses a
	ON e.AddressID=a.AddressID
	JOIN Towns t
	ON t.TownID=a.TownID
GROUP BY t.Name
HAVING COUNT(*)=(SELECT MAX(q.Cnt)
				 FROM (SELECT a.TownID, COUNT(*) AS Cnt
					 FROM Employees e
						JOIN Addresses a
						ON e.AddressID=a.AddressID
    					GROUP BY a.TownID) q)

-- Task 28
-- Write a SQL query to display the number of managers from each town.
SELECT q.Name AS [Town Name], COUNT(*) AS [Managers]
FROM (SELECT e.EmployeeID, e.FirstName, e.LastName, t.Name
		FROM Employees em
			JOIN Employees e
			ON em.ManagerID=e.EmployeeID
			JOIN Addresses a
			ON a.AddressID=e.AddressID
			JOIN Towns t
			ON t.TownID=a.TownID
		GROUP BY e.EmployeeID, e.FirstName, e.LastName, t.Name) q
GROUP BY q.Name
ORDER BY q.Name

--Task 29
--Write a SQL to create table WorkHours to store work reports for each employee
--(employee id, date, task, hours, comments). Don't forget to define  identity, primary key and appropriate foreign key.
--Issue few SQL statements to insert, update and delete of some data in the table.
--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--For each change keep the old record data, the new record data and the command (insert / update / delete).
CREATE TABLE WorkHours(
	EmployeeID int IDENTITY,
	[Date] datetime,
	Task nvarchar(50),
	[Hours] int,
	Comment nvarchar(50),
	CONSTRAINT PK_WorkHours PRIMARY KEY(EmployeeID),
	CONSTRAINT FK_WorkHours_Employees FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID)
)
GO
INSERT INTO WorkHours(Date, Task, Hours)
VALUES
	(getdate(), 'Sample Task1', 23),
	(getdate(), 'Sample Task2', 3)

DELETE FROM WorkHours
WHERE Task LIKE '%Task1'

UPDATE WorkHours
SET HOURS = 10
WHERE Task = 'Sample Task2'

CREATE TABLE WorkHoursLog(
	Id int IDENTITY,
	OldRecord nvarchar(100) NOT NULL,
	NewRecord nvarchar(100) NOT NULL,
	Command nvarchar(10) NOT NULL,
	EmployeeId int NOT NULL,
	CONSTRAINT PK_WorkHoursLog PRIMARY KEY(Id),
	CONSTRAINT FK_WorkHoursLogs_WorkHours FOREIGN KEY(EmployeeId) REFERENCES WorkHours(EmployeeID)
)
GO

CREATE TRIGGER tr_WorkHoursInsert ON WorkHours FOR INSERT
AS
	INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
	Values(' ',
		   (SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comment 
			FROM Inserted),
		   'INSERT',
		   (SELECT EmployeeID FROM Inserted))
GO

CREATE TRIGGER tr_WorkHoursUpdate ON WorkHours FOR UPDATE
AS
	INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
	Values((SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comment FROM Deleted),
		   (SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comment FROM Inserted),
		   'UPDATE',
		   (SELECT EmployeeID FROM Inserted))
GO

CREATE TRIGGER tr_WorkHoursDeleted ON WorkHours FOR DELETE
AS
	INSERT INTO WorkHoursLog(OldRecord, NewRecord, Command, EmployeeId)
	Values((SELECT 'Day: ' + CAST(Date AS nvarchar(50)) + ' ' + ' Task: ' + Task + ' ' + ' Hours: ' + CAST([Hours] AS nvarchar(50)) + ' ' + Comment FROM Deleted),
		   ' ',
		   'DELETE',
		   (SELECT EmployeeID FROM Deleted))
GO

INSERT INTO WorkHours([Date], Task, Hours, Comment)
VALUES(GETDATE(), 'Random task4', 12, 'Comment4')

DELETE FROM WorkHours
WHERE Task = 'Random task3'

UPDATE WorkHours
SET Task = 'Random task12'
WHERE EmployeeID = 8

-- Task 30
-- Start a database transaction, delete all employees from the 'Sales' department along with all dependent
-- records from the pother tables. At the end rollback the transaction.
USE TelerikAcademy
BEGIN TRAN
DELETE FROM Employees
	SELECT d.Name
	FROM Employees e 
		JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	GROUP BY d.Name
ROLLBACK TRAN

-- Task 31
-- Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data?
USE TelerikAcademy
BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK TRAN

-- Task 32
-- Find how to use temporary tables in SQL Server.
-- Using temporary tables backup all records from EmployeesProjects and restore them back 
-- after dropping and re-creating the table.
USE TelerikAcademy
CREATE TABLE #TemporaryTable(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL
)

INSERT INTO #TemporaryTable
	SELECT EmployeeID, ProjectID
	FROM EmployeesProjects

DROP TABLE EmployeesProjects

CREATE TABLE EmployeesProjects(
	EmployeeID int NOT NULL,
	ProjectID int NOT NULL,
	CONSTRAINT PK_EmployeesProjects PRIMARY KEY(EmployeeID, ProjectID),
	CONSTRAINT FK_EP_Employee FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID),
	CONSTRAINT FK_EP_Project FOREIGN KEY(ProjectID) REFERENCES Projects(ProjectID)
)

INSERT INTO EmployeesProjects
SELECT EmployeeID, ProjectID
FROM #TemporaryTable





