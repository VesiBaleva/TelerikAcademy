using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.EntityFrameworkModel;

public class InheritEmployee
{
    static void Main()
    {
        NORTHWNDEntities northwind = new NORTHWNDEntities();
        Employee employeeExtended = new Employee();

        employeeExtended = northwind.Employees.Find(1);

        foreach (var item in employeeExtended.EntityTerritories)
        {
            Console.WriteLine("Decription of territory: {0}",item.TerritoryDescription);
        }
    }
}
