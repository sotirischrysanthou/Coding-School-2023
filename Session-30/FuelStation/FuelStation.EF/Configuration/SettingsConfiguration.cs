using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Configuration {
    public class SettingsConfiguration : IEntityTypeConfiguration<Settings> {
        public void Configure(EntityTypeBuilder<Settings> builder) {
            // Set table name
            builder.ToTable("Settings");

            // Set primary key
            builder.HasKey(s => s.Id);
        }
    }
}
