using System;
using MongoDB.Bson;

namespace DAL.MongoDB
{
    public abstract class DbRecordBase
    {
        public ObjectId Id {get; set; }

        public bool Deleted { get; set; }
        public DateTimeOffset LastModified { get; set; }
    }
}