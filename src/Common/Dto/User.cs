using System;
using Common.Classes;
using Common.Enums;
using Common.ExtensionMethods;

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
        ) : this(client, firstName, lastName, email, username)
        {
            Id = id;
            DateCreated = dateCreated;
            LastModified = lastModified;
            Deleted = deleted;
        }

        public User (
            string client, 
            string firstName,
            string lastName,
            string email,
            string username
        )
        {
            Client = client;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
        }

        public string Client { get; set; }
        public string Username  { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Email     { get; set; }
        public bool EmailConfirmed { get; set; }

        public bool IsValid =>
            FirstName.NotEmpty() &&
            LastName.NotEmpty() &&
            Email.NotEmpty() &&
            Username.NotEmpty();
    }
}