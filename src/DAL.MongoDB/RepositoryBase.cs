using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using Common.Interfaces;
using Common.Classes;
using DAL.MongoDB.Interfaces;
using DAL.MongoDB;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace DAL.MongoDB
{
    public class RepositoryBase
    {
        protected internal IAppSettings appSettings { get; set; }

        public RepositoryBase(IAppSettings appSettings) {
            this.appSettings = appSettings;
        }

        protected internal RsMongoContext GetContext() {
            return new RsMongoContext(appSettings);
        }

        protected internal IMongoCollection<IDbRecord> GetCollection(IMongoCollection<IDbRecord> collection) {
            return (IMongoCollection<IDbRecord>)collection;
        }

        public async Task<IEnumerable<IDbRecord>> GetAll(IMongoCollection<IDbRecord> collection) {
            using (var ctx = GetContext()) {
                return await collection.AsQueryable().ToListAsync();
            }
        }

        public async Task<IDbRecord> GetByIdGeneric (string id, IMongoCollection<IDbRecord> collection)
        {
            using (var ctx = GetContext()) 
            {
                var objectId = new ObjectId(id);
                return await collection.AsQueryable().Where(x => x.Id == objectId).SingleOrDefaultAsync();
            };
        }

        public async Task AddGeneric(IDbRecord record, IMongoCollection<IDbRecord> collection) {
            using (var ctx = GetContext()) {
                await collection.InsertOneAsync(record);
            }
        }
        public async Task DeleteGeneric(IDbRecord record, IMongoCollection<IDbRecord> collection)
        {
            await SetDeleted(record, collection, true);
        }
        public async Task UndeleteGeneric(IDbRecord record, IMongoCollection<IDbRecord> collection)
        {
            await SetDeleted(record, collection, false);
        }

        public async Task ObliterateGeneric (IDbRecord record, IMongoCollection<IDbRecord> collection) 
        {
            using (var ctx = GetContext()) {
                var oldUser = ctx.Users.AsQueryable().Where(x => x.Id == record.Id).SingleOrDefault();
                if (oldUser != null) {
                    var filter = Builders<IDbRecord>.Filter.Eq(x => x.Id, record.Id);
                    await collection.DeleteOneAsync(filter);
                }
            }
        }

        private async Task SetDeleted(IDbRecord record, IMongoCollection<IDbRecord> collection, bool deleted) 
        {
            using (var ctx =  GetContext()) {
                var oldRecord = collection.AsQueryable().Where(x => x.Id == record.Id).SingleOrDefaultAsync();
                if (oldRecord != null) {
                    var filter = Builders<IDbRecord>.Filter.Eq(x => x.Id, record.Id);
                    var update = Builders<IDbRecord>.Update
                        .Set(x => x.Deleted, deleted)
                        .Set(x => x.LastModified, DateTime.Now);

                    await collection.UpdateOneAsync(filter, update);
                }
            }
        }
    }
}