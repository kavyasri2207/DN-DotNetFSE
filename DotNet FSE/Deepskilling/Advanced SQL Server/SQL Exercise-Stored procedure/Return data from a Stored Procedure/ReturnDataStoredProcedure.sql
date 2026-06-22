-- =========================================================================================
-- Return Data from a Stored Procedure
-- Goal: Create a stored procedure that returns the total number of employees in a department.
-- =========================================================================================

CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    -- Write the SQL query to count the number of employees in the specified department
    SELECT COUNT(EmployeeID) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

-- =========================================================================================
-- Example Execution to test the procedure:
-- EXEC sp_GetEmployeeCountByDepartment @DepartmentID = 3;
-- =========================================================================================
