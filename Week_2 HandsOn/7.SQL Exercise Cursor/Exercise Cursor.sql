CREATE DATABASE CursorDB;
GO

USE CursorDB;
GO

-- Creating Department table
CREATE TABLE Department (
  DepartmentID INT PRIMARY KEY,
  DepartmentName VARCHAR(100)
);

-- Creating Employees table
CREATE TABLE Employees (
  EmployeeID INT PRIMARY KEY,
  FirstName VARCHAR(50),
  LastName VARCHAR(50),
  DepartmentID INT FOREIGN KEY REFERENCES Department(DepartmentID),
  Salary DECIMAL(10,2),
  JoinDate DATE
);

-- Insert sample data
INSERT INTO Department VALUES
(1, 'HR'),
(2, 'IT'),
(3, 'FINANCE');

INSERT INTO Employees VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Bob', 'Johnson', 3, 5500.00, '2021-07-30');

-- Cursor Declaration and Execution
DECLARE @EmpID INT, @FirstName VARCHAR(50), @LastName VARCHAR(50), 
        @DeptID INT, @Salary DECIMAL(10,2), @JoinDate DATE;

DECLARE employee_cursor CURSOR FOR
SELECT EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate
FROM Employees;

OPEN employee_cursor;

FETCH NEXT FROM employee_cursor INTO @EmpID, @FirstName, @LastName, @DeptID, @Salary, @JoinDate;

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'EmployeeID: ' + CAST(@EmpID AS VARCHAR) +
          ', Name: ' + @FirstName + ' ' + @LastName +
          ', DeptID: ' + CAST(@DeptID AS VARCHAR) +
          ', Salary: ' + CAST(@Salary AS VARCHAR) +
          ', Join Date: ' + CONVERT(VARCHAR, @JoinDate, 23);

    FETCH NEXT FROM employee_cursor INTO @EmpID, @FirstName, @LastName, @DeptID, @Salary, @JoinDate;
END

CLOSE employee_cursor;
DEALLOCATE employee_cursor;

-- Static Cursor
DECLARE static_cursor STATIC CURSOR FOR
SELECT EmployeeID, FirstName FROM Employees;

OPEN static_cursor;
FETCH NEXT FROM static_cursor INTO @EmpID, @FirstName;
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Static Cursor -> ID: ' + CAST(@EmpID AS VARCHAR) + ', Name: ' + @FirstName;
    FETCH NEXT FROM static_cursor INTO @EmpID, @FirstName;
END
CLOSE static_cursor;
DEALLOCATE static_cursor;

-- Dynamic Cursor
DECLARE dynamic_cursor DYNAMIC CURSOR FOR
SELECT EmployeeID, FirstName FROM Employees;

OPEN dynamic_cursor;
FETCH NEXT FROM dynamic_cursor INTO @EmpID, @FirstName;
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Dynamic Cursor -> ID: ' + CAST(@EmpID AS VARCHAR) + ', Name: ' + @FirstName;
    FETCH NEXT FROM dynamic_cursor INTO @EmpID, @FirstName;
END
CLOSE dynamic_cursor;
DEALLOCATE dynamic_cursor;

-- Forward-Only Cursor
DECLARE forward_cursor CURSOR FORWARD_ONLY FOR
SELECT EmployeeID, FirstName FROM Employees;

OPEN forward_cursor;
FETCH NEXT FROM forward_cursor INTO @EmpID, @FirstName;
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Forward Cursor -> ID: ' + CAST(@EmpID AS VARCHAR) + ', Name: ' + @FirstName;
    FETCH NEXT FROM forward_cursor INTO @EmpID, @FirstName;
END
CLOSE forward_cursor;
DEALLOCATE forward_cursor;

-- Keyset Cursor
DECLARE keyset_cursor KEYSET CURSOR FOR
SELECT EmployeeID, FirstName FROM Employees;

OPEN keyset_cursor;
FETCH NEXT FROM keyset_cursor INTO @EmpID, @FirstName;
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Keyset Cursor -> ID: ' + CAST(@EmpID AS VARCHAR) + ', Name: ' + @FirstName;
    FETCH NEXT FROM keyset_cursor INTO @EmpID, @FirstName;
END
CLOSE keyset_cursor;
DEALLOCATE keyset_cursor;
