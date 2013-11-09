using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _01.SortedCoursesWithStudents
{
    public class CoursesStudents
    {
        public static void Main()
        {
            List<string[]> students = ReadData();
            OrderedMultiDictionary<string, Student> byCourse = new OrderedMultiDictionary<string, Student>(true);
            foreach (var student in students)
            {
                Student st = new Student(student[0], student[1]);
                byCourse.Add(student[2], st);
            }

            foreach (var student in byCourse)
            {
                Console.WriteLine(string.Format("{0}: {1}", student.Key, string.Join(", ", student.Value)));
            }
        }

        private static List<string[]> ReadData()
        {
            List<string[]> students = new List<string[]>();

            string inputText;

            StreamReader sr = new StreamReader(@"../../students.txt");
            using (sr)
            {
                while (sr.Peek() >= 0)
                {
                    inputText = sr.ReadLine();
                    var student = inputText.Split(new char[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    students.Add(student);
                }
            }

            return students;
        }
    }
}
