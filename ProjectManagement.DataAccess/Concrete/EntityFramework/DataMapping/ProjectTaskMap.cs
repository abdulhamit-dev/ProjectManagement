using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DataAccess.Concrete.EntityFramework.DataMapping
{
    public class ProjectTaskMap : IEntityTypeConfiguration<ProjectTask>
    {
        public void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x=>x.UserId).IsRequired();
            builder.Property(x=>x.CreatedUserId).IsRequired();
            builder.Property(x=>x.ProjectId).IsRequired();
            builder.Property(x=>x.CreatedDate).IsRequired();
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(100);
        }
    }
}
