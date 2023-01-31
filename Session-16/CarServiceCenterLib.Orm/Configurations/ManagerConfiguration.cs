using CarServiceCenterLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Orm.Configurations {
    internal class ManagerConfiguration : IEntityTypeConfiguration<Manager> {
        public void Configure(EntityTypeBuilder<Manager> builder) {
            builder.ToTable("Managers");
            builder.HasKey(managers => managers.ID);
            builder.Property(managers => managers.Name).HasMaxLength(50);
            builder.Property(managers => managers.Surname).HasMaxLength(50);
            builder.HasMany(manager => manager.Engineers)
                .WithOne(engineer => engineer.Manager)
                .HasForeignKey(engineer => engineer.ManagerID);
        }
    }
}
