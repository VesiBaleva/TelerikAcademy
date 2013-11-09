--Task 4
--Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
select * from Departments

--Task 5
--Write a SQL query to find all department names.
select Name from Departments

--Task 6
--Write a SQL query to find the salary of each employee.
select FirstName, LastName, JobTitle,Salary from Employees

--Task7
--Write a SQL to find the full name of each employee.
select concat(FirstName,' ',MiddleName,' ',LastName) as FullName from Employees

--Task 8
--Write a SQL query to find the email addresses of each employee (by his first and last name).
-- Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com".
--The produced column should be named "Full Email Addresses".
use TelerikAcademy
select FirstName + '.' + LastName + '@telerik.com' as [Full Email Address] from Employees

--Task 9
--Write a SQL query to find all different employee salaries.
use TelerikAcademy
select distinct Salary from Employees
order by Salary desc


--Task 10
--Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
use TelerikAcademy
select *
from Employees
where JobTitle = 'Sales Representative'


--Task 11
--Write a SQL query to find the names of all employees whose first name starts with "SA".
use TelerikAcademy
select FirstName, LastName, JobTitle, Salary
from Employees
where FirstName like 'SA%'

--Task 12
--Write a SQL query to find the names of all employees whose last name contains "ei".
use TelerikAcademy
select FirstName, LastName, JobTitle, Salary
from Employees
where LastName like '%ei%'

--Task 13
--Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
use TelerikAcademy
select FirstName, LastName, JobTitle, Salary
from Employees
where Salary>=20000 and Salary<=30000
order by Salary

--Task 14
--Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
use TelerikAcademy
select FirstName, LastName, JobTitle, Salary
from Employees
where Salary in (25000,14000,12500,23600)
order by Salary

--Task 15
--Write a SQL query to find all employees that do not have manager.
use TelerikAcademy
select *
from Employees
where ManagerID is null

--Task 16
--Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
use TelerikAcademy
select *
from Employees
where Salary>50000
order by Salary desc

--Task 17
--Write a SQL query to find the top 5 best paid employees.
use TelerikAcademy
select top 5 *
from Employees
order by Salary desc

--Task 18
--Write a SQL query to find all employees along with their address. Use inner join with ON clause.
use TelerikAcademy
select e.FirstName, e.LastName, e.JobTitle,a.AddressText,t.Name
	from Employees e
		join Addresses a
	on e.AddressID=a.AddressID
		join Towns t
	on t.TownID=a.TownID

--Task 19
--Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
use TelerikAcademy
select e.FirstName, e.LastName, e.JobTitle,a.AddressText,t.Name
from Employees e, Addresses a, Towns t
where e.AddressID=a.AddressID and t.TownID=a.TownID

--Task 20
--Write a SQL query to find all employees along with their manager.
use TelerikAcademy
select e.FirstName, e.LastName, e.EmployeeID,e.ManagerID,m.EmployeeID,m.FirstName,m.LastName
from Employees e 
	join Employees m
  on e.ManagerID=m.EmployeeID

--Task 21
--Write a SQL query to find all employees, along with their manager and their address.
--Join the 3 tables: Employees e, Employees m and Addresses a.
use TelerikAcademy
select e.FirstName, e.LastName, a.AddressText, e.EmployeeID,e.ManagerID,m.EmployeeID,m.FirstName,m.LastName
from Employees e 
	left join Employees m
  on e.ManagerID=m.EmployeeID
	join Addresses a
  on a.AddressID=e.AddressID

--Task 22
--Write a SQL query to find all departments and all town names as a single list. Use UNION.
use TelerikAcademy
select d.Name
	from Departments d
  union
select t.Name
	 from Towns t


--Task 23 left join
--Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager.
-- Use right outer join. Rewrite the query to use left outer join.
use TelerikAcademy
select e.FirstName, e.LastName, e.EmployeeID,e.ManagerID,m.EmployeeID,m.FirstName,m.LastName
from Employees e 
	left join Employees m
  on e.ManagerID=m.EmployeeID

--Task 23 right join
use TelerikAcademy
select e.FirstName, e.LastName, e.EmployeeID,e.ManagerID,m.EmployeeID,m.FirstName,m.LastName
from Employees m 
	right join Employees e
  on e.ManagerID=m.EmployeeID

--Task 24
--Write a SQL query to find the names of
-- all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
use TelerikAcademy
select e.FirstName, e.LastName,d.Name, e.HireDate, YEAR(e.HireDate) as [Hire year]
from Employees e
	join Departments d
  on e.DepartmentID=d.DepartmentID
where d.Name in ('Finance','Sales') and YEAR(e.HireDate) between 1995 and 2005
