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
                Id = dbUser.Id,
                Username = dbUser.Username,
                NormalizedUserName = dbUser.NormalizedUserName,
                Email = dbUser.Email,
                FirstName = dbUser.FirstName,
                LastName = dbUser.LastName,
                PasswordHash = dbUser.PasswordHash,
                DateCreated = dbUser.DateCreated,
                LastModified = dbUser.LastModified,
                Deleted = dbUser.Deleted,
                EmailConfirmed = dbUser.EmailConfirmed,
                Token = dbUser.Token
            };
        }

        public static DbUser ToDb(this User user) 
        {
            return new DbUser {
                Id = user.Id,
                Username = user.Username,
                NormalizedUserName = user.NormalizedUserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = user.PasswordHash,
                Deleted = user.Deleted,
                EmailConfirmed = user.EmailConfirmed,
                Token = user.Token,
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