using Microsoft.EntityFrameworkCore;
using EmployeeManagementAPI.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementAPI.Models.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(e => e.EmployeeId);

            builder.Property(e => e.EmployeeId)
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasIndex(e => e.Email)
                .IsUnique();

            builder.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.HireDate)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(e => e.Salary)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
