using DAL.MongoDB.Interfaces.Models;
using Core.Dtos;

namespace DAL.MongoDB.DtoConversions
{
    public static class UserDtoConversion
    {
        public static Core.Dtos.User ToDto(this DbUser dbUser) 
        {
            return new Core.Dtos.User {
                FirstName = dbUser.FirstName
            };
        }
    }
}