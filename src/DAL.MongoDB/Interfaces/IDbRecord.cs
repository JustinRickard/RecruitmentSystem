using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.MongoDB.Interfaces
{
    public interface IDbRecord
    {
        DateTimeOffset LastModified { get; set; }

        bool Deleted { get; set; }
    }
}
