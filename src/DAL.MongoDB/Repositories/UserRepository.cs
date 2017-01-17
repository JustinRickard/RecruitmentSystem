using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Interfaces;
using DAL.MongoDB;
using DAL.MongoDB.Interfaces.Models;

namespace DAL.MongoDB.Repositories
{
    public class UserRepository : RepositoryBase
    {
        public UserRepository(IAppSettings appSettings) : base(appSettings) {
        }

        public async Task<User> GetById (ObjectId id) {
            using (var ctx = GetContext()) {
                var user = ctx.Users.Find(x => x.Id == id);
                return user.ToDto();
            };
        }

        public async Task<IEnumerable<User>> GetAll() {
            using (var ctx = GetContext()) {
                var users = await ctx.Users.AsQueryable().ToListAsync();
                return users.ToDto();
            }
        }

        public async Task Add(User user) {
            var dbUser = user.ToDto();
            using (var ctx = GetContext()) {
                await ctx.Users.InsertOneAsync(dbUser);
            }
        }

        public async Task Update(User user) {
            using (var ctx =  GetContext()) {
                var oldUser = await ctx.Users.Find(x => x.Id == user.Id);
                if (oldUser != null) {
                    var filter = Builders<DbUser>.Filter.Eq(x => x.Id, user.Id);
                    var update = Builders<DbUser>.Update
                        .Set(x => x.Email, user.Email)
                        .Set(x => x.FirstName, user.FirstName)
                        .Set(x => x.LastName, user.LastName)
                        .Set(x => x.PhoneNumbers, user.PhoneNumbers);

                    await ctx.Users.UpdateOneAsync(filter, update);
                }
            }
        }

        public async Task Obliterate (User user) {
            using (var ctx = GetContext()) {
                var oldUser = ctx.Users.AsQueryable().Where(x => x.Id == user.Id).SingleOrDefault();
                if (oldUser != null) {
                    var filter = Builders<User>.Filter.Eq(x => x.Id, user.Id);
                    await ctx.Users.DeleteOneAsync(filter);
                } //
            }
        }
    }
}