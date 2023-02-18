using FuelStation.Model.Enums;
using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelStation.EF.Configuration {
    public class ItemConfiguration : IEntityTypeConfiguration<Item> {
        public void Configure(EntityTypeBuilder<Item> builder) {
            builder.ToTable("Items"); // Set the name of the table

            // Set ID as the primary key
            builder.HasKey(i => i.Id);

            // Set Code as unique
            builder.HasIndex(i => i.Code).IsUnique();

            // Set properties
            builder.Property(i => i.Id).IsRequired();
            builder.Property(i => i.Code).HasColumnName("Code").HasMaxLength(50).IsRequired();
            builder.Property(i => i.Description).HasColumnName("Description").HasMaxLength(100).IsRequired();
            builder.Property(i => i.Price).HasColumnName("Price").HasPrecision(10, 2).IsRequired();
            builder.Property(i => i.Cost).HasColumnName("Cost").HasPrecision(10, 2).IsRequired();

            // Set enum mapping for ItemType
            builder.Property(i => i.ItemType).HasColumnName("ItemType").HasConversion<string>().IsRequired();
        }
    }
}