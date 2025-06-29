DECLARE @Total DECIMAL(10,2);
EXEC sp_TotalSalaryByDepartment 2, @Total OUTPUT;
PRINT @Total;