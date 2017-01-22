using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using Common.Dto;
using Common.Interfaces;
using Common.Classes;
using DAL.MongoDB.Interfaces;
using DAL.MongoDB.Models;
using System;

namespace DAL.MongoDB
{
    public class RsMongoContext : IDisposable, IRsMongoContext
    {
        public IMongoDatabase Database;

        public RsMongoContext() {

            // TODO: Get app settings here
            IAppSettings appSettings = new AppSettings();
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