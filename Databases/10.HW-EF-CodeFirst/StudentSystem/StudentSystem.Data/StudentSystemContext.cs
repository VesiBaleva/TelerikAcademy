using StudentSystem.Model;
using System;
using System.Data.Entity;

namespace StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("StudentSystemDB")
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<Course>().Property(x => x.Description).HasMaxLength(150);
            modelBuilder.Entity<Course>().Property(x => x.Material).HasMaxLength(100);

            //* OR *//
            modelBuilder.Configurations.Add(new StudentMappings()); // Create separate class file with Students Annotate Attributes

            base.OnModelCreating(modelBuilder);
        }
    }
}