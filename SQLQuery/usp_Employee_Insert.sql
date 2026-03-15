CREATE OR ALTER PROCEDURE usp_Employee_Insert
(
    @EmployeeId NVARCHAR(36),
    @FirstName  NVARCHAR(100),
    @LastName   NVARCHAR(100),
    @Email      NVARCHAR(150),
    @Phone      NVARCHAR(20),
    @HireDate   DATE,
    @Salary     DECIMAL(18,2)
)
AS
BEGIN
    SET NOCOUNT ON;

	INSERT INTO Employees
	(
		EmployeeId, FirstName, LastName, Email, Phone, HireDate, Salary, IsActive, IsDeleted, CreatedAt
	) 
	VALUES 
	(
        @EmployeeId, @FirstName, @LastName, @Email, @Phone, @HireDate, @Salary, 1, 0, GETUTCDATE()
	);
END
