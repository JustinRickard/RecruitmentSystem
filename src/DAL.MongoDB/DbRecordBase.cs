using System;
using MongoDB.Bson;
using DAL.MongoDB.Interfaces;

namespace DAL.MongoDB
{
    public abstract class DbRecordBase : IDbRecord
    {
        public ObjectId Id { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset LastModified { get; set; }

        public bool Deleted { get; set; }
    }
}