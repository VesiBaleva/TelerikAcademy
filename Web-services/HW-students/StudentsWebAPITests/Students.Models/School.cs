using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Students.Models
{
    public class School
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public School()
        {
            this.Students = new HashSet<Student>();
        }
    }
}
