using System;

namespace Site.Admin2.ViewModels
{
    public class UserVM
    {
        public UserVM(){}
        public UserVM(
            string id,
            string client,
            string username,
            string email,
            string firstName,
            string lastName,
            DateTimeOffset dateCreated,
            DateTimeOffset lastModified,
            bool deleted
        ) 
        {
            Id = id;
            Client = client;
            Username = username;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            DateCreated = dateCreated;
            LastModified = lastModified;
        }

        public string Id { get; set; }
        public string Client { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public bool Deleted { get; set; }
    }
}