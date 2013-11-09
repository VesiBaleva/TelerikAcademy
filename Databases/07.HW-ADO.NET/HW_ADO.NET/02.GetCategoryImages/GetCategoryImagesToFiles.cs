using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;

class GetCategoryImagesToFiles
{
    static void Main()
    {
        DirectoryInfo currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);
        string imagesDirectoryName = Path.Combine(currentDirectory.Parent.Parent.FullName, "Images");

        SqlConnection dbCon = new SqlConnection(
            ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);

        dbCon.Open();

        using (dbCon)
        {
            ExtractCategoryImagesFromDB(dbCon, imagesDirectoryName);
        }
    }

    private const int OLE_METAFILEPICT_START_POSITION = 78;

    private static void ExtractCategoryImagesFromDB(SqlConnection dbCon, string directoryName)
    {
        SqlCommand extractImagesCommand = new SqlCommand("SELECT CategoryName, Picture FROM Categories", dbCon);
        SqlDataReader reader = extractImagesCommand.ExecuteReader();
        using (reader)
        {
            while (reader.Read())
            {
                string imageName = (string)reader["CategoryName"];

                if (imageName.Contains("/"))
                {
                    imageName = imageName.Replace('/', ' ');
                }

                byte[] imageData = (byte[])reader["Picture"];

                MemoryStream stream = new MemoryStream(imageData, OLE_METAFILEPICT_START_POSITION, imageData.Length - OLE_METAFILEPICT_START_POSITION);
                Image picture = Image.FromStream(stream);

                using (picture)
                {
                    picture.Save(Path.Combine(directoryName, imageName + ".jpg"), ImageFormat.Jpeg);
                }
            }
        }
    }
}
