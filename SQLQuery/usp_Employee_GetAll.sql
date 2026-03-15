CREATE OR ALTER PROCEDURE usp_Employee_GetAll
AS
BEGIN
	SET NOCOUNT ON;

	SELECT EmployeeId, FirstName, LastName, Email, Phone, HireDate, Salary, IsActive, CreatedAt, UpdatedAt
	FROM Employees
	ORDER BY FirstName

END
