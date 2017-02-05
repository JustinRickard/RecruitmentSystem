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

namespace DAL.MongoDB
{
    public class RepositoryBase
    {
        protected internal IAppSettings appSettings { get; set; }

        public RepositoryBase(IOptions<AppSettings> appSettings) {
            this.appSettings = appSettings.Value;
        }

        protected internal RsMongoContext GetContext() {
            return new RsMongoContext(appSettings);
        }

        protected internal void UpdateLastModified(IDbRecord record) 
        {
            record.LastModified = DateTime.Now;
        }

        protected internal void UpdateDateCreated(IDbRecord record) 
        {
            var now = DateTime.Now;
            record.DateCreated = now;
            record.LastModified = now;
        }
    }
}