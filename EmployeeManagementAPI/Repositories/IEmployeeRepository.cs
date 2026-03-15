using EmployeeManagementAPI.Models.Entities;
using EmployeeManagementAPI.Models.DTOs.RequestDto;
using EmployeeManagementAPI.Models.DTOs.ResponseDto;

namespace EmployeeManagementAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task CreateAsync(Employee request);
        Task UpdateAsync(string employeeId, UpdateEmployeeDto request);
        Task DeleteAsync(string employeeId);
        Task<GetEmployeeResponseDto?> GetByIdAsync(string employeeId);
        Task<IReadOnlyList<GetEmployeeResponseDto?>> GetAllAsync();
    }
}
