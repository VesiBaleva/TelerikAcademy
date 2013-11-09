using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentSystem.Model
{
    [Table("Homeworks")]
    public class Homework
    {
        [Key, Column("HomeworkId")]
        public int HomeworkId { get; set; }

        [Required, Column("Content")]
        public string Content { get; set; }

        [Column("TimeSent")]
        public DateTime TimeSent { get; set; }

        [Column("Course"), ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Column("Student"), ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}