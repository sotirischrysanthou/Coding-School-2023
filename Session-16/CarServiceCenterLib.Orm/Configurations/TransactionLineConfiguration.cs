﻿using CarServiceCenterLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Orm.Configurations {
    public class TransactionLineConfiguration : IEntityTypeConfiguration<TransactionLine> {
        public void Configure(EntityTypeBuilder<TransactionLine> builder) {
            builder.ToTable("TransactionLines");
            builder.HasKey(transactionLine => transactionLine.ID);
            builder.HasOne(transactionLine => transactionLine.Transaction)
                .WithMany(transaction => transaction.TransactionLines)
                .HasForeignKey(transactionLine => transactionLine.TransactionID);
            builder.HasOne(transactionLine => transactionLine.Engineer)
                .WithMany(engineer => engineer.TransactionLines)
                .HasForeignKey(transactionLine => transactionLine.EngineerID);
            builder.HasOne(transactionLine => transactionLine.ServiceTask)
                .WithMany(serviceTask => serviceTask.TransactionLines)
                .HasForeignKey(transactionLine => transactionLine.ServiceTaskID);
        }
    }
}
