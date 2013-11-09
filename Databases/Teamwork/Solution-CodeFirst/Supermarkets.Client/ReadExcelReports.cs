using System;
using System.Linq;
using System.Data.OleDb;
using System.IO;
using System.IO.Compression;
using Supermarkets.Data;
using Supermarkets.Model;

namespace Supermarkets.Client
{
    public class ReadExcelReports
    {
        static SupermarketsContext dbContext = new SupermarketsContext();
        static string zipToUnpack = "../../../Sample-Sales-Reports.zip";
        static string unpackDirectory = "../../../Temp";

        public static void ReadReports()
        {
            CreateTemp(unpackDirectory);
            Extract();
            string[] dirs = Directory.GetDirectories(unpackDirectory);

            foreach (string dir in dirs)
            {
                string[] filePaths = Directory.GetFiles(dir);
                foreach (string filePath in filePaths)
                {
                    int idCity = GetCityId(filePath);
                    ReadExcel(filePath, idCity);
                }
            }

            DeleteFiles(unpackDirectory);
        }

        private static void CreateTemp(string tempPath)
        {
            Directory.CreateDirectory(tempPath);
        }

        private static void Extract()
        {
            ZipFile.ExtractToDirectory(zipToUnpack, unpackDirectory);
        }

        private static void DeleteFiles(string tempDir)
        {
            DirectoryInfo dir = new DirectoryInfo(tempDir);
            if (dir.Exists)
            {
                dir.Delete(true);
            }
        }

        private static void ReadExcel(string filePath, int idCity)
        {
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;";
            OleDbConnection excelCon = new OleDbConnection(connStr);
            excelCon.Open();

            using (excelCon)
            {
                OleDbCommand readSales = new OleDbCommand(@"SELECT * FROM [Sales$]", excelCon);
                OleDbDataReader reader = readSales.ExecuteReader();

                using (reader)
                {
                    reader.Read();
                    string marketLocation = reader[0].ToString();
                    int idMarket = InsertMarket(marketLocation, idCity);

                    DateTime salesDate = GetSalesDate(filePath);
                    int saleId = InsertSales(idMarket, salesDate);

                    while (reader.Read())
                    {
                        string productId = reader[0].ToString();
                        string quantity = reader[1].ToString();
                        string unitPrice = reader[2].ToString();

                        int num;
                        if (int.TryParse(productId, out num))
                        {
                            CreateSaleDetails(saleId, productId, quantity, unitPrice);
                        }
                    }
                }
            }
        }

        private static void CreateSaleDetails(int saleId, string productId, string quantity, string unitPrice)
        {
            using (SupermarketsContext dbContext = new SupermarketsContext())
            {
                SaleDetail newSaleDetail = new SaleDetail
                {
                    ProductId = int.Parse(productId),
                    Quantity = int.Parse(quantity),
                    UnitPrice = decimal.Parse(unitPrice),
                    SaleId = saleId
                };
                dbContext.SaleDetails.Add(newSaleDetail);
                dbContext.SaveChanges();
            }
        }

        private static int GetCityId(string filePath)
        {
            string[] filesNameData = filePath.Split(new char[] { '-', '\\' });          
            string sityName = filesNameData[4].ToString();

            using (SupermarketsContext dbContext = new SupermarketsContext())
            {
                var allCities = dbContext.Cities.Where(city => city.Name == sityName).FirstOrDefault();
                if (allCities == null)
                {
                    City newCity = new City
                    {
                        Name = sityName
                    };
                    dbContext.Cities.Add(newCity);
                    dbContext.SaveChanges();
                    return newCity.Id;
                }
                else
                {
                    return allCities.Id;
                }
            }
        }

        private static int InsertMarket(string marketLocation, int idCity)
        {
            using (SupermarketsContext dbContext = new SupermarketsContext())
            {
                var allMarkets = dbContext.Markets.Where(market => market.Address == marketLocation).FirstOrDefault();
                if (allMarkets == null)
                {
                    Market newMarket = new Market
                    {
                        Address = marketLocation,
                        CityId = idCity
                    };
                    dbContext.Markets.Add(newMarket);
                    dbContext.SaveChanges();
                    return newMarket.Id;
                }
                else
                {
                    return allMarkets.Id;
                }
            }
        }

        private static DateTime GetSalesDate(string filePath)
        {
            string[] filesNameData = filePath.Split(new char[] { '-', '\\' });   
            return DateTime.Parse(filesNameData[1] + "." + filesNameData[2] + filesNameData[3]);
        }

        private static int InsertSales(int idMarket, DateTime salesDate)
        {
            using (SupermarketsContext dbContext = new SupermarketsContext())
            {
                var allSales = dbContext.Sales.Where(sale => (sale.Date == salesDate && sale.MarketId == idMarket)).FirstOrDefault();
                if (allSales == null)
                {
                    Sale newSale = new Sale
                    {
                        Date = salesDate,
                        MarketId = idMarket
                    };
                    dbContext.Sales.Add(newSale);
                    dbContext.SaveChanges();
                    return newSale.Id;
                }
                else
                {
                    return allSales.Id;
                }
            }
        }        
    }
}
