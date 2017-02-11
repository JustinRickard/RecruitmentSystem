using Common.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.MongoDB.Models
{
    public class DbUser : DbRecordBase
    {
        public string ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        [BsonRepresentation(BsonType.String)] 
        public Gender Gender { get; set; }
    }
}