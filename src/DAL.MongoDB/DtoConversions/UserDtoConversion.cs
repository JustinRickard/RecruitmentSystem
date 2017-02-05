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
                Id = dbUser.Id.ToString(),
                Username = dbUser.Username,
                Email = dbUser.Email,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName
            };
        }

        public static DbUser ToDb(this User user) 
        {
            return new DbUser {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username
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