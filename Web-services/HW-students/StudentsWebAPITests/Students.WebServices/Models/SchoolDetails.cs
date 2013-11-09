using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.WebServices.Models
{
    public class SchoolDetails
    {
        public int Id { get; set; }

        public string Location { get; set; }

        public string Name { get; set; }

        public IEnumerable<StudentDetails> Students { get; set; }
    }
}