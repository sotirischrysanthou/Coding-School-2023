using CarServiceCenter.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarServiceCenter.EF.Configurations
{
    public class TransactionLineConfiguration : IEntityTypeConfiguration<TransactionLine>
    {
        public void Configure(EntityTypeBuilder<TransactionLine> builder)
        {
            // Table Name
            builder.ToTable("TransactionLines");

            // Primary Key
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            // Properties
            builder.Property(t => t.Hours).HasPrecision(3, 2).IsRequired();
            builder.Property(t => t.PricePerHour).HasPrecision(3, 2).IsRequired();
            builder.Property(t => t.Price).HasPrecision(9, 2).IsRequired();

            // Relations
            builder.HasOne(t => t.Transaction)
                .WithMany(t => t.TransactionLines)
                .HasForeignKey(t => t.TransactionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.ServiceTask)
                .WithMany(t => t.TransactionLines)
                .HasForeignKey(t => t.ServiceTaskId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Engineer)
                .WithMany(t => t.TransactionLines)
                .HasForeignKey(t => t.EngineerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
