namespace EmployeeManagementAPI.Models.Entities
{
    public class Employee : BaseEntity
    {
        public string EmployeeId { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateOnly HireDate { get; set; }
        public decimal Salary { get; set; }
    }
}
