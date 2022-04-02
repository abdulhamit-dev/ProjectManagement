using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectManagement.DataAccess.Concrete.EntityFramework.DataMapping;
using ProjectManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DataAccess.Concrete.EntityFramework.Contexts
{
    public class ProjectManagementContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DbProjectManagement");
            optionsBuilder.UseSqlServer(connectionString, providerOptions => { providerOptions.EnableRetryOnFailure(); });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeamMap());
            modelBuilder.ApplyConfiguration(new ProjectMap());
            modelBuilder.ApplyConfiguration(new ProjectTaskMap());
            modelBuilder.ApplyConfiguration(new SubTaskMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
            modelBuilder.ApplyConfiguration(new RoleMap());

            modelBuilder.Entity<Team>().HasData(new Team { Id = 1, IsActive = true, Name = "admin" });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id=1,
                Email="test@gmail.com",
                FullName="admin admin",
                UserName="admin",
                Password="123",
                IsActive=true,
                TeamId=1
            });
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

    }
}
