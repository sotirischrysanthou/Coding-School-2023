using CarServiceCenterLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Orm.Configurations {
    public class CarConfiguration : IEntityTypeConfiguration<Car> {
        public void Configure(EntityTypeBuilder<Car> builder) {
            builder.ToTable("Cars");
            builder.HasKey(car => car.ID);
            builder.Property(car => car.Brand).HasMaxLength(50);
            builder.Property(car => car.Model).HasMaxLength(50);
            builder.Property(car => car.CarRegistrationNumber).HasMaxLength(8);
            
            // Relations
            //              Transactions
            //builder.HasMany(car => car.Transactions)
            //    .WithOne(transaction => transaction.Car)
            //    .HasForeignKey(transaction => transaction.CarID);

        }
    }
}
