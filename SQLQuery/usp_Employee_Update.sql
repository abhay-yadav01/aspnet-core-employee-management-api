CREATE OR ALTER PROCEDURE usp_Employee_Update
(
    @EmployeeId NVARCHAR(36),

    @FirstName  NVARCHAR(100) = NULL,
    @LastName   NVARCHAR(100) = NULL,
    @Phone      NVARCHAR(20)  = NULL,
    @Salary     DECIMAL(18,2) = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Employees WHERE EmployeeId = @EmployeeId AND IsDeleted = 0)
        THROW 50001, 'Employee not found or has been deleted.', 1;

    UPDATE Employees
    SET
        FirstName = ISNULL(@FirstName, FirstName),
        LastName  = ISNULL(@LastName,  LastName),
        Phone     = ISNULL(@Phone,     Phone),
        Salary    = ISNULL(@Salary,    Salary),
        UpdatedAt = GETUTCDATE()
    WHERE EmployeeId = @EmployeeId AND IsDeleted = 0;

END
