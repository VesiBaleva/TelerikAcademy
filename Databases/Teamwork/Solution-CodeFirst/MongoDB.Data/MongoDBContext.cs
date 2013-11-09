using System;
using System.Linq;
using MongoDB.Driver;
using System.IO;
using ReportsQueries;
using System.Collections.Generic;
namespace MongoDB.Data
{
    public static class MongoDBContext
    {
        public static void GenerateMongoDB ()
        {
            var json = new MongoJson();
            var mongo = new Mongo();

            mongo.Connect();

            //Create clean database and collection for Notes
            var db = mongo["SupermarkertsDB"];
            db.SendCommand("dropDatabase");
            var products = db["Products"];

            List<int> ids;
            var jsonData = GenerateJSONReports.ExatractJsonData(out ids);
            foreach (var item in jsonData)
            {
                var jsonDocument = json.DocumentFrom(item);
                products.Insert(jsonDocument);
            }           
            
            mongo.Disconnect();
        }
    }
}
