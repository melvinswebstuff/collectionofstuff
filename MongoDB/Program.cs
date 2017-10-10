using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            // To directly connect to a single MongoDB server
            // (this will not auto-discover the primary even if it's a member of a replica set)
            var client = new MongoClient();
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<BsonDocument>("bar");
            // or use a connection string
            //var client = new MongoClient("mongodb://localhost:27017");

            // or, to connect to a replica set, with auto-discovery of the primary, supply a seed list of members
            //var client = new MongoClient("mongodb://localhost:27017,localhost:27018,localhost:27019");
            Console.WriteLine(nameof(HelloWorld));

        }

        static void HelloWorld()
        {

        }
    }
}
