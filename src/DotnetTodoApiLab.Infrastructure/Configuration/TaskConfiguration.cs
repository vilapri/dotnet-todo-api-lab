using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetTodoApiLab.Infrastructure.Configuration
{
    internal class TaskConfiguration : IEntityTypeConfiguration<DotnetTodoApiLab.Domain.Entities.Task>
    {
        public void Configure(EntityTypeBuilder<DotnetTodoApiLab.Domain.Entities.Task> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(254);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Description).HasMaxLength(2048);

            //builder.HasData(
            //    new Domain.Entities.Task()
            //    {
            //        Id = new Guid("687d9fd5-2752-4a96-93d5-0f33a59913c6"),
            //        Name = "Task 1 test",
            //        Description = "Default task 1"
            //    },
            //    new Domain.Entities.Task()
            //    {
            //        Id = new Guid("687d4fd5-2752-4a96-93d5-0f33a59913c7"),
            //        Name = "Task 2 test",
            //        Description = "Default task 2"
            //    }
            //);
        }

    }
}
