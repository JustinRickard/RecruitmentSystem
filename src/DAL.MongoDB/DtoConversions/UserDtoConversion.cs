using System.Collections.Generic;
using System.Linq;
using DAL.MongoDB.Models;
using Common.Dto;
using MongoDB.Bson;

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
                LastName = dbUser.LastName,
                LastModified = dbUser.LastModified
            };
        }

        public static DbUser ToDb(this User user) 
        {
            return new DbUser {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                NormalizedUserName = user.NormalizedUserName,
                PasswordHash = user.PasswordHash,
                Token = user.Token
            };
        }

        public static IEnumerable<User> ToDto(this IEnumerable<DbUser> users) {
            return users != null 
                ? users.Select(user => user.ToDto())
                : new List<User>();
        }

        public static IEnumerable<DbUser> ToDto(this IEnumerable<User> users) {
            return users != null
                ? users.Select(user => user.ToDb())
                : new List<DbUser>();
        }
    }
}