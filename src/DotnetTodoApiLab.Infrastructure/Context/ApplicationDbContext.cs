using Microsoft.EntityFrameworkCore;
using DotnetTodoApiLab.Domain.Entities;
using DotnetTodoApiLab.Infrastructure.Configuration;

namespace DotnetTodoApiLab.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Task> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }
    }
}
