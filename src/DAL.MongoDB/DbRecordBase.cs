using System;

namespace DAL.MongoDB
{
    public abstract class DbRecordBase
    {
        public bool Deleted { get; set; }
        public DateTimeOffset LastModified { get; set; }
    }
}