using System;
using System.Linq;

namespace _01.SortedCoursesWithStudents
{
    public class Student:IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student(string fname, string lname)
        {
            this.FirstName = fname;
            this.LastName = lname;
        }

        public override string ToString()
        {
            string str = string.Format("{0} {1}", this.FirstName, this.LastName);
            return str;
        }

        public int CompareTo(object obj)
        {
            if (obj is Student)
            {
                var student = (Student)obj;

                if (this.LastName.CompareTo(student.LastName) > 0)
                {
                    return 1;
                }
                else if (this.LastName.CompareTo(student.LastName) < 0)
                {
                    return -1;
                }
                else
                {
                    if (this.FirstName.CompareTo(student.FirstName) > 0)
                    {
                        return 1;
                    }
                    else if (this.FirstName.CompareTo(student.FirstName) < 0)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            throw new NotImplementedException();
        }
    }
}
