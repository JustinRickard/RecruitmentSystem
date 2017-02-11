using System;
using Common.Classes;
using Common.Enums;

namespace Common.Dto
{
    public class User : DbRecordBase
    {
        public User() {}

        public User(
            string id,
            string client, 
            string firstName,
            string lastName,
            string email,
            string username,
            DateTimeOffset dateCreated,
            DateTimeOffset lastModified,
            bool deleted
        ) 
        {
            Id = id;
            Client = client;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            DateCreated = dateCreated;
            LastModified = lastModified;
            Deleted = deleted;
        }

        public string Client { get; set; }
        public string Username  { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Email     { get; set; }
        public Gender Gender { get; set; }
    }
}