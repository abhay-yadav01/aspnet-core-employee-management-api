using System.Data;
using Microsoft.Data.SqlClient;
using EmployeeManagementAPI.Models.Entities;
using EmployeeManagementAPI.Repositories.Base;
using EmployeeManagementAPI.Models.DTOs.RequestDto;
using EmployeeManagementAPI.Models.DTOs.ResponseDto;

namespace EmployeeManagementAPI.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(IConfiguration configuration, ILogger<EmployeeRepository> logger) : base(configuration.GetConnectionString("DefaultConnection")!)
        {
            _logger = logger;
        }


        // ---------- INSERT EMPLOYEE ----------
        public async Task CreateAsync(Employee request)
        {
            _logger.LogInformation("Executing 'usp_Employee_Insert' & Inserting employee | Email: {Email}", request.Email);

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = CreateCommand("usp_Employee_Insert", connection);

            command.Parameters.Add("@EmployeeId", SqlDbType.NVarChar, 36).Value = request.EmployeeId;
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = request.FirstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = request.LastName;
            command.Parameters.Add("@Email", SqlDbType.NVarChar, 150).Value = request.Email;
            command.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = request.Phone;
            command.Parameters.Add("@HireDate", SqlDbType.Date).Value = request.HireDate;
            command.Parameters.Add("@Salary", SqlDbType.Decimal).Value = request.Salary;

            await ExecuteNonQueryAsync(command);

            _logger.LogInformation("Employee inserted successfully | Email: {Email}", request.Email);
        }


        // ---------- UPDATE EMPLOYEE ----------
        public async Task UpdateAsync(string employeeId, UpdateEmployeeDto request)
        {
            _logger.LogInformation("Executing 'usp_Employee_Update' & Updating employee | EmployeeId {EmployeeId}", employeeId);

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = CreateCommand("usp_Employee_Update", connection);

            command.Parameters.Add("@EmployeeId", SqlDbType.NVarChar, 36).Value = employeeId;

            command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value =
                string.IsNullOrWhiteSpace(request.FirstName) ? (object)DBNull.Value : request.FirstName.Trim();

            command.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value =
                string.IsNullOrWhiteSpace(request.LastName) ? (object)DBNull.Value : request.LastName.Trim();

            command.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value =
                string.IsNullOrWhiteSpace(request.Phone) ? (object)DBNull.Value : request.Phone.Trim();

            command.Parameters.Add("@Salary", SqlDbType.Decimal).Value =
                request.Salary.HasValue ? (object)request.Salary.Value : DBNull.Value;

            await ExecuteNonQueryAsync(command);

            _logger.LogInformation("Employee updated successfully | EmployeeId {EmployeeId}", employeeId);
        }


        // ---------- DELETE EMPLOYEE ----------
        public async Task DeleteAsync(string employeeId)
        {
            _logger.LogInformation("Executing 'usp_Employee_Delete' & Deleting employee | EmployeeId {EmployeeId}", employeeId);

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = CreateCommand("usp_Employee_Delete", connection);

            command.Parameters.Add("@EmployeeId", SqlDbType.NVarChar, 36).Value = employeeId;

            await ExecuteNonQueryAsync(command);

            _logger.LogInformation("Employee deleted successfully | EmployeeId {EmployeeId}", employeeId);
        }


        // ---------- GET EMPLOYEE BY ID ----------
        public async Task<GetEmployeeResponseDto?> GetByIdAsync(string employeeId)
        {
            _logger.LogInformation("Executing 'usp_Employee_GetById' & Fetching employee | EmployeeId {EmployeeId}", employeeId);

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = CreateCommand("usp_Employee_GetById", connection);

            command.Parameters.Add("@EmployeeId", SqlDbType.NVarChar, 36).Value = employeeId;

            await connection.OpenAsync();

            using SqlDataReader reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return MapEmployee(reader);

            return null;
        }


        // ---------- GET ALL EMPLOYEE ----------
        public async Task<IReadOnlyList<GetEmployeeResponseDto?>> GetAllAsync()
        {
            _logger.LogInformation("Executing 'usp_Employee_GetAll' & Fetching all employees");

            var employees = new List<GetEmployeeResponseDto>();

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = CreateCommand("usp_Employee_GetAll", connection);

            await connection.OpenAsync();

            using SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
                employees.Add(MapEmployee(reader));

            return employees;
        }
    }
}
