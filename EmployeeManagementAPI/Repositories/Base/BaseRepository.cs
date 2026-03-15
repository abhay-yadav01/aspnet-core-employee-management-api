using System.Data;
using Microsoft.Data.SqlClient;
using EmployeeManagementAPI.Models.DTOs.ResponseDto;

namespace EmployeeManagementAPI.Repositories.Base
{
    public abstract class BaseRepository
    {
        protected readonly string _connectionString;

        protected BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ---------- PRIVATE HELPERS ---------- 

        // Helper 1 — Create Command
        protected SqlCommand CreateCommand(string storedProcedure, SqlConnection connection)
        {
            var command = new SqlCommand(storedProcedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }


        // Helper 2 — Execute Non Query
        protected async Task ExecuteNonQueryAsync(SqlCommand command)
        {
            await command.Connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }


        //Helper 3 — Map Employee
        protected static GetEmployeeResponseDto MapEmployee(SqlDataReader reader)
        {
            return new GetEmployeeResponseDto
            {
                EmployeeId = reader.GetString(reader.GetOrdinal("EmployeeId")),
                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                Email = reader.GetString(reader.GetOrdinal("Email")),
                Phone = reader.GetString(reader.GetOrdinal("Phone")),
                HireDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("HireDate"))),
                Salary = reader.GetDecimal(reader.GetOrdinal("Salary")),
                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                UpdatedAt = reader.IsDBNull(reader.GetOrdinal("UpdatedAt")) ? null : reader.GetDateTime(reader.GetOrdinal("UpdatedAt"))
            };
        }
    }
}
