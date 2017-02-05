using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.MongoDB.Interfaces
{
    public interface IDbRecord
    {
        ObjectId Id { get; set; }

        DateTimeOffset DateCreated { get; set; }

        DateTimeOffset LastModified { get; set; }

        bool Deleted { get; set; }
    }
}
