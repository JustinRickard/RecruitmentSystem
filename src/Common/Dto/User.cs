using System;

namespace Common.Dto
{
    public class User
    {
        public User() {}

        public User(
            string id,
            string client, 
            string firstName,
            string lastName,
            string email,
            string username,
            DateTimeOffset lastModified
        ) 
        {
            Id = id;
            Client = client;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            LastModified = lastModified;
        }

        public string Id { get; set; }
        public string Client { get; set; }
        public string Username  { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Email     { get; set; }
        public DateTimeOffset LastModified {get; set;}
    }
}