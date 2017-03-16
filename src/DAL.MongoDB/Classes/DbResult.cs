using System.Collections.Generic;

namespace DAL.MongoDB.Classes
{
    public class DbResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int ErrorCode { get; set; }
        public DbResult()
        {
            Success = false;
            Message = "";
            ErrorCode = 500;
        }
    }

    public class GetOneResult<TEntity> : DbResult where TEntity : class, new()
    {
        public TEntity Entity { get; set; }
    }

    public class GetManyResult<TEntity> : DbResult where TEntity : class, new()
    {
        public IEnumerable<TEntity> Entities { get; set; }
    }

    public class GetListResult<T> : DbResult
    {
        public List<T> Entities { get; set; }
    }
    
}