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
// using DAL.MongoDB.Classes;

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

        protected internal void UpdateLastModified(IDbRecord record) 
        {
            record.LastModified = Now;
        }

        protected internal void UpdateDateCreated(IDbRecord record) 
        {
            var now = Now;
            record.DateCreated = now;
            record.LastModified = now;
        }

        protected internal void SetInitialRecordValues(IDbRecord record) {
            var now = Now;
            record.DateCreated = now;
            record.LastModified = now;
            record.Deleted = false;
        }

        internal protected async Task<Maybe<TEntity>> GetOne<TEntity>(string id) where TEntity : class, new()
        {            
                var filter = Builders<TEntity>.Filter.Eq("Id", id);
                return await GetOne<TEntity>(filter);            
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

        internal protected async Task<IEnumerable<TEntity>> GetAllNotDeleted<TEntity>() where TEntity : class, new()
        {
            var filter = Builders<TEntity>.Filter.Eq("Deleted", false);
            return await GetMany<TEntity>(filter);
        }

        private DateTimeOffset Now => DateTimeOffset.Now;
    }
}