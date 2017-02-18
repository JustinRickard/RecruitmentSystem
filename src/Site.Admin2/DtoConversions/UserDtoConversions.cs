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
                user.LastName,
                user.DateCreated,
                user.LastModified,
                user.Deleted
            );
        }

        public static IEnumerable<UserVM> ToViewModel(this IEnumerable<User> users) {
            return users.Select(user => user.ToViewModel());
        }

        public static User ToDto(this UserVM user) {
            return new User(
                user.Id,
                user.Client, 
                user.FirstName, 
                user.LastName,
                user.Email, 
                user.Username,
                user.DateCreated,
                user.LastModified,
                user.Deleted
            );
        }
    }
}