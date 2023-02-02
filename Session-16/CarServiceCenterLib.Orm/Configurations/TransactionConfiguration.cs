using CarServiceCenterLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Orm.Configurations {
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction> {
        public void Configure(EntityTypeBuilder<Transaction> builder) {
            builder.ToTable("Transactions");
            builder.HasKey(transaction => transaction.ID);
            //builder.HasMany(transaction => transaction.TransactionLines)
            //    .WithOne(transactionLine => transactionLine.Transaction)
            //    .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
