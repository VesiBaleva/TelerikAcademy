using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace _06.ReadFromExcelFile
{
    class ReadExcelFile
    {
        static void Main(string[] args)
        {
            DirectoryInfo currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);
            string resourcesDirectoryName = Path.GetDirectoryName(currentDirectory.Parent.Parent.FullName);
            string excelFilePath = Path.Combine(resourcesDirectoryName, "Scores.xlsx");

            DataSet dataSet = ReadSheetData(excelFilePath, "Sheet1");

            // Traverse through each row in the dataset.
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                // store the DataRow info into an array
                object[] cells = dataRow.ItemArray;

                // Traverse through the array of objects.
                // Uses object since for some reason the Dataset might read some blank value.
                // By using object we can convert to string at a later point.
                foreach (object cell in cells)
                {
                    string cellText = cell.ToString();
                    Console.Write("{0, -18}", cellText);
                }

                Console.WriteLine();
            }
        }

        private static OleDbConnection GetConnection(string excelFilePath)
        {
            OleDbConnection connection = new OleDbConnection(
                string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;",
                excelFilePath));

            return connection;
        }

        private static DataSet ReadSheetData(string excelFilePath, string sheetName)
        {
            OleDbConnection connection = GetConnection(excelFilePath);

            connection.Open();

            using (connection)
            {
                // Create Dataset and fill with imformation from the Excel Spreadsheet for easier reference.
                DataSet dataSet = new DataSet();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(
                    string.Format("SELECT * FROM [{0}$]",
                    sheetName),
                    connection);

                dataAdapter.Fill(dataSet);
                return dataSet;
            }
        }
    }
}
