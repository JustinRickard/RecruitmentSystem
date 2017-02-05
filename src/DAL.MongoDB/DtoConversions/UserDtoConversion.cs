using System.Collections.Generic;
using System.Linq;
using DAL.MongoDB.Models;
using Common.Dto;

namespace DAL.MongoDB.DtoConversions
{
    public static class UserDtoConversion
    {
        public static User ToDto(this DbUser dbUser) 
        {
            return new User {
                FirstName = dbUser.FirstName
            };
        }

        public static DbUser ToDb(this User user) 
        {
            return new DbUser {
                FirstName = user.FirstName
            };
        }

        public static IEnumerable<User> ToDto(this IEnumerable<DbUser> users) {
            return users.Select(user => user.ToDto());
        }

        public static IEnumerable<DbUser> ToDto(this IEnumerable<User> users) {
            return users.Select(user => user.ToDb());
        }
    }
}