using System;
using System.Linq;
using System.Data.OleDb;
using System.IO;
using System.IO.Compression;
using Supermarkets.Data;
using Supermarkets.Model;
using System.Xml;

namespace Supermarkets.Client
{
    class LoadVendorExpences
    {
        public static void ReadXml()
        {
            using (SupermarketsContext db = new SupermarketsContext())
            {
                using (XmlReader reader = XmlReader.Create("../../Vendors-Expenses.xml"))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) &&
                            (reader.Name == "sale"))
                        {
                            string vendorName = reader.GetAttribute("vendor");
                            var vendorID =
                                from vendor in db.Vendors
                                where vendor.Name == vendorName
                                select vendor;
                            
                            while (!((reader.NodeType == XmlNodeType.EndElement) && (reader.Name == "sale")))
                            {
                                reader.Read();
                                if ((reader.NodeType == XmlNodeType.Element) &&
                                    (reader.Name == "expenses"))
                                {
                                    DateTime date = DateTime.Parse(reader.GetAttribute("month"));
                                    decimal expences = decimal.Parse(reader.ReadInnerXml());
                                    VendorExpense newVendorExpense = new VendorExpense
                                    {
                                        Date = date,
                                        Expense = expences,
                                        Vendor = vendorID.First(),
                                    };
                                    db.VendorExpenses.Add(newVendorExpense);
                                    db.SaveChanges();
                                }
                            }
                        }
                    }                    
                }
            }
        }
    }
}
