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
    }
}