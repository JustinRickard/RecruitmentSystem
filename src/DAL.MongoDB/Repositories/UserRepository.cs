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
        public UserRepository(IOptions<AppSettings> appSettings) : base(appSettings) {

        }

        public async Task<User> GetById (string id) {
            using (var ctx = GetContext()) {
                var user = await ctx.Users.AsQueryable().Where(x => x.Id == new ObjectId(id)).SingleOrDefaultAsync();
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
            
            using (var ctx = GetContext()) {
                var dbUser = user.ToDb();
                UpdateDateCreated(dbUser);
                await ctx.Users.InsertOneAsync(dbUser);
            }
        }

        public async Task<User> Update(User user) {
            using (var ctx =  GetContext()) {
                var oldUser = await ctx.Users.AsQueryable().Where(x => x.Id == new ObjectId(user.Id)).SingleOrDefaultAsync();
                if (oldUser != null) {
                    var filter = Builders<DbUser>.Filter.Eq(x => x.Id, oldUser.Id);
                    var update = Builders<DbUser>.Update
                        .Set(x => x.Email, user.Email)
                        .Set(x => x.FirstName, user.FirstName)
                        .Set(x => x.LastName, user.LastName)
                        .Set(x => x.LastModified, DateTime.Now);

                    await ctx.Users.UpdateOneAsync(filter, update);

                    var newUser = await ctx.Users.AsQueryable().Where(x => x.Id == new ObjectId(user.Id)).SingleOrDefaultAsync();
                    return newUser.ToDto();
                }
                throw new Exception(string.Format("User not found with id {0}", user.Id)); // TODO: Handle exceptions
            }
        }

        public async Task Delete(string id) {
            using (var ctx = GetContext()) {
                var user = await ctx.Users.AsQueryable().Where(x => x.Id == new ObjectId(id)).SingleOrDefaultAsync();
                if (user != null) {
                    var filter = Builders<DbUser>.Filter.Eq(x => x.Id, user.Id);
                    var update = Builders<DbUser>.Update
                        .Set(x => x.Deleted, true)
                        .Set(x => x.LastModified, DateTimeOffset.Now);
                }
            }
        }

        public async Task Obliterate (string id) {
            using (var ctx = GetContext()) {
                var user = await ctx.Users.AsQueryable().Where(x => x.Id == new ObjectId(id)).SingleOrDefaultAsync();
                if (user != null) {
                    var filter = Builders<DbUser>.Filter.Eq(x => x.Id, user.Id);
                    await ctx.Users.DeleteOneAsync(filter);
                }
            }
        }
    }
}