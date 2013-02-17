using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        static Dictionary<string[], string> employeesPosition = new Dictionary<string[], string>();
        static Dictionary<string, int> positionsRating = new Dictionary<string, int>();
        static char[] separators = {'-'};

        static void Main(string[] args)
        {
            FillPositionsRating();
            FillEmployeesPositions();
            var sortedDict = (from employee in employeesPosition
                              join position in positionsRating
                              on employee.Value equals position.Key
                              orderby position.Value descending, employee.Key[1] ascending, employee.Key[0] ascending
                              select new { employee.Key });

            foreach (var item in sortedDict)
            {
                Console.WriteLine("{0} {1}",item.Key[0],item.Key[1]);
            }
        }
        private static void FillEmployeesPositions()
        {
            int employees = int.Parse(Console.ReadLine());
            for (int i = 0; i < employees; i++)
            {
                string[] tempRow = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                employeesPosition.Add(tempRow[0].Trim().Split(' '), tempRow[1].Trim());

            }
        }
        private static void FillPositionsRating()
        {
            int pos = int.Parse(Console.ReadLine());
            for (int i = 0; i < pos; i++)
            {
                 string[] tempRow = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                 if (!positionsRating.Keys.Contains(tempRow[0].Trim()))
                 {
                    positionsRating.Add(tempRow[0].Trim(), int.Parse(tempRow[1]));
                 }
            }
        }
    }
}
