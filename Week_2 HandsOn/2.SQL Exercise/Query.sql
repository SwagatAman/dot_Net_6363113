-- Create and Use Database
CREATE DATABASE db;
GO
USE db;
GO

-- Tables
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    Region VARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Sample Data
INSERT INTO Customers (CustomerID, Name, Region) VALUES
(1, 'Alice', 'North'),
(2, 'Bob', 'South'),
(3, 'Charlie', 'East'),
(4, 'David', 'West');

INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Smartphone', 'Electronics', 800.00),
(3, 'Tablet', 'Electronics', 600.00),
(4, 'Headphones', 'Accessories', 150.00);

INSERT INTO Orders (OrderID, CustomerID, OrderDate) VALUES
(1, 1, '2023-01-15'),
(2, 2, '2023-02-20'),
(3, 3, '2023-03-25'),
(4, 4, '2023-04-30');

INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) VALUES
(1, 1, 1, 1),
(2, 2, 2, 2),
(3, 3, 3, 1),
(4, 4, 4, 3);

-- Exercise 1: Non-Clustered Index on ProductName
SELECT * FROM Products WHERE ProductName = 'Laptop';

CREATE NONCLUSTERED INDEX idx_ProductName
ON Products (ProductName);

SELECT * FROM Products WHERE ProductName = 'Laptop';

-- Exercise 2: Clustered Index on OrderDate
-- Warning: Only one clustered index allowed per table (OrderID is PK & clustered by default)
-- To apply this, drop the existing clustered PK or skip this if you're only observing

-- Example (optional and risky in production):
-- ALTER TABLE Orders DROP CONSTRAINT PK_Orders;
-- CREATE CLUSTERED INDEX idx_OrderDate ON Orders (OrderDate);

-- In general:
SELECT * FROM Orders WHERE OrderDate = '2023-01-15';

-- Exercise 3: Composite Index on CustomerID and OrderDate
SELECT * FROM Orders WHERE CustomerID = 1 AND OrderDate = '2023-01-15';

CREATE NONCLUSTERED INDEX idx_CustomerID_OrderDate
ON Orders (CustomerID, OrderDate);

SELECT * FROM Orders WHERE CustomerID = 1 AND OrderDate = '2023-01-15';
