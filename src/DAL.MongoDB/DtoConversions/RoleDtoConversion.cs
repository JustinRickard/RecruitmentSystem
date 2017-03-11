using System.Collections.Generic;
using System.Linq;
using Common.Dto;
using DAL.MongoDB.Models;
using MongoDB.Bson;

namespace DAL.MongoDB.DtoConversions
{
    public static class RoleDtoConversion
    {
        public static Role ToDto(this DbRole role)
        {
            return new Role
            {
                Id = role.Id.ToString(),
                Name = role.Name
            };
        }

        public static IEnumerable<Role> ToDto(this IEnumerable<DbRole> roles)
        {
            return roles.Select(x => x.ToDto());
        }

        public static DbRole ToDb(this Role role) {
            return new DbRole {
                // Id = new ObjectId(role.Id),
                Name = role.Name
            };
        }
        public static IEnumerable<DbRole> ToDb(this IEnumerable<Role> roles)
        {
            return roles.Select(x => x.ToDb());
        }    
    }
}