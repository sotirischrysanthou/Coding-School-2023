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
            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            builder.Property(e => e.Name).HasColumnName("Name").IsRequired().HasMaxLength(20);
            builder.Property(e => e.Surname).HasColumnName("Surname").IsRequired().HasMaxLength(20);
            builder.Property(e => e.HireDateStart).HasColumnName("HireDateStart").IsRequired();
            builder.Property(e => e.HireDateEnd).HasColumnName("HireDateEnd");
            builder.Property(e => e.SalaryPerMonth).HasColumnName("SalaryPerMonth").HasPrecision(10,2).IsRequired();
            builder.Property(e => e.EmployeeType).HasColumnName("EmployeeType").IsRequired().HasConversion<string>();

            // Set enum mapping for EmployeeType
            builder.Property(e => e.EmployeeType)
                .HasColumnName("EmployeeType")
                .HasConversion<string>()
                .IsRequired();

            // Set navigation properties
            builder.HasOne(e => e.Account)
                   .WithOne(a => a.Employee)
                   .HasForeignKey<Employee>(e => e.AccountId);
        }
    }
}