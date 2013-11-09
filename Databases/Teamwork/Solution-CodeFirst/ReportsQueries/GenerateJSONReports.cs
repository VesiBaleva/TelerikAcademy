using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarkets.Data;
using Supermarkets.Model;
using Newtonsoft.Json;
using System.IO;
using System.Collections;

namespace ReportsQueries
{
    public class GenerateJSONReports
    {
        private static string rptDir = "../../../Product-Reports";
        /*
        public static IEnumerable Power(SupermarketsContext db)
        {
            foreach (var product in db.Products.Include("Vendor").Include("SaleDetails"))
            {
                decimal quantity = 0;
                decimal totalSum = 0;
                foreach (var productSaleDetail in product.SaleDetails)
                {
                    quantity += productSaleDetail.Quantity;
                    totalSum += productSaleDetail.Sum;
                }

                Dictionary<string, object> report = new Dictionary<string, object>();
                report["Id"] = product.Id;
                report["Name"] = product.Name;
                report["VendorName"] = product.Vendor.Name;
                report["TotalQuantity"] = quantity;
                report["TotalSum"] = totalSum;

                yield return report;
            }
            
        }
        */
        public static void StoreJsonReports()
        {
            if (!Directory.Exists(rptDir))
            {
                Directory.CreateDirectory(rptDir);
            }

            List<int> ids;

            var jsons = ExatractJsonData(out ids);

            for (int i = 0; i < jsons.Count; i++)
            {
                File.WriteAllText(rptDir + "\\" + ids[i].ToString("00") + ".json", jsons[i]);
            }
        }

        public static List<string> ExatractJsonData(out List<int> ids)
        {
            ids = new List<int>();

            List<string> jsons = new List<string>();

            using (SupermarketsContext dbContexet = new SupermarketsContext())
            {
                Dictionary<string, object> jsonDict = new Dictionary<string, object>();
                foreach (var product in dbContexet.Products.Include("Vendor").Include("SaleDetails"))
                {
                    jsonDict.Clear();
                    decimal quantity = 0;
                    decimal totalSum = 0;
                    foreach (var productSaleDetail in product.SaleDetails)
                    {
                        quantity += productSaleDetail.Quantity;
                        totalSum += productSaleDetail.Sum;
                    }
                    
                    ids.Add(product.Id);

                    jsonDict["product-id"] = product.Id;
                    jsonDict["product-name"] = product.Name;
                    jsonDict["vendor-name"] = product.Vendor.Name;
                    jsonDict["total-quantity-sold"] = quantity;
                    jsonDict["total-icomes"] = totalSum;

                    string json = JsonConvert.SerializeObject(jsonDict, Formatting.Indented);

                    jsons.Add(json);
                }
                /*
                var result =
                from product in dbContexet.Products
                join vendor in dbContexet.Vendors
                on product.VendorId equals vendor.Id
                join sd in dbContexet.SaleDetails
                on product.Id equals sd.ProductId
                group sd by new
                {
                product.Id,
                product.Name,
                vendorName = vendor.Name
                } into g
                select new
                {
                ProductId = g.Key.Id,
                ProductName = g.Key.Name,
                VendorName = g.Key.vendorName,
                TotalQnt = g.Sum(x => x.Quantity),
                TotalIncome = g.Sum(x => x.Quantity * x.UnitPrice)
                };
                Directory.CreateDirectory(rptDir);
                foreach (var item in result)
                {
                string json = JsonConvert.SerializeObject(item, Formatting.Indented);
                Console.WriteLine(json);
                File.WriteAllText(rptDir + "\\" + item.ProductId.ToString("00") + ".json", json);
                }
                */
            }

            return jsons;
        }
    }
}
