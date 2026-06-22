# Advanced SQL Exercises - Explanations and Expected Output

This document provides explanations for the advanced T-SQL queries implemented in `Advanced_SQL_Exercises.sql` and demonstrates the simulated expected output when executed against a standard e-commerce database.

## Exercise 1: Ranking and Window Functions
**Explanation:** 
We use `ROW_NUMBER()`, `RANK()`, and `DENSE_RANK()` over a partition of the `Category` column to rank products by their `Price` in descending order. We then wrap this in a Common Table Expression (CTE) to filter out only the top 3 most expensive products per category.

**Expected Output:**
| ProductID | ProductName | Category | Price | RowNumRank | StdRank | DenseRnk |
|---|---|---|---|---|---|---|
| 105 | Gaming Laptop | Electronics | 1500 | 1 | 1 | 1 |
| 112 | 4K Monitor | Electronics | 1500 | 2 | 1 | 1 |
| 109 | Smartphone | Electronics | 900 | 3 | 3 | 2 |
*(Notice how RANK skips to 3 after a tie, while DENSE_RANK proceeds sequentially to 2).*

---

## Exercise 2: Aggregation with GROUPING SETS, CUBE, and ROLLUP
**Explanation:** 
Instead of running multiple heavy `GROUP BY` queries, we use `GROUPING SETS`, `ROLLUP`, and `CUBE` to generate multi-dimensional totals in a single pass.
- `GROUPING SETS` gives exactly the specific combinations we asked for (Region alone, Category alone, etc.).
- `ROLLUP` gives hierarchical subtotals (like a receipt).
- `CUBE` generates every mathematical combination possible.

**Expected Output (Snippet of CUBE results):**
| Region | Category | TotalQuantitySold |
|---|---|---|
| North | Electronics | 450 |
| North | Furniture | 200 |
| North | NULL | 650 *(Subtotal for North)* |
| NULL | Electronics | 1200 *(Subtotal for Electronics)* |
| NULL | NULL | 5000 *(Grand Total)* |

---

## Exercise 3: CTEs and MERGE
**Explanation:**
- **Recursive CTE**: We establish an anchor date of '2025-01-01' and recursively add 1 day until we hit '2025-01-31'. This is an incredibly powerful way to generate a calendar table dynamically out of thin air.
- **MERGE**: Instead of writing separate `UPDATE` and `INSERT` statements, `MERGE` looks at our `StagingProducts` table and decides: "If the product exists, update its price. If it doesn't exist, insert it as a brand new product."

**Expected Output:**
*(Calendar CTE)*
| CalendarDate |
|---|
| 2025-01-01 |
| 2025-01-02 |
| ... |
| 2025-01-31 |

*(MERGE returns no table data by default, but simply outputs: `(15 rows affected)`)*

---

## Exercise 4: PIVOT and UNPIVOT
**Explanation:** 
`PIVOT` is used to transform data from a long format into a wide format. We sum the quantities sold and turn the `DATENAME` months into literal column headers. We store this in a temporary table `#PivotedSales` and then use `UNPIVOT` to dynamically collapse those month columns back into standard rows.

**Expected Output (After PIVOT):**
| ProductName | January | February | March | April | May | June |
|---|---|---|---|---|---|---|
| Gaming Laptop | 15 | 22 | 18 | 30 | 12 | 45 |
| Office Chair | 40 | 50 | 35 | 60 | 55 | 70 |

---

## Exercise 5: Using CTE to Simplify a Query
**Explanation:**
Instead of writing a complex nested subquery in the `WHERE` or `HAVING` clause, we extract the order-counting logic into a clean CTE named `CustomerOrderCounts`. We then join this CTE back to the main `Customers` table to easily filter out anyone with `<= 3` orders.

**Expected Output:**
| CustomerID | Name | OrderCount |
|---|---|---|
| C001 | Alice Johnson | 5 |
| C045 | Bob Smith | 8 |
| C102 | Charlie Brown | 4 |
