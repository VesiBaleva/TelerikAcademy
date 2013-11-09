using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.EntityFrameworkModel;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace _06.CreateNorthwindTwin
{
    class CreateNorthwindTwin
    {
        static void Main(string[] args)
        {
            IObjectContextAdapter objectContext = new NORTHWNDEntities();

            string generatedScript = objectContext.ObjectContext.CreateDatabaseScript();

            string dbScript = "CREATE DATABASE NorthwindTwin ON PRIMARY " +
                "(NAME = NorthwindTwin, " +
                "FILENAME = 'E:\\NorthwindTwin.mdf', " +
                "SIZE = 5MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = NorthwindTwinLog, " +
                "FILENAME = 'E:\\NorthwindTwin.ldf', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)";

            string strDbConn = "Server=LOCALHOST;Database=master;Integrated Security=true";

            SqlConnection dbConn = new SqlConnection(strDbConn);
            dbConn.Open();

            using (dbConn)
            {
                SqlCommand createDB = new SqlCommand(dbScript, dbConn);
                createDB.ExecuteNonQuery();
            }

            string strDbConnCloning = "Server=LOCALHOST;Database=NorthwindTwin;Integrated Security=true";
            SqlConnection dbConnCloning = new SqlConnection(strDbConnCloning);

            dbConnCloning.Open();

            using (dbConnCloning)
            {
                SqlCommand cloneDb = new SqlCommand(generatedScript, dbConnCloning);
                cloneDb.ExecuteNonQuery();
            }
        }
    }
}
