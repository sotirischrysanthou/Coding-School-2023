using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Configuration {
    public class AccountConfiguration : IEntityTypeConfiguration<Account> {
        public void Configure(EntityTypeBuilder<Account> builder) {
            // Set table name
            builder.ToTable("Accounts");

            // Set primary key
            builder.HasKey(a => a.Id);

            // Set properties
            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.Username).HasColumnName("Userame").IsRequired().HasMaxLength(20);
            builder.Property(a => a.Password).HasColumnName("Password").IsRequired().HasMaxLength(20);
            builder.Property(a => a.Role).HasColumnName("Role").IsRequired().HasConversion<string>();

            // Set navigation properties
            builder.HasOne(a => a.Employee)
                .WithOne(e => e.Account)
                .HasForeignKey<Account>(a => a.EmployeeId);
        }
    }
}
