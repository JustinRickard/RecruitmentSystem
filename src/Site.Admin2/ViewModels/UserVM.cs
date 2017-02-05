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
            string lastName
        ) 
        {
            Id = id;
            Client = client;
            Username = username;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Id { get; set; }

        public string Client { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}