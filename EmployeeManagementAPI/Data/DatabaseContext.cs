using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Models.Entities;
using EmployeeManagementAPI.Models.Configurations;

namespace EmployeeManagementAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }

        // Apply entity configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}
