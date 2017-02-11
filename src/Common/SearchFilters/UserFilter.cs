using Common.Enums;

namespace Common.SearchFilters
{
    public class UserFilter
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public string ClientId { get; set; }
    }
}