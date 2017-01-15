using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using Core.Dtos;

namespace DAL.MongoDB
{
    public class RsMongoContext
    {
        public IMongoDatabase Database;
        public RsMongoContext(string connectionString) {
            var client = new MongoClient(connectionString);
            this.Database = client.GetDatabase(Constants.DatabaseName);
        }

        public IMongoCollection<User> Users => Database.GetCollection<User>("users");
    }
}