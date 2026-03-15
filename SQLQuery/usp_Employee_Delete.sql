CREATE OR ALTER PROCEDURE usp_Employee_Delete
(
	@EmployeeId NVARCHAR(36)
)
AS
BEGIN
	SET NOCOUNT ON;

    IF NOT EXISTS(SELECT 1 FROM Employees WHERE EmployeeId = @EmployeeId AND IsActive = 1)
        THROW 50001, 'Employee NotFound or Is Deleted', 1;

	UPDATE Employees
    SET
        IsActive = 0,
        IsDeleted = 1,
        DeletedAt = GETUTCDATE()
    WHERE EmployeeId = @EmployeeId AND IsDeleted = 0;

END
