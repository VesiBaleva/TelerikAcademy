namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentSystem.Model;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // Allow Data loss, must be removed when database is ready
            //this.AutomaticMigrationDataLossAllowed = true; 
        }

        protected override void Seed(StudentSystem.Data.StudentSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.Students.AddOrUpdate(
              p => p.Name,
              new Student
              {
                  Name = "Andrew Peters",
                  Number = 1000
              });

        }
    }
}