using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halkhata.Database
{
    public static class MongoDatabase
    {
        static MongoClient dbClient;
        public static void InitMongo()
        {
            dbClient = new MongoClient("mongodb://localhost:27017/");

            var dbList = dbClient.ListDatabases().ToList();

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }
        }
    }
}
