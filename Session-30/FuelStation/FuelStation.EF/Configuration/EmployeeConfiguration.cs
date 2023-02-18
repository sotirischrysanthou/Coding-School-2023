using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelStation.EF.Configuration {
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee> {
        public void Configure(EntityTypeBuilder<Employee> builder) {
            // Set table name
            builder.ToTable("Employees");

            // Set primary key
            builder.HasKey(e => e.Id);

            // Set properties
            builder.Property(e => e.Id).HasColumnName("ID").IsRequired();
            builder.Property(e => e.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            builder.Property(e => e.Surname).HasColumnName("Surname").IsRequired().HasMaxLength(50);
            builder.Property(e => e.HireDateStart).HasColumnName("HireDateStart").IsRequired();
            builder.Property(e => e.HireDateEnd).HasColumnName("HireDateEnd");
            builder.Property(e => e.SalaryPerMonth).HasColumnName("SalaryPerMonth").HasPrecision(10,2).IsRequired();
            builder.Property(e => e.EmployeeType).HasColumnName("EmployeeType").IsRequired().HasConversion<string>();

            // Set enum mapping for EmployeeType
            builder.Property(e => e.EmployeeType)
                .HasColumnName("EmployeeType")
                .HasConversion<string>()
                .IsRequired();

            //// Set navigation properties
            //builder.HasMany(e => e.Transactions)
            //       .WithOne(t => t.Employee)
            //       .HasForeignKey(t => t.EmployeeID)
            //       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}