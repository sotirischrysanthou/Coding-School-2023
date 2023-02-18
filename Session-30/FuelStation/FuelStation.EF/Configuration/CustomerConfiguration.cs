using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelStation.EF.Configuration {

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer> {
        public void Configure(EntityTypeBuilder<Customer> builder) {
            // Set table name
            builder.ToTable("Customers");

            // Set primary key
            builder.HasKey(c => c.Id);

            // Set properties
            builder.Property(c => c.Id).HasColumnName("ID").IsRequired();
            builder.Property(c => c.Name).HasColumnName("Name").IsRequired().HasMaxLength(50);
            builder.Property(c => c.Surname).HasColumnName("Surname").IsRequired().HasMaxLength(50);
            builder.Property(c => c.CardNumber).HasColumnName("CardNumber").IsRequired().HasMaxLength(10);

            // Set the maximum length of the CardNumber column to 20
            builder.Property(c => c.CardNumber)
                .HasMaxLength(20);

            // Add a check constraint to the CardNumber column to ensure that it starts with the letter 'A'
            String checkConstraint = "CardNumber LIKE 'A%'";
            builder.ToTable(t => t.HasCheckConstraint("CK_CardNumber_StartsWith_A", checkConstraint));

            //// Set navigation properties
            //builder.HasMany(c => c.Transactions)
            //       .WithOne(t => t.Customer)
            //       .HasForeignKey(t => t.CustomerID)
            //       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
