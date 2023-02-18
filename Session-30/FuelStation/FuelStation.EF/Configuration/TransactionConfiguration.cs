using FuelStation.EF.Configuration;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelStation.EF.Configuration {
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction> {
        public void Configure(EntityTypeBuilder<Transaction> builder) {
            // Set table name
            builder.ToTable("Transactions");

            // Set primary key
            builder.HasKey(t => t.Id);

            // Set properties
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Date).HasColumnName("Date").IsRequired();
            builder.Property(t => t.EmployeeId).HasColumnName("EmployeeId").IsRequired();
            builder.Property(t => t.CustomerId).HasColumnName("CustomerId").IsRequired();
            builder.Property(t => t.TotalValue).HasColumnName("TotalValue").HasPrecision(10, 2).IsRequired();

            // Set enum mapping for PaymentType
            builder.Property(t => t.PaymentMethod).HasConversion<string>().IsRequired();

            // Set navigation properties
            builder.HasOne(t => t.Customer)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Employee)
                .WithMany(e => e.Transactions)
                .HasForeignKey(t => t.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
