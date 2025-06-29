CREATE DATABASE SwagatDB;
USE SwagatDB;

CREATE TABLE ProductCatalog (
    ID INT PRIMARY KEY,
    Name VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

INSERT INTO ProductCatalog (ID, Name, Category, Price) VALUES
(101, 'Ultra Laptop 15"', 'Electronics', 1450.00),
(102, 'Smartphone Elite', 'Electronics', 980.00),
(103, 'Wireless Speaker', 'Electronics', 310.00),
(104, 'Curved Monitor', 'Electronics', 520.00),
(105, 'Ergonomic Mouse', 'Electronics', 45.00),
(106, 'Executive Chair', 'Furniture', 360.00),
(107, 'Standing Desk', 'Furniture', 215.00),
(108, 'Wooden Shelf', 'Furniture', 175.00),
(109, 'Task Chair', 'Furniture', 240.00),
(110, 'Luxury Sofa', 'Furniture', 690.00),
(111, 'Graphic Tee', 'Apparel', 28.00),
(112, 'Denim Jacket', 'Apparel', 155.00),
(113, 'Running Shoes', 'Apparel', 130.00),
(114, 'Slim Fit Jeans', 'Apparel', 85.00),
(115, 'Cotton Hoodie', 'Apparel', 65.00);

SELECT *
FROM (
    SELECT *,
           ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowPosition
    FROM ProductCatalog
) AS RankedProducts
WHERE RowPosition <= 3;

SELECT *
FROM (
    SELECT *,
           RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS PriceRank
    FROM ProductCatalog
) AS RankedProducts
WHERE PriceRank <= 3;

SELECT *
FROM (
    SELECT *,
           DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DensePriceRank
    FROM ProductCatalog
) AS RankedProducts
WHERE DensePriceRank <= 3;
