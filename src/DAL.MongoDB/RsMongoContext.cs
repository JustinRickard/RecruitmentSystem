using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using Core.Dtos;
using System;
using Core.Interfaces;
using DAL.MongoDB.Interfaces;
using DAL.MongoDB.Interfaces.Models;

namespace DAL.MongoDB
{
    public class RsMongoContext : IDisposable, IRsMongoContext
    {
        public IMongoDatabase Database;

        public RsMongoContext(IAppSettings appSettings) {
            var client = new MongoClient(appSettings.ConnectionString);
            this.Database = client.GetDatabase(appSettings.DatabaseName);
        }

        public IMongoCollection<DbUser> Users => Database.GetCollection<DbUser>("users");

        public void Dispose() {
            // TODO: Check if we need to close connection;
            this.Database = null;
        }
    }
}