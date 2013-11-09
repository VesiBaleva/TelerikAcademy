namespace Supermarkets.Client
{
    #region Usings
    using Supermarkets.Data;
    using Supermarkets.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Products.Data;
    using ReportsQueries;
    using MongoDB.Data;
    #endregion    

    internal class Program
    {
        static void Main(string[] args)
        {
            using (SupermarketsContext db = new SupermarketsContext())
            {                
                TransferDB(db);                
                ReadExcelReports.ReadReports();
                Console.WriteLine("Crated MSSQL Databas");
                
                Console.WriteLine("Generated Pdf");
                GenerateXMLSalesByVendors.Generate();
                Console.WriteLine("Generated xml sales report");
                GenerateJSONReports.StoreJsonReports();
                Console.WriteLine("Generated json reports");
                LoadVendorExpences.ReadXml();
                Console.WriteLine("Read xml vendor expences");
                MongoDBContext.GenerateMongoDB();
                Console.WriteLine("Generated mongodg database");
            }
        }
  
        private static void TransferDB(SupermarketsContext db)
        {
            using (db)
            {
                using (var mySqlContext = new ProductsModel())
                {
                    var products = mySqlContext.Products.ToList();
                    var measures = mySqlContext.Measures.ToList();
                    var vendors = mySqlContext.Vendors.ToList();   
                    db.SaveChanges();

                    foreach (var vendor in vendors)
                    {                        
                        var newVendor = new Supermarkets.Model.Vendor { Name = vendor.VendorName };
                        newVendor.Id = vendor.VendorID;
                        db.Vendors.Add(newVendor);
                    }                   

                   
                    foreach (var measure in measures)
                    {                       
                        var newMeasure = new Supermarkets.Model.Measure { Name = measure.MeasureName };
                        newMeasure.Id = measure.MeasureID;
                        db.Measures.Add(newMeasure);
                    }                

                    foreach (var product in products)
                    {
                        var newProduct = new Supermarkets.Model.Product { Id = product.ProductsID, Name = product.ProductName };
                        newProduct.Vendor = db.Vendors.Find(product.VendorID);
                        newProduct.Measure = db.Measures.Find(product.MeasureID);
                        db.Products.Add(newProduct);
                        db.SaveChanges();
                    }
                    db.SaveChanges();
                }
            }
        }
    }
}
