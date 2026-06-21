-- =========================================================================================
-- Advanced SQL Exercises for Online Retail Store (T-SQL / SQL Server)
-- =========================================================================================

-- =========================================================================================
-- Exercise 1: Ranking and Window Functions
-- Goal: Find the top 3 most expensive products in each category using ranking functions.
-- =========================================================================================

WITH RankedProducts AS (
    SELECT 
        ProductID,
        ProductName,
        Category,
        Price,
        -- ROW_NUMBER: Strictly sequential ranking without ties
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNumRank,
        -- RANK: Skips rank numbers when there is a tie
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS StdRank,
        -- DENSE_RANK: Does not skip rank numbers when there is a tie
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRnk
    FROM Products
)
SELECT * 
FROM RankedProducts
WHERE RowNumRank <= 3;


-- =========================================================================================
-- Exercise 2: Aggregation with GROUPING SETS, CUBE, and ROLLUP
-- Goal: Analyze sales data across multiple dimensions (Region and Category).
-- =========================================================================================

-- 1. Using GROUPING SETS (Specific totals by Region, by Category, and Grand Total)
SELECT 
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantitySold
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY GROUPING SETS (
    (c.Region, p.Category),
    (c.Region),
    (p.Category),
    ()
);

-- 2. Using ROLLUP (Hierarchical subtotals and grand total)
SELECT 
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantitySold
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY ROLLUP (c.Region, p.Category);

-- 3. Using CUBE (Every possible mathematical combination of Region and Category)
SELECT 
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantitySold
FROM Orders o
JOIN OrderDetails od ON o.OrderID = od.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY CUBE (c.Region, p.Category);


-- =========================================================================================
-- Exercise 3: CTEs and MERGE
-- Goal: Create a recursive CTE for a calendar and use MERGE for upserts.
-- =========================================================================================

-- a) Recursive CTE to generate dates from '2025-01-01' to '2025-01-31'
WITH CalendarCTE AS (
    -- Anchor member (Starting point)
    SELECT CAST('2025-01-01' AS DATE) AS CalendarDate
    UNION ALL
    -- Recursive member (Loops adding 1 day until condition is met)
    SELECT DATEADD(day, 1, CalendarDate)
    FROM CalendarCTE
    WHERE CalendarDate < '2025-01-31'
)
SELECT CalendarDate FROM CalendarCTE;

-- b) MERGE statement to update or insert product prices
-- Assuming a target table 'Products' and a source table 'StagingProducts'
MERGE INTO Products AS Target
USING StagingProducts AS Source
ON (Target.ProductID = Source.ProductID)
WHEN MATCHED THEN 
    -- Update existing product prices
    UPDATE SET Target.Price = Source.Price
WHEN NOT MATCHED BY TARGET THEN 
    -- Insert completely new products
    INSERT (ProductID, ProductName, Category, Price)
    VALUES (Source.ProductID, Source.ProductName, Source.Category, Source.Price);


-- =========================================================================================
-- Exercise 4: PIVOT and UNPIVOT
-- Goal: Transform data rows into columns for reporting, and back again.
-- =========================================================================================

-- 1 & 2. Aggregate sales by Product and Month, then PIVOT
SELECT *
INTO #PivotedSales -- Storing in a temporary table so we can easily UNPIVOT it in step 3
FROM (
    SELECT 
        p.ProductName,
        DATENAME(month, o.OrderDate) AS OrderMonth,
        od.Quantity
    FROM OrderDetails od
    JOIN Orders o ON od.OrderID = o.OrderID
    JOIN Products p ON od.ProductID = p.ProductID
) AS SourceTable
PIVOT (
    SUM(Quantity)
    FOR OrderMonth IN ([January], [February], [March], [April], [May], [June])
) AS PivotTable;

-- View the pivoted data (Months are now Columns)
SELECT * FROM #PivotedSales;

-- 3. UNPIVOT to convert the Monthly Columns back to standard Rows
SELECT ProductName, OrderMonth, Quantity
FROM #PivotedSales
UNPIVOT (
    Quantity
    FOR OrderMonth IN ([January], [February], [March], [April], [May], [June])
) AS UnpivotTable;

-- Clean up the temporary table
DROP TABLE #PivotedSales;


-- =========================================================================================
-- Exercise 5: Using CTE to Simplify a Query
-- Goal: Find all customers who have placed more than 3 orders.
-- =========================================================================================

WITH CustomerOrderCounts AS (
    SELECT 
        o.CustomerID,
        COUNT(o.OrderID) AS OrderCount
    FROM Orders o
    GROUP BY o.CustomerID
)
SELECT 
    c.CustomerID,
    c.Name,
    coc.OrderCount
FROM CustomerOrderCounts coc
JOIN Customers c ON c.CustomerID = coc.CustomerID
WHERE coc.OrderCount > 3;

-- =========================================================================================
-- End of Assignment
-- =========================================================================================
