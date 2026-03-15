using EmployeeManagementAPI.Repositories;
using EmployeeManagementAPI.Models.Entities;
using EmployeeManagementAPI.Models.DTOs.RequestDto;
using EmployeeManagementAPI.Models.DTOs.ResponseDto;

namespace EmployeeManagementAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly ILogger<EmployeeService> _logger;
        public EmployeeService(IEmployeeRepository repository, ILogger<EmployeeService> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        // ---------- CREATE ---------- 
        public async Task CreateEmployeeAsync(CreateEmployeeDto request)
        {
            try
            {
                _logger.LogInformation("Creating employee with email {Email}", request.Email);

                Employee employee = new Employee()
                {
                    EmployeeId = Guid.NewGuid().ToString(),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Phone = request.Phone,
                    HireDate = request.HireDate,
                    Salary = request.Salary,
                };

                await _repository.CreateAsync(employee);

                _logger.LogInformation("Employee created successfully with Id {EmployeeId} and email {Email}", employee.EmployeeId, employee.Email);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating employee with email {Email}", request.Email);

                throw;
            }
        }


        // ---------- UPDATE ---------- 
        public async Task UpdateEmployeeAsync(string employeeId, UpdateEmployeeDto request)
        {
            try
            {
                _logger.LogInformation("Updating EmployeeId: {EmployeeId}", employeeId);

                await _repository.UpdateAsync(employeeId, request);

                _logger.LogInformation("Updated successfully EmployeeId: {EmployeeId}", employeeId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating employee with EmployeeId: {EmployeeId}", employeeId);
                throw;
            }
        }


        // ---------- DELETE ---------- 
        public async Task DeleteEmployeeAsync(string employeeId)
        {
            try
            {
                _logger.LogInformation("Deleting employee with EmployeeId: {EmployeeId}", employeeId);

                await _repository.DeleteAsync(employeeId);

                _logger.LogInformation("Employee deleted successfully with EmployeeId: {EmployeeId}", employeeId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting employee with EmployeeId: {EmployeeId}", employeeId);
                throw;
            }
        }


        // ---------- GET BY EMPLOYEEID ---------- 
        public async Task<GetEmployeeResponseDto?> GetByIdAsync(string employeeId)
        {
            try
            {
                _logger.LogInformation("Fetching employee details for EmployeeId {EmployeeId}", employeeId);

                var result = await _repository.GetByIdAsync(employeeId);

                if (result == null)
                {
                    _logger.LogWarning("Employee not found for EmployeeId {EmployeeId}", employeeId);
                    throw new KeyNotFoundException($"Employee with ID '{employeeId}' not found.");
                }

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while geting employee with EmployeeId: {EmployeeId}", employeeId);
                throw;
            }
        }


        // ---------- GET ALL ---------- 
        public async Task<IReadOnlyList<GetEmployeeResponseDto?>> GetAllEmployeesAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all employees");

                var result = await _repository.GetAllAsync();

                if (result == null || !result.Any())
                {
                    _logger.LogWarning("No employees found in database");
                    throw new KeyNotFoundException("No employees found.");
                }

                _logger.LogInformation("Retrieved {Count} employees from database", result.Count);

                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all employees.");
                throw;
            }
        }
    }
}
