using StudentSystem.Data;
using StudentSystem.Model;
using System;
using System.Collections;
using System.Data.Entity;
using System.Collections.Generic;
using StudentSystem.Data.Migrations;

namespace StudentSystem.ConsoleClient
{
    public class Program
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion
                <StudentSystemContext, Configuration>());

            StudentSystemContext db = new StudentSystemContext();

            Student student = new Student
            {
                Name = "Dimitar",
                Number = 1212
            };

            db.Students.Add(student);

            Student student2 = new Student("Ivan", 1554);
            db.Students.Add(student2);

            Course course = new Course("C#PartII", "C# advanced course", "C# Book");
            db.Courses.Add(course);

            db.SaveChanges();
        }
    }
}