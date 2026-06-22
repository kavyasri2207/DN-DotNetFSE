# Advanced SQL Exercises - Explanations and Expected Output

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
