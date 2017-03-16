using MongoDB.Driver;
using DAL.MongoDB.Models;

namespace DAL.MongoDB.Interfaces
{
    public interface IRsMongoContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>();
        IMongoCollection<DbAudit> AuditLogs { get; }
        IMongoCollection<DbRole> Roles { get; }
        IMongoCollection<DbUser> Users { get; }
    }
}