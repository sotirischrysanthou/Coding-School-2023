using FuelStation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelStation.EF.Configuration {
    public class TransactionLineConfiguration : IEntityTypeConfiguration<TransactionLine> {
        public void Configure(EntityTypeBuilder<TransactionLine> builder) {
            // Set table name
            builder.ToTable("TransactionLines");

            // Set primary key
            builder.HasKey(t => t.Id);

            // Set properties
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Quantity).HasColumnName("Quantity").IsRequired();
            builder.Property(t => t.ItemPrice).HasColumnName("ItemPrice").HasPrecision(10, 2).IsRequired();
            builder.Property(t => t.NetValue).HasColumnName("NetValue").HasPrecision(10, 2).IsRequired();
            builder.Property(t => t.DiscountPercent).HasColumnName("DiscountPercent").HasPrecision(4, 2).IsRequired();
            builder.Property(t => t.DiscountValue).HasColumnName("DiscountValue").HasPrecision(10, 2).IsRequired();
            builder.Property(t => t.TotalValue).HasColumnName("TotalValue").HasPrecision(10, 2).IsRequired();

            // Set navigation properties
            builder.HasOne(t => t.Transaction)
                .WithMany(t => t.TransactionLines)
                .HasForeignKey(t => t.TransactionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.HasOne(t => t.Item)
                .WithMany(i => i.TransactionLines)
                .HasForeignKey(t => t.ItemId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}