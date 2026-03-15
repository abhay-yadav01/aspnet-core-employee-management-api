namespace EmployeeManagementAPI.Models.DTOs.RequestDto
{
    public class UpdateEmployeeDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public decimal? Salary { get; set; }
    }
}
