using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Classes;
using Common.Dto;
using Common.Interfaces.Repositories;
using DAL.MongoDB.DtoConversions;
using DAL.MongoDB.Interfaces;
using DAL.MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DAL.MongoDB.Repositories
{
    public class RoleRepository : RepositoryBase, IRoleRepository
    {
        public RoleRepository(
            IOptions<AppSettings> appSettings
        ) : base(appSettings)
        {
            
        }

        public async Task<Maybe<Role>> GetById (string id)
        {
            using (var ctx = GetContext()) {
                var role = await ctx.Roles.AsQueryable().Where(x => x.Id == id).SingleOrDefaultAsync();
                return ReturnMaybeRole(role);
            }
        }

        public async Task<Maybe<Role>> GetByName (string name)
        {
            using (var ctx = GetContext()) {
                var role = await ctx.Roles.AsQueryable().Where(x => x.Name == name).SingleOrDefaultAsync();
                return ReturnMaybeRole(role);
            }
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            using (var ctx = GetContext()) {
                var roles = await ctx.Roles.AsQueryable().Where(x => x.Deleted == false).ToListAsync();
                return roles.ToDto();
            }
        }

        public async Task<Maybe<Role>> Add (Role role)
        {
            using (var ctx = GetContext()) {
                await ctx.Roles.InsertOneAsync(role.ToDb());
                var newRole = await ctx.Roles.AsQueryable().Where(x => x.Name == role.Name).SingleOrDefaultAsync();

                return ReturnMaybeRole(newRole);
            }
        }

        public async Task<Maybe<Role>> Update (Role role)
        {
            using (var ctx = GetContext()) {
                var oldRole = await ctx.Roles.AsQueryable().Where(x => x.Id == role.Id).SingleOrDefaultAsync();
                if (oldRole != null) {
                    var filter = Builders<DbRole>.Filter.Eq(x => x.Id, oldRole.Id);
                    var update = Builders<DbRole>.Update
                        .Set(x => x.Name, role.Name);

                    await ctx.Roles.UpdateOneAsync(filter, update);

                    var newRole = await ctx.Roles.AsQueryable().Where(x => x.Id == role.Id).SingleOrDefaultAsync();                    
                    return ReturnMaybeRole(newRole);
                }
                return null;
            }
        }

        public async Task Delete (string id)
        {
            using (var ctx = GetContext()) {
                var role = await ctx.Roles.AsQueryable().Where(x => x.Id == id).SingleOrDefaultAsync();
                if (role != null) {
                    var filter = Builders<DbRole>.Filter.Eq(x => x.Id, role.Id);
                    var update = Builders<DbRole>.Update
                        .Set(x => x.Deleted, true)
                        .Set(x => x.LastModified, DateTimeOffset.Now);
                    
                    await ctx.Roles.UpdateOneAsync(filter, update);
                }
            }
        }

        public async Task Obliterate(string id)
        {
            using (var ctx = GetContext()) {
                var role = await ctx.Roles.AsQueryable().Where(x => x.Id == id).SingleOrDefaultAsync();
                if (role != null) {
                    var filter = Builders<DbRole>.Filter.Eq(x => x.Id, role.Id);
                    await ctx.Roles.DeleteOneAsync(filter);
                }
            }
        }

        private Maybe<Role> ReturnMaybeRole(DbRole role) 
        {
            return role != null 
                    ? new Maybe<Role>(role.ToDto())
                    : Maybe<Role>.Fail;
        }
    }
}