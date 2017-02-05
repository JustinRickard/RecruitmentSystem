using System.Collections.Generic;
using System.Linq;
using Common.Dto;
using Site.Admin2.ViewModels;

namespace Site.Admin2.DtoConversions
{
    public static class UserDtoConversions
    {
        public static UserVM ToViewModel(this User user) {
            return new UserVM(
                user.Id, 
                "dummy client", 
                user.Username, 
                user.Email, 
                user.FirstName, 
                user.LastName
            );
        }

        public static IEnumerable<UserVM> ToViewModel(this IEnumerable<User> users) {
            return users.Select(user => user.ToViewModel());
        }
    }
}