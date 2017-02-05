using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Interfaces;
using Common.Interfaces.Repositories;
using Common.Dto;
using Common.Classes;
using DAL.MongoDB.DtoConversions;
using DAL.MongoDB;
using DAL.MongoDB.Models;
using DAL.MongoDB.Interfaces;

namespace DAL.MongoDB.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        // TODO: Return classes from Common
        public UserRepository(IOptions<AppSettings> appSettings) : base(appSettings) {

        }

        public async Task<User> GetById (string id) {
            using (var ctx = GetContext()) {
                var dbUser = (DbUser)await GetByIdGeneric(id, GetCollection((IMongoCollection<IDbRecord>)ctx.Users));
                return dbUser.ToDto();
            }

            /*
            using (var ctx = GetContext()) {
                var user = await ctx.Users.AsQueryable().Where(x => x.Id == id).SingleOrDefaultAsync();
                return user; //.ToDto();
            };
            */
        }

        public async Task<IEnumerable<User>> GetAll() {
            using (var ctx = GetContext()) {
                var users = await ctx.Users.AsQueryable().ToListAsync();
                return users.ToDto();
            }
        }

        public async Task Add(User user) {
            /*
            using (var ctx = GetContext()) {
                await ctx.Users.InsertOneAsync(user);
            }
            */
            var dbUser = user.ToDb();
            using (var ctx = GetContext()) {
                await AddGeneric(dbUser, GetCollection((IMongoCollection<IDbRecord>)ctx.Users));
            }
        }

        public async Task Update(DbUser user) {
            using (var ctx =  GetContext()) {
                var oldUser = ctx.Users.AsQueryable().Where(x => x.Id == user.Id).SingleOrDefaultAsync();
                if (oldUser != null) {
                    var filter = Builders<DbUser>.Filter.Eq(x => x.Id, user.Id);
                    var update = Builders<DbUser>.Update
                        .Set(x => x.Email, user.Email)
                        .Set(x => x.FirstName, user.FirstName)
                        .Set(x => x.LastName, user.LastName);

                    await ctx.Users.UpdateOneAsync(filter, update);
                }
            }
        }

        public async Task Obliterate (DbUser user) {
            using (var ctx = GetContext()) {
                var oldUser = ctx.Users.AsQueryable().Where(x => x.Id == user.Id).SingleOrDefault();
                if (oldUser != null) {
                    var filter = Builders<DbUser>.Filter.Eq(x => x.Id, user.Id);
                    await ctx.Users.DeleteOneAsync(filter);
                }
            }
        }
    }
}