-- =========================================================================================
-- Employee Management System SQL Exercises
-- =========================================================================================

-- 1. Database Schema Creation
CREATE TABLE Departments ( 
    DepartmentID INT PRIMARY KEY, 
    DepartmentName VARCHAR(100) 
); 

CREATE TABLE Employees ( 
    -- Added IDENTITY(1,1) so the sp_InsertEmployee procedure works without passing a manual ID
    EmployeeID INT PRIMARY KEY IDENTITY(1,1), 
    FirstName VARCHAR(50), 
    LastName VARCHAR(50), 
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID), 
    Salary DECIMAL(10,2), 
    JoinDate DATE 
); 
GO

-- 2. Sample Data Insertion
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES 
(1, 'HR'), 
(2, 'Finance'), 
(3, 'IT'), 
(4, 'Marketing'); 

-- Using IDENTITY_INSERT because sample data provides explicit manual EmployeeIDs
SET IDENTITY_INSERT Employees ON;
INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES 
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'), 
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'), 
(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'), 
(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05'); 
SET IDENTITY_INSERT Employees OFF;
GO

-- =========================================================================================
-- Exercise 1: Create a Stored Procedure
-- =========================================================================================

-- Goal: Create a stored procedure to retrieve employee details by department.
CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        e.EmployeeID, 
        e.FirstName, 
        e.LastName, 
        d.DepartmentName, 
        e.Salary, 
        e.JoinDate
    FROM Employees e
    JOIN Departments d ON e.DepartmentID = d.DepartmentID
    WHERE e.DepartmentID = @DepartmentID;
END;
GO

-- Goal: Create sp_InsertEmployee
CREATE PROCEDURE sp_InsertEmployee 
    @FirstName VARCHAR(50), 
    @LastName VARCHAR(50), 
    @DepartmentID INT, 
    @Salary DECIMAL(10,2), 
    @JoinDate DATE 
AS 
BEGIN 
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) 
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate); 
END;
GO
