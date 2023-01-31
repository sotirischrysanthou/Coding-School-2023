using CarServiceCenterLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceCenterLib.Orm.Configurations {
    public class ServiceTaskConfiguration : IEntityTypeConfiguration<ServiceTask> {
        public void Configure(EntityTypeBuilder<ServiceTask> builder) {
            builder.ToTable("ServiceTasks");
            builder.HasKey(serviceTask => serviceTask.ID);
            builder.Property(serviceTask => serviceTask.Description).HasMaxLength(100);
        }
    }
}
