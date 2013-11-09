using System;
using System.Configuration;
using System.Data.SqlClient;

namespace _01.RetrieveCategories
{
    class RetrieveCategories
    {
        static void Main()
        {
            SqlConnection dbCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
            dbCon.Open();
            using (dbCon)
            {
                SqlCommand cmdCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories", dbCon);
                int categoriesCount = (int)cmdCount.ExecuteScalar();
                Console.WriteLine("The number of rows in the Categories table is : {0} ", categoriesCount);
                Console.WriteLine();

                Console.WriteLine("{0,-20} {1,-50}","Name", "Description");
                SqlCommand cmdAllCategories = new SqlCommand(
                  "SELECT CategoryName, Description FROM Categories", dbCon);
                SqlDataReader reader = cmdAllCategories.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];
                        Console.WriteLine("{0,-20} {1,-50}", name, description);
                    }
                }
                Console.WriteLine();
                Console.WriteLine("\n{0,-20} {1,-50}", "Category Name", "Product name");
                SqlCommand cmdAllCategoriesProducts = new SqlCommand(
                  "select c.CategoryName,p.ProductName from Categories c " +
                    "JOIN Products p " +
                    "ON p.CategoryID=c.CategoryID " +
                    "ORDER BY c.CategoryID,p.ProductName "
                    , dbCon);
                reader = cmdAllCategoriesProducts.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string cat_name = (string)reader["CategoryName"];
                        string product_name = (string)reader["ProductName"];
                        Console.WriteLine("{0,-20} {1,-50}", cat_name, product_name);
                    }
                }

                Console.WriteLine();
                int newProductId = AddNewProduct(dbCon, "Cabernet Sauvignon", 4, 1, "1 bottle", 15.9M, 200, 6, 1, false);
                Console.WriteLine("\nProduct ID: " + newProductId);
            }
        }

        private static int AddNewProduct(
            SqlConnection dbCon,
            string productName,
            int supplierID,
            int categoryID,
            string quantityPerUnit,
            decimal unitPrice,
            short unitsInStock,
            short unitsOnOrder,
            short recordLevel,
            bool discontinued)
        {
            SqlCommand cmdAddNewProduct = new SqlCommand(
                "INSERT INTO Products(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                "VALUES (@productName, @suplierID, @categoryID, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder,@recordLevel, @discontinued)", dbCon);
            cmdAddNewProduct.Parameters.AddWithValue("@productName", productName);
            cmdAddNewProduct.Parameters.AddWithValue("@suplierID", supplierID);
            cmdAddNewProduct.Parameters.AddWithValue("@categoryID", categoryID);
            cmdAddNewProduct.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            cmdAddNewProduct.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmdAddNewProduct.Parameters.AddWithValue("@unitsInStock", unitsInStock);
            cmdAddNewProduct.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
            cmdAddNewProduct.Parameters.AddWithValue("@recordLevel", recordLevel);
            cmdAddNewProduct.Parameters.AddWithValue("@discontinued", discontinued);

            cmdAddNewProduct.ExecuteNonQuery();

            SqlCommand cmdSelectIdentity =
                new SqlCommand("SELECT @@Identity", dbCon);
            int AddedRecordId =
                (int)(decimal)cmdSelectIdentity.ExecuteScalar();
            return AddedRecordId;
        }
    }
}
