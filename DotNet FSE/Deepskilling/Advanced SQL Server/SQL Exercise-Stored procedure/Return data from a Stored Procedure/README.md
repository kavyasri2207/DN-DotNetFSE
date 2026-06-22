## Return Data from a Stored Procedure

### `sp_GetEmployeeCountByDepartment`
This stored procedure takes a `@DepartmentID` as an input parameter and uses the `COUNT()` aggregate function to return the total number of employees currently assigned to that department.

### Visual Data Breakdown
Based on our sample data, here is how the departments and employees are currently distributed across the database:

* **Dept 1 — HR**: John Doe `(Total: 1)`
* **Dept 2 — Finance**: Jane Smith `(Total: 1)`
* **Dept 3 — IT**: Michael Johnson `(Total: 1)`  <-- *If queried, returns 1*
* **Dept 4 — Marketing**: Emily Davis `(Total: 1)`

---

**Example Execution (Querying Dept 3 - IT):**
```sql
EXEC sp_GetEmployeeCountByDepartment @DepartmentID = 3;
```

**Output:**
```text
TotalEmployees
--------------
1

```
