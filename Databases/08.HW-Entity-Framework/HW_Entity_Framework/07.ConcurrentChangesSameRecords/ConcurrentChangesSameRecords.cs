using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.EntityFrameworkModel;


namespace _07.ConcurrentChangesSameRecords
{
    class ConcurrentChangesSameRecords
    {
        static void Main()
        {
            using (NORTHWNDEntities northwindEntities1 = new NORTHWNDEntities())
            {
                using (NORTHWNDEntities northwindEntities2 = new NORTHWNDEntities())
                {
                    Customer editedCustomer1 = northwindEntities1.Customers.Find("WELLI");
                    editedCustomer1.Region = "SP1";

                    Customer editedCustomer2 = northwindEntities2.Customers.Find("WELLI");
                    editedCustomer2.Region = "SP2";

                    northwindEntities1.SaveChanges();
                    northwindEntities2.SaveChanges();

                }
            }
        }
    }
}
