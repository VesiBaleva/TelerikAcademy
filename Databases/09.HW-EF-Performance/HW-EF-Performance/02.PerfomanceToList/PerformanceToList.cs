using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModelDB;

namespace _02.PerfomanceToList
{
    class PerformanceToList
    {
        static void Main()
        {
            TelerikAcademyEntities academyEntities = new TelerikAcademyEntities();
            Console.WriteLine("\nBefore:");
            EmployeesFromSofia_Slow(academyEntities);
            Console.WriteLine("\nAfter");
            EmployeesFromSofia_Fast(academyEntities);
        }
        static void EmployeesFromSofia_Slow(TelerikAcademyEntities academyEntities)
        {
            var employeesFromSofia = academyEntities.Employees.ToList()
                        .Select(e => e.Address).ToList()
                        .Select(e=>e.Town).ToList()
                        .Where(e => e.Name=="Sofia");
            foreach (var employee in employeesFromSofia)
            {
                Console.WriteLine(employee.Name);
            }
        }

        static void EmployeesFromSofia_Fast(TelerikAcademyEntities academyEntities)
        {
            List<Employee> employeesFromSofia = 
                (from employee in academyEntities.Employees
                    join address in academyEntities.Addresses
                    on employee.AddressID equals address.AddressID
                    join town in academyEntities.Towns
                    on address.TownID equals town.TownID
                    where town.Name=="Sofia"
                    select employee).ToList();
            
            foreach (var employee in employeesFromSofia)
            {
                Console.WriteLine(employee.FirstName + " " + employee.LastName);
            }
        }
    }
}
