using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.EntityFrameworkModel;

    public class DAO
        
    {
        private static NORTHWNDEntities northwindEntities;

        static void Main()
        {
            northwindEntities = new NORTHWNDEntities();
            string newCustomerName = InsertCustomer("WIKON","Ivkony Union");
            Console.WriteLine("Inserted new customer with name {0}.",newCustomerName );
            Customer editedCustomer = ModifyCustomer("WIKON", "Ivan Ivanov");
            Console.WriteLine("Added contact name {0} to company name {1}",editedCustomer.ContactName,editedCustomer.CompanyName);
            Console.WriteLine("Print all customers before deleted customer with Company name {0}: ", editedCustomer.CompanyName);
            PrintCustomers();
            DeleteCustomer(editedCustomer.CustomerID);
            Console.WriteLine("\nPrint all customers after delete customer with Company name {0}: ", editedCustomer.CompanyName);
            PrintCustomers();
            Console.WriteLine();
            CustomersWithOrders();
            Console.WriteLine("\nAfter running native SQL Query");
            IEnumerable<CustomerOrder> result = ReportForCanadaAnd1997();
            Console.WriteLine("{0,-40} {1,-30} {2,-30} {3,-20}","Customer Name", "Contact Name", "Order Date", "Ship Country");
            foreach (var item in result)
            {
                Console.WriteLine("{0,-40} {1,-30} {2,-30} {3,-20}", item.CompanyName, item.ContactName, item.OrderDate, item.ShipCountry);
            }
            Console.WriteLine("\nOrders by specific region");
            OrdersBySpecigicRegionAnYear("UK", new DateTime(1998, 1, 1), new DateTime(1998, 3, 31));
        }

        private static string InsertCustomer(string CustomerId, string CustomerName)
        {
            Customer newCustomer = new Customer
            {
                CustomerID = CustomerId,
                CompanyName = CustomerName
            };
            northwindEntities.Customers.Add(newCustomer);
            northwindEntities.SaveChanges();
            return newCustomer.CompanyName;
        }

        private static Customer ModifyCustomer(string CustomerId, string ContactName)
        {
            Customer editedCustomer = GetCustomerById(CustomerId);
            editedCustomer.ContactName = ContactName;
            northwindEntities.SaveChanges();
            return editedCustomer;
        }

        private static void DeleteCustomer(string CustomerId)
        {
            Customer deletedCustomer = GetCustomerById(CustomerId);
            northwindEntities.Customers.Remove(deletedCustomer);
            northwindEntities.SaveChanges();            
        }

        private static Customer GetCustomerById(string CustomerId)
        {
            Customer customer = northwindEntities.Customers.Find(CustomerId);
            return customer;
        }

        static void PrintCustomers()
        {
            
            IQueryable<Customer> allCustomers =
                (from c in northwindEntities.Customers
                 orderby c.CustomerID ascending
                 select c);
            
            foreach (var customer in allCustomers)
            {
                Console.WriteLine("{0}. {1}", customer.CustomerID, customer.CompanyName);
            }
            Console.WriteLine(allCustomers.Count());
        }

        //task 3
        private static void CustomersWithOrders()
        {
            var customerOrders =
                from order in northwindEntities.Orders
                join customer in northwindEntities.Customers
                on order.CustomerID equals customer.CustomerID
                where order.OrderDate.Value.Year == 1997 && order.ShipCountry=="Canada"
                select new
                {
                    CustomerName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    OrderDate=order.OrderDate,
                    ShipCountry=order.ShipCountry
                };
            Console.WriteLine("{0,-40} {1,-30} {2,-30} {3,-20}","Customer Name", "Contact Name", "Order Date", "Ship Country");
            foreach (var item in customerOrders)
            {
                Console.WriteLine("{0,-40} {1,-30} {2,-30} {3,-20}",item.CustomerName,item.ContactName,item.OrderDate,item.ShipCountry);
            }

        }

        //task 4

        private static IEnumerable<CustomerOrder> ReportForCanadaAnd1997()
        {
            string nativeSQLQuery =
                "SELECT CompanyName, ContactName, OrderDate, ShipCountry " +
                "FROM Customers  c " +
                "JOIN Orders o " +
                "ON c.CustomerID=o.CustomerID " +
                "WHERE YEAR(OrderDate)=1997 AND ShipCountry='Canada'";
            IEnumerable<CustomerOrder> result = northwindEntities.Database.SqlQuery<CustomerOrder>(nativeSQLQuery);
            return result;
        }


        internal class CustomerOrder
        {
            public string CompanyName {get; set;}
            public string ContactName {get; set;}
            public DateTime OrderDate {get; set;}
            public string ShipCountry {get; set;}
        }

        //task 5
        private static void OrdersBySpecigicRegionAnYear(string shipRegion, DateTime? beginingDate, DateTime? endingDate)
        {
            var customerOrders =
                from order in northwindEntities.Orders
                join customer in northwindEntities.Customers
                on order.CustomerID equals customer.CustomerID
                where order.OrderDate>=beginingDate && order.OrderDate<=endingDate && order.ShipCountry == shipRegion
                select new
                {
                    CustomerName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    OrderDate = order.OrderDate,
                    ShipCountry = order.ShipCountry
                };
            Console.WriteLine("{0,-40} {1,-30} {2,-30} {3,-20}", "Customer Name", "Contact Name", "Order Date", "Ship Country");
            foreach (var item in customerOrders)
            {
                Console.WriteLine("{0,-40} {1,-30} {2,-30} {3,-20}", item.CustomerName, item.ContactName, item.OrderDate, item.ShipCountry);
            }

        }
    }
