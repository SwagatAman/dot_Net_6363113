CREATE DATABASE SwagatDB;
USE SwagatDB;

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    Region VARCHAR(50)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Customers (CustomerID, CustomerName, Region) VALUES
(1, 'Alice', 'North'),
(2, 'Bob', 'South'),
(3, 'Charlie', 'East'),
(4, 'Diana', 'West');

INSERT INTO Products (ProductID, ProductName, Category) VALUES
(1, 'Laptop', 'Electronics'),
(2, 'Chair', 'Furniture'),
(3, 'T-Shirt', 'Apparel'),
(4, 'Desk', 'Furniture');

INSERT INTO Orders (OrderID, CustomerID, OrderDate) VALUES
(101, 1, '2024-06-01'),
(102, 2, '2024-06-02'),
(103, 3, '2024-06-03'),
(104, 4, '2024-06-04');

INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) VALUES
(1, 101, 1, 3),
(2, 101, 3, 2),
(3, 102, 2, 1),
(4, 103, 4, 4),
(5, 104, 1, 2),
(6, 104, 2, 3);

SELECT
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantity
FROM OrderDetails od
JOIN Orders o ON od.OrderID = o.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY GROUPING SETS (
    (c.Region),
    (p.Category),
    (c.Region, p.Category)
)
ORDER BY c.Region, p.Category;

SELECT
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantity
FROM OrderDetails od
JOIN Orders o ON od.OrderID = o.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY ROLLUP (c.Region, p.Category)
ORDER BY c.Region, p.Category;

SELECT
    c.Region,
    p.Category,
    SUM(od.Quantity) AS TotalQuantity
FROM OrderDetails od
JOIN Orders o ON od.OrderID = o.OrderID
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN Products p ON od.ProductID = p.ProductID
GROUP BY CUBE (c.Region, p.Category)
ORDER BY c.Region, p.Category;
