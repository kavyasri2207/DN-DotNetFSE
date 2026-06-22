## Database Schema and Sample Data
The schema creates the `Departments` and `Employees` tables. Sample data is inserted to provide a baseline for testing the stored procedures. 

*(Note: `IDENTITY(1,1)` was professionally added to the `EmployeeID` column so that the provided `sp_InsertEmployee` procedure works seamlessly without needing to manually pass a Primary Key ID).*

---

## Create a Stored Procedure

### 1. `sp_GetEmployeesByDepartment`
This stored procedure takes a `@DepartmentID` parameter and returns all details of the employees belonging to that specific department by joining the `Employees` and `Departments` tables.

**Output (if executed with `@DepartmentID = 3`):**
| EmployeeID | FirstName | LastName | DepartmentName | Salary | JoinDate |
|---|---|---|---|---|---|
| 3 | Michael | Johnson | IT | 7000.00 | 2018-07-30 |

### 2. `sp_InsertEmployee`
This stored procedure takes all the necessary employee details (Name, Department, Salary, Date) as parameters and dynamically inserts a new record into the `Employees` table. 

**Output:**
*(Executing this procedure returns no table data, but simply outputs `(1 row affected)`)*
