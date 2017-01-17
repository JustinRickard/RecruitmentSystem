using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using Core.Dtos;
using System;
using Core.Interfaces;

namespace DAL.MongoDB
{
    public class RsMongoContext : IDisposable
    {
        public IMongoDatabase Database;

        public RsMongoContext(IAppSettings appSettings) {
            var client = new MongoClient(appSettings.ConnectionString);
            this.Database = client.GetDatabase(appSettings.DatabaseName);
        }

        public IMongoCollection<User> Users => Database.GetCollection<User>("users");

        public void Dispose() {
            // TODO: Check if we need to close connection;
            this.Database = null;
        }
    }
}