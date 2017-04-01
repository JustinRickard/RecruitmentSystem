using Microsoft.Extensions.Options;
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
using Common.Interfaces.Repositories;
using DAL.MongoDB.Models;
using Common.Enums;

namespace DAL.MongoDB
{
    public class RepositoryBase
    {
        protected internal IAppSettings appSettings { get; set; }

        public RepositoryBase(
            IOptions<AppSettings> appSettings
        ) {
            this.appSettings = appSettings.Value;
        }

        protected internal RsMongoContext GetContext() {
            return new RsMongoContext(appSettings);
        }

        protected internal void SetInitialRecordValues(IDbRecord record) {
            var now = Now;
            record.DateCreated = now;
            record.LastModified = now;
            record.Deleted = false;
        }

        // Generic CRUD operations

        // GET
        internal protected async Task<Maybe<TEntity>> GetOne<TEntity>(string id) where TEntity : DbRecordBase, new()
        {            
                return await GetOne<TEntity>(GetByIdFilter<TEntity>(id));
        }

        internal protected async Task<Maybe<TEntity>> GetOne<TEntity>(FilterDefinition<TEntity> filter) where TEntity : class, new()
        {
            using (var ctx = GetContext())
            {
                var collection = ctx.GetCollection<TEntity>();
                var entity = await collection.Find(filter).SingleOrDefaultAsync();                

                return entity != null
                    ? new Maybe<TEntity>(entity)
                    : Maybe<TEntity>.Fail;
            }
        }

        internal protected async Task<IEnumerable<TEntity>> GetMany<TEntity>(FilterDefinition<TEntity> filter) where TEntity : class, new()
        {
            using (var ctx = GetContext())
            {
                var collection = ctx.GetCollection<TEntity>();
                var entities = await collection.Find(filter).ToListAsync();
                return entities;
            }
        }

        internal protected async Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : class, new()
        {
            return await GetMany<TEntity>(null);
        }

        internal protected async Task<IEnumerable<TEntity>> GetAllNotDeleted<TEntity>() where TEntity : DbRecordBase, new()
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Deleted, false);
            return await GetMany<TEntity>(filter);
        }

        // ADD
        public async Task<Maybe<TEntity>> Add<TEntity>(TEntity dbRecord) where TEntity : IDbRecord
        {
            SetInitialRecordValues(dbRecord);

            using (var ctx = GetContext()) {
                var collection = ctx.GetCollection<TEntity>();
                await collection.InsertOneAsync(dbRecord);
                var filter = GetByIdFilter<TEntity>(dbRecord.Id);
                var newRecord = await collection.Find(filter).SingleOrDefaultAsync(); 
                return ReturnMaybe(newRecord);
            }
        }

        // Update
        public async Task<Maybe<TEntity>> Update<TEntity>(string id, UpdateDefinition<TEntity> update) where TEntity : IDbRecord
        {
            using (var ctx =  GetContext()) {
                await ctx.AuditLogs.InsertOneAsync(new DbAudit{ Type = AuditType.RepositoryBase, Message = string.Format("Update: {0}", update.ToString()) });

                var record = await GetById<TEntity>(ctx, id);
                if (record == null)
                {
                    // The record to update does not exist
                    return Maybe<TEntity>.Fail;
                }
                var filter = GetByIdFilter<TEntity>(id);
                update = update.Set(x => x.LastModified, Now);

                var result = await ctx.GetCollection<TEntity>().UpdateOneAsync(filter, update);
                
                // The record being updated should be updated. If not, use updatedRecord.
                // var updatedRecord = await ctx.GetCollection<TEntity>().Find(filter).SingleOrDefaultAsync();
                return ReturnMaybe(record);
            }
        }

        // Delete / Obliterate

        public async Task<Maybe<TEntity>> Delete<TEntity>(string id) where TEntity : IDbRecord
        {
                var update = Builders<TEntity>.Update
                            .Set(x => x.Deleted, true)
                            .Set(x => x.LastModified, DateTime.Now);
                
                return await Update<TEntity>(id, update);            
        }

        public async Task Obliterate<TEntity> (string id) where TEntity : IDbRecord
        {
            using (var ctx = GetContext()) {
                var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);
                await ctx.GetCollection<TEntity>().DeleteOneAsync(filter);
            }           
        }

        // Helper methods

        internal protected async Task<TEntity> GetById<TEntity>(IRsMongoContext ctx, string id) where TEntity : IDbRecord
        {
            var collection = ctx.GetCollection<TEntity>();
            var filter = GetByIdFilter<TEntity>(id);
            var record = await collection.Find(filter).SingleOrDefaultAsync();
            return record;
        }

        private Maybe<TEntity> ReturnMaybe<TEntity>(TEntity entity)
        {
            return entity != null
                ? new Maybe<TEntity>(entity)
                : Maybe<TEntity>.Fail;
        }

        private FilterDefinition<TEntity> GetByIdFilter<TEntity> (string id) where TEntity : IDbRecord
        {
            return Builders<TEntity>.Filter.Eq(x => x.Id, id);
        }

        
        private DateTimeOffset Now => DateTimeOffset.Now;
    }
}