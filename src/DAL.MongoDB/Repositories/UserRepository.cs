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

namespace DAL.MongoDB.Repositories
{
    public class UserRepository : RepositoryBase
    {
        public UserRepository(IAppSettings appSettings) : base(appSettings) {
        }

        public async Task<User> GetById (Guid id) {
            using (var ctx = GetContext()) {
                var user = await ctx.Users.AsQueryable().Where(x => x.Id == id).SingleOrDefaultAsync();
                return user;
            };
        }

        public async Task<IEnumerable<User>> GetAll() {
            using (var ctx = GetContext()) {
                var users = await ctx.Users.AsQueryable().ToListAsync();
                return users;
            }
        }

        public async Task Add(User user) {
            using (var ctx = GetContext()) {
                await ctx.Users.InsertOneAsync(user);
            }
        }

        public async Task Update(User user) {
            using (var ctx =  GetContext()) {
                var oldUser = ctx.Users.AsQueryable().Where(x => x.Id == user.Id).SingleOrDefault();
                if (oldUser != null) {
                    var filter = Builders<User>.Filter.Eq(x => x.Id, user.Id);
                    var update = Builders<User>.Update
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