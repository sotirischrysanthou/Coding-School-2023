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
            builder.Property(a => a.Id).HasColumnName("ID").IsRequired();
            builder.Property(a => a.Username).HasColumnName("Userame").IsRequired().HasMaxLength(20);
            builder.Property(c => c.Password).HasColumnName("Password").IsRequired().HasMaxLength(20);
            builder.Property(c => c.Role).HasColumnName("Role").IsRequired().HasConversion<string>();

            // Set navigation properties
            builder.HasOne(a => a.Employee)
                .WithOne(e => e.Account)
                .HasForeignKey<Account>(a => a.EmployeeId);
        }
    }
}
