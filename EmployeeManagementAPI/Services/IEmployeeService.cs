using EmployeeManagementAPI.Models.DTOs.RequestDto;
using EmployeeManagementAPI.Models.DTOs.ResponseDto;

namespace EmployeeManagementAPI.Services
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(CreateEmployeeDto request);
        Task UpdateEmployeeAsync(string employeeId, UpdateEmployeeDto request);
        Task DeleteEmployeeAsync(string employeeId);
        Task<GetEmployeeResponseDto?> GetByIdAsync(string employeeId);
        Task<IReadOnlyList<GetEmployeeResponseDto?>> GetAllEmployeesAsync();
    }
}
