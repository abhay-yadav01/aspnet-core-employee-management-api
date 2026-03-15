using Microsoft.AspNetCore.Mvc;
using EmployeeManagementAPI.Services;
using EmployeeManagementAPI.Models.DTOs.RequestDto;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeService _services;
        private readonly ILogger<EmployeesController> _logger;
        public EmployeesController(IEmployeeService services, ILogger<EmployeesController> logger)
        {
            _services = services;
            _logger = logger;
        }


        // ---------- INSERT ---------- 
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] CreateEmployeeDto createDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid employee creation request received for email {Email}", createDto?.Email);
                return BadRequest(ModelState);
            }

            _logger.LogInformation("Employee creation started for email {Email}", createDto.Email);

            await _services.CreateEmployeeAsync(createDto);

            _logger.LogInformation("Employee created successfully for email {Email}", createDto.Email);

            return CreateResponse("Employee Account created successfully!");
        }


        // ---------- UPDATE ----------
        [HttpPatch("{employeeId}")]
        public async Task<IActionResult> UpdateAsync(string employeeId, [FromBody] UpdateEmployeeDto updateDto)
        {
            if (string.IsNullOrWhiteSpace(employeeId))
                return BadRequestResponse("Employee ID is required.");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid employee update request received for EmployeeId {EmployeeId}", employeeId);
                return BadRequest(ModelState);
            }

            _logger.LogInformation("Update started for EmployeeId {EmployeeId}", employeeId);

            await _services.UpdateEmployeeAsync(employeeId, updateDto);

            _logger.LogInformation("Update completed for EmployeeId {EmployeeId}", employeeId);

            return OkResponse("Employee details updated successfully!");
        }


        // ---------- DELETE BY EMPLOYEEID ---------- 
        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteAsync(string employeeId)
        {
            if (string.IsNullOrWhiteSpace(employeeId))
            {
                _logger.LogWarning("Delete request received with empty EmployeeId");
                return BadRequestResponse("employeeId is required for deletion");
            }

            _logger.LogInformation("Employee deletion started for EmployeeId {EmployeeId}", employeeId);

            await _services.DeleteEmployeeAsync(employeeId);

            _logger.LogInformation("Employee deleted successfully for EmployeeId {EmployeeId}", employeeId);

            return OkResponse("Employee deleted successfully!");
        }


        // ---------- GET BY EMPLOYEEID ---------- 
        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetByIdAsync(string employeeId)
        {
            if (string.IsNullOrWhiteSpace(employeeId))
            {
                _logger.LogWarning("Get employee request received with empty EmployeeId");
                return BadRequestResponse("Employee ID is required.");
            }

            _logger.LogInformation("Fetching employee details for EmployeeId {EmployeeId}", employeeId);

            var response = await _services.GetByIdAsync(employeeId);

            if (response == null)
            {
                _logger.LogWarning("Employee not found for EmployeeId {EmployeeId}", employeeId);
                return NotFoundResponse("Employee not found.");
            }

            _logger.LogInformation("Employee retrieved successfully for EmployeeId {EmployeeId}", employeeId);

            return OkResponse("Employee retrieved successfully.", response);

        }


        // ---------- GET ALL ---------- 
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            _logger.LogInformation("Fetching all employees");

            var response = await _services.GetAllEmployeesAsync();

            _logger.LogInformation("Total employees retrieved: {Count}", response.Count());

            return OkResponse("Employees retrieved successfully.", response);
        }
    }
}
