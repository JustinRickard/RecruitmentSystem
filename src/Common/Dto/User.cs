namespace Common.Dto
{
    public class User
    {
        public User() {}

        public User(
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

        public string Id { get; set; }
        public string Client { get; set; }
        public string Username  { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Email     { get; set; }
    }
}