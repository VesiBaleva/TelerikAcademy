using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Model
{
    [Table("Students")]
    public class Student
    {
        private ICollection<Course> courses;

        private ICollection<Homework> homeworks;

        [Key, Column("StudentID")]
        public int StudentID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Required, Column("Number")]
        public int Number { get; set; }

        public ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        public Student(string name, int number)
            : this()
        {
            this.Name = name;
            this.Number = number;
        }

    }
}