using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using Core.Dtos;
using System;

namespace DAL.MongoDB
{
    public class RsMongoContext : IDisposable
    {
        public IMongoDatabase Database;
        public AppSettings AppSettings;

        public RsMongoContext() {
            var client = new MongoClient(AppSettings.ConnectionString); // TODO: Get connection string from settings
            this.Database = client.GetDatabase(AppSettings.DatabaseName);
        }

        public IMongoCollection<User> Users => Database.GetCollection<User>("users");

        public void Dispose() {
            // TODO: Check if we need to close connection;
            this.Database = null;
        }
    }
}