using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Model
{
    [Table("Courses")]
    public class Course
    {
        private ICollection<Student> students;

        private ICollection<Homework> homeworks;

        [Key]
        public int Id { get; set; }

        [Required, Column("Name")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Materials")]
        public string Material { get; set; }

        //EF will automatically add ParentId
        //public virtual Course Parent { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return homeworks; }
            set { homeworks = value; }
        }


        public Course()
        {
            this.students = new HashSet<Student>();
            this.homeworks = new HashSet<Homework>();
        }

        public Course(string name, string description, string material)
            : this()
        {
            this.Name = name;
            this.Description = description;
            this.Material = material;
        }
    }
}