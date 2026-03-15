using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Shared.ValidationAttributes
{
    public class EmailFormatAttribute : ValidationAttribute
    {
        // custom validation heart
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("The Email field is required.");
            }

            string? email = value.ToString();

            // Simple regex for email validation
            // Note : emailPattern :- username + @ + domain + . + extension
            var emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(email!, emailPattern))
            {
                return new ValidationResult("Invalid email format. Example: example@test.com");
            }
            return ValidationResult.Success;
        }
    }
}
