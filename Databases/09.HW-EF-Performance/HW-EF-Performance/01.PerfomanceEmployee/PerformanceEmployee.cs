using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModelDB;
namespace _01.PerfomanceEmployee
{
    class PerformanceEmployee
    {
        static void Main(string[] args)
        {
            TelerikAcademyEntities academyEntities = new TelerikAcademyEntities();
            Console.WriteLine("\nWith Problem");
            PrintEmployeesWithQueryProblem(academyEntities);
            Console.WriteLine("\nWithout Problem");
            PrintEmployeesWithoutQueryProblem(academyEntities);

        }

        static void PrintEmployeesWithQueryProblem(TelerikAcademyEntities academyEntities)
        {
            foreach (var employee in academyEntities.Employees)
            {
                Console.WriteLine("EmployeeName: {0}; Department: {1}; Town: {2}",employee.FirstName + ' ' + employee.LastName,
                    employee.Department.Name,employee.Address.Town.Name);
            }
        }

        static void PrintEmployeesWithoutQueryProblem(TelerikAcademyEntities academyEntities)
        {
            foreach (var employee in academyEntities.Employees.Include("Department").Include("Address.Town"))
            {
                Console.WriteLine("EmployeeName: {0}; Department: {1}; Town: {2}",employee.FirstName + ' ' + employee.LastName,
                    employee.Department.Name,employee.Address.Town.Name);
            }

        }
    }
}
