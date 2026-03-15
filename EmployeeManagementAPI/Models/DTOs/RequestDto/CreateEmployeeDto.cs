using System.ComponentModel.DataAnnotations;
using EmployeeManagementAPI.Shared.ValidationAttributes;

namespace EmployeeManagementAPI.Models.DTOs.RequestDto
{
    public class CreateEmployeeDto
    {
        [Required, MaxLength(100)] public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(100)] public string LastName { get; set; } = string.Empty;
        [Required, EmailFormat] public string Email { get; set; } = string.Empty;
        [Required] public string Phone { get; set; } = string.Empty;
        [Required] public DateOnly HireDate { get; set; }
        [Required] public decimal Salary { get; set; }
    }
}
