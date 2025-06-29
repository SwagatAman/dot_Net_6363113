USE Swagat;

SELECT 
    ProductName,
    OrderMonth,
    TotalQuantity
FROM (
    SELECT 
        ProductName, 
        [2025-01], [2025-02], [2025-03]
    FROM (
        SELECT 
            P.ProductName,
            FORMAT(O.OrderDate, 'yyyy-MM') AS OrderMonth,
            OD.Quantity
        FROM 
            Orders O
        JOIN OrderDetails OD ON O.OrderID = OD.OrderID
        JOIN Products P ON P.ProductID = OD.ProductID
    ) AS SourceTable
    PIVOT (
        SUM(Quantity)
        FOR OrderMonth IN ([2025-01], [2025-02], [2025-03])
    ) AS Pivoted
) AS PivotedTable
UNPIVOT (
    TotalQuantity FOR OrderMonth IN ([2025-01], [2025-02], [2025-03])
) AS UnpivotedTable;
