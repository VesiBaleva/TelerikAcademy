using StudentSystem.Model;
using System;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace StudentSystem.Data
{
    public class StudentMappings : EntityTypeConfiguration<Student>
    {
        public StudentMappings()
        {
            this.HasKey(s => s.StudentID);
            this.Property(s => s.StudentID).HasColumnName("ID");

            this.Property(s => s.Name)
                .IsUnicode(true)
                .HasColumnName("Name")
                .HasMaxLength(80);

            this.Property(s => s.Number)
                .IsRequired()
                .HasColumnName("Number");
        }
    }
}