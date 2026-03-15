CREATE OR ALTER PROCEDURE usp_Employee_GetById
(
	@EmployeeId NVARCHAR(36)
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT EmployeeId, FirstName, LastName, Email, Phone, HireDate, Salary, IsActive, CreatedAt, UpdatedAt
	FROM Employees
	WHERE EmployeeId = @EmployeeId AND IsDeleted = 0;

END

