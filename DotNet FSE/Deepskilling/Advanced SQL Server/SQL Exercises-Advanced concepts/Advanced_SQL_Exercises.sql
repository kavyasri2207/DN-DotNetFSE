-- =========================================================================================
-- Ranking and Window Functions
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
