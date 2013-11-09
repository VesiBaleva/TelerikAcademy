using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarkets.Data;
using System.Xml;
using Supermarkets.Model;


namespace ReportsQueries
{    
    public class GenerateXMLSalesByVendors
    {
        static SupermarketsContext sqlServerContext = new SupermarketsContext();

        public static void Generate()
        {
            string fileName = "../../../Sales-by-Vendors-report.xml";
            Encoding encoding = Encoding.GetEncoding("utf-8");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("sales");

                foreach (var item in sqlServerContext.Vendors)
                {
                    WriteSale(writer, item);
                }

                writer.WriteEndDocument();

                Console.WriteLine("Document {0} created.", fileName);
            }
        }
        private static void WriteSale(XmlWriter writer, Vendor item)
        {
            writer.WriteStartElement("sale");
            writer.WriteAttributeString("vendor", item.Name);
            IEnumerable<VendorSale> result = SummaryReportByVendor(item.Id);
            foreach (var vendorItem in result)
            {
                writer.WriteStartElement("summary");
                writer.WriteAttributeString("date", vendorItem.Date.ToString("dd-MMM-yyyy"));
                writer.WriteAttributeString("total-sum", vendorItem.Sum.ToString("N" + 2));
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        private static IEnumerable<VendorSale> SummaryReportByVendor(int vendorId)
        {
            string nativeSQLQuery =
                    "select Vendors.name,Vendors.id, Sales.Date, sum(Quantity*UnitPrice) as Sum " +
                    "from Vendors " +
                    "join Products " +
                    "on Vendors.id=Products.VendorId " +
                    "join SalesDetails " +
                    "on SalesDetails.ProductId=Products.id " +
                    "join Sales " +
                    "on SalesDetails.SalesId=Sales.id " +
                    "where Vendors.id={0} " +
                    "Group by Vendors.name,Vendors.id, Sales.Date";
            object[] parameters = { vendorId };
            IEnumerable<VendorSale> result = sqlServerContext.Database.SqlQuery<VendorSale>(nativeSQLQuery, parameters);
            return result;
        }

        internal class VendorSale
        {
            public string VendorName { get; set; }
            public int VendorId { get; set; }
            public DateTime Date { get; set; }
            public decimal Sum { get; set; }
        }
    }    
}
