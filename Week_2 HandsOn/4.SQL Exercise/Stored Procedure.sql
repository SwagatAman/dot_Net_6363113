CREATE DATABASE EmployeeDB;
GO

USE EmployeeDB;
GO
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);

INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');

INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
('John', 'Doe', 1, 5000.00, '2020-01-15'),
('Jane', 'Smith', 2, 6000.00, '2019-03-22'),
('Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
('Emily', 'Davis', 4, 5500.00, '2021-11-05');

--Exercise 1: Create a Stored Procedure to Insert Employee

CREATE PROCEDURE sp_InsertEmployee 
    @FirstName VARCHAR(50), 
    @LastName VARCHAR(50), 
    @DepartmentID INT, 
    @Salary DECIMAL(10,2), 
    @JoinDate DATE 
AS 
BEGIN 
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) 
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate); 
END;

--Exercise 2: Modify Stored Procedure to Include Salary

CREATE PROCEDURE sp_GetEmployeesByDepartment 
    @DepartmentID INT 
AS 
BEGIN 
    SELECT EmployeeID, FirstName, LastName, Salary 
    FROM Employees 
    WHERE DepartmentID = @DepartmentID; 
END;

--Exercise 3: Delete a Stored Procedure

DROP PROCEDURE sp_InsertEmployee;

--Exercise 4: Execute a Stored Procedure

EXEC sp_GetEmployeesByDepartment @DepartmentID = 2;

--Exercise 5: Count Employees in a Department

CREATE PROCEDURE sp_CountEmployeesInDepartment 
    @DepartmentID INT 
AS 
BEGIN 
    SELECT COUNT(*) AS TotalEmployees 
    FROM Employees 
    WHERE DepartmentID = @DepartmentID; 
END;

--Exercise 6: Output Total Salary of a Department

CREATE PROCEDURE sp_TotalSalaryByDepartment 
    @DepartmentID INT, 
    @TotalSalary DECIMAL(10,2) OUTPUT 
AS 
BEGIN 
    SELECT @TotalSalary = SUM(Salary) 
    FROM Employees 
    WHERE DepartmentID = @DepartmentID; 
END;

DECLARE @Total DECIMAL(10,2);
EXEC sp_TotalSalaryByDepartment 2, @Total OUTPUT;
PRINT @Total;

--Exercise 7: Update Employee Salary

CREATE PROCEDURE sp_UpdateEmployeeSalary 
    @EmployeeID INT, 
    @NewSalary DECIMAL(10,2) 
AS 
BEGIN 
    UPDATE Employees 
    SET Salary = @NewSalary 
    WHERE EmployeeID = @EmployeeID; 
END;

EXEC sp_UpdateEmployeeSalary 1, 5500.00;

--Exercise 8: Give Bonus by Department
CREATE PROCEDURE sp_GiveBonus 
    @DepartmentID INT, 
    @BonusAmount DECIMAL(10,2) 
AS 
BEGIN 
    UPDATE Employees 
    SET Salary = Salary + @BonusAmount 
    WHERE DepartmentID = @DepartmentID; 
END;

EXEC sp_GiveBonus 1, 500.00;

--Exercise 9: Use Transactions

CREATE PROCEDURE sp_TransactionalUpdateSalary 
    @EmployeeID INT, 
    @NewSalary DECIMAL(10,2) 
AS 
BEGIN 
    BEGIN TRANSACTION;

    BEGIN TRY 
        UPDATE Employees 
        SET Salary = @NewSalary 
        WHERE EmployeeID = @EmployeeID;

        COMMIT;
    END TRY 
    BEGIN CATCH 
        ROLLBACK;
        THROW;
    END CATCH
END;

--Exercise 10: Use Dynamic SQL
CREATE PROCEDURE sp_GetEmployeesByDynamicFilter 
    @FilterColumn VARCHAR(50), 
    @FilterValue VARCHAR(100) 
AS 
BEGIN 
    DECLARE @SQL NVARCHAR(MAX);
    SET @SQL = 'SELECT * FROM Employees WHERE ' + QUOTENAME(@FilterColumn) + ' = @value';

    EXEC sp_executesql @SQL, N'@value VARCHAR(100)', @value = @FilterValue;
END;

--Exercise 11: Error Handling

CREATE PROCEDURE sp_SafeUpdateSalary 
    @EmployeeID INT, 
    @NewSalary DECIMAL(10,2) 
AS 
BEGIN 
    BEGIN TRY 
        UPDATE Employees 
        SET Salary = @NewSalary 
        WHERE EmployeeID = @EmployeeID;
    END TRY 
    BEGIN CATCH 
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR('Error updating salary: %s', 16, 1, @ErrorMessage);
    END CATCH
END;

