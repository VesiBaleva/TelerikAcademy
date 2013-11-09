using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.WebServices.Models
{
    public class StudentDetails
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int Id { get; set; }

        public int Grade { get; set; }

        public int Age { get; set; }

        public int SchoolId { get; set; }

        public IEnumerable<MarkModel> Marks { get; set; }
    }
}