using System;
using Microsoft.EntityFrameworkCore;
namespace DMAWS_T2204M_TrungKien.Models

{
	public partial class ProjectContext : DbContext
	{
        public static string ConnectionString;

        public ProjectContext(DbContextOptions<ProjectContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<ProjectEmployee> ProjectEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

