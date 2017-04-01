using System;
using Common.Dto;
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
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string Token { get; set; }
        public UserSettings Settings { get; set; }
        /*
        [BsonRepresentation(BsonType.String)] 
        public Gender Gender { get; set; }
         */
    }
}