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
            builder.HasKey(cars => cars.ID);
            builder.Property(cars => cars.Brand).HasMaxLength(50);
            builder.Property(cars => cars.Model).HasMaxLength(50);
            builder.Property(cars => cars.CarRegistrationNumber).HasMaxLength(8);

        }
    }
}
