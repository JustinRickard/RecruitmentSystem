using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Interfaces.Repositories;
using Common.Dto;
using Common.Classes;
using DAL.MongoDB.DtoConversions;
using DAL.MongoDB;
using DAL.MongoDB.Models;
using DAL.MongoDB.Interfaces;
using Common.Interfaces.Helpers;
using Common.SearchFilters;
using Common.ExtensionMethods;
using System.Threading;

namespace DAL.MongoDB.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        private IPasswordHelper passwordHelper;

        public UserRepository(
            IOptions<AppSettings> appSettings,
            IPasswordHelper passwordHelper
            ) : base(appSettings) {
            this.passwordHelper = passwordHelper;
        }

        // GET        
        public async Task<IEnumerable<User>> GetAll() 
        {
            var dbUsers = await GetAllNotDeleted<DbUser>();
            return dbUsers.ToDto();
        }

        public async Task<IEnumerable<User>> Get(UserFilter filter)
        {
            using (var ctx = GetContext()) {

                var users = await Filter(ctx, filter)
                    .ToListAsync();

                return users.ToDto();
            }
        }

        public async Task<Maybe<User>> GetById (string id) 
        {
                var dbUser = await GetOne<DbUser>(id);
                return ReturnMaybeUser(dbUser);
        }

        public async Task<Maybe<User>> GetByUsername (string username) 
        {
            using (var ctx = GetContext()) {
                var user = await ctx.Users.AsQueryable().Where(x => x.Username == username).SingleOrDefaultAsync();

                return ReturnMaybeUser(user);
              };
        }

        public async Task<Maybe<User>> GetByLoginCredentials (LoginCredentials credentials) 
        {
            using (var ctx = GetContext()) {
                var user = await ctx.Users.AsQueryable()
                    .Where(x => x.Username == credentials.Username)
                    .SingleOrDefaultAsync();

                return user != null && passwordHelper.IsValid(credentials.Password, user.PasswordHash)
                    ? new Maybe<User> (user.ToDto())
                    : Maybe<User>.Fail;             
            }
        }

        public async Task<Maybe<string>> GetPasswordHash (string userId) {
            using (var ctx = GetContext()) 
            {
                var user = await ctx.Users.AsQueryable().Where(x => x.Id == userId).SingleOrDefaultAsync();
                
                return user != null
                    ? new Maybe<string> (user.PasswordHash)
                    : Maybe<string>.Fail;
            }
        }

        // ADD
        public async Task<Maybe<User>> Add(User user) 
        {
            var dbUser = user.ToDb();
            SetInitialRecordValues(dbUser);

            using (var ctx = GetContext()) {
                 await ctx.Users.InsertOneAsync(dbUser);
                 var newUser = ctx.Users.AsQueryable().Where(x => x.Username == user.Username).FirstOrDefault();
                 return ReturnMaybeUser(newUser);
            }
        }

        // UPDATE
        public async Task<Maybe<User>> Update(User user) 
        {
            using (var ctx =  GetContext()) {
                var oldUser = await ctx.Users.AsQueryable().Where(x => x.Id == user.Id).SingleOrDefaultAsync();
                if (oldUser != null) {
                    var filter = Builders<DbUser>.Filter.Eq(x => x.Id, oldUser.Id);
                    var update = Builders<DbUser>.Update
                        .Set(x => x.Email, user.Email)
                        .Set(x => x.FirstName, user.FirstName)
                        .Set(x => x.LastName, user.LastName)
                        .Set(x => x.LastModified, DateTime.Now);

                    await ctx.Users.UpdateOneAsync(filter, update);

                    var newUser = await ctx.Users.AsQueryable().Where(x => x.Id == user.Id).SingleOrDefaultAsync();
                    
                    return ReturnMaybeUser(newUser);
                }
                return null;
            }
        }

        public async Task<Maybe<User>> UpdateUsername (User user, string username, CancellationToken cancellationToken)
        {
            using (var ctx =  GetContext()) {
                var oldUser = await ctx.Users.AsQueryable().Where(x => x.Id == user.Id).SingleOrDefaultAsync();
                if (oldUser != null) {
                    var filter = Builders<DbUser>.Filter.Eq(x => x.Id, oldUser.Id);
                    var update = Builders<DbUser>.Update
                        .Set(x => x.Username, username);
                    
                    await ctx.Users.UpdateOneAsync(filter, update, null, cancellationToken);

                    var newUser = await ctx.Users.AsQueryable().Where(x => x.Id == user.Id).SingleOrDefaultAsync();
                    return ReturnMaybeUser(newUser);
                }
                return null;
            }
        }

        public async Task<Maybe<User>> UpdatePassword(User user, string passwordHash, CancellationToken cancellationToken)
        {
            using (var ctx =  GetContext()) {
                var oldUser = await ctx.Users.AsQueryable().Where(x => x.Id == user.Id).SingleOrDefaultAsync();
                if (oldUser != null) {
                    var filter = Builders<DbUser>.Filter.Eq(x => x.Id, oldUser.Id);
                    var update = Builders<DbUser>.Update
                        .Set(x => x.PasswordHash, passwordHash);
                    
                    await ctx.Users.UpdateOneAsync(filter, update, null, cancellationToken);

                    var newUser = await ctx.Users.AsQueryable().Where(x => x.Id == user.Id).SingleOrDefaultAsync();
                    return ReturnMaybeUser(newUser);
                }
                return null;
            }
        }

        // DELETE
        public async Task Delete(string id) 
        {
            using (var ctx = GetContext()) {
                var user = await ctx.Users.AsQueryable().Where(x => x.Id == id).SingleOrDefaultAsync();
                if (user != null) {
                    var filter = Builders<DbUser>.Filter.Eq(x => x.Id, user.Id);
                    var update = Builders<DbUser>.Update
                        .Set(x => x.Deleted, true)
                        .Set(x => x.LastModified, DateTimeOffset.Now);
                    
                    await ctx.Users.UpdateOneAsync(filter, update);
                }
            }
        }

        public async Task Obliterate (string id) 
        {
            using (var ctx = GetContext()) {
                var user = await ctx.Users.AsQueryable().Where(x => x.Id == id).SingleOrDefaultAsync();
                if (user != null) {
                    var filter = Builders<DbUser>.Filter.Eq(x => x.Id, user.Id);
                    await ctx.Users.DeleteOneAsync(filter);
                }
            }
        }

        // HELPER METHODS

        private Maybe<User> ReturnMaybeUser(Maybe<DbUser> user) 
        {
            return user.HasValue
                    ? ReturnMaybeUser(user.Value)
                    : Maybe<User>.Fail;
        }

        private Maybe<User> ReturnMaybeUser(DbUser user) 
        {
            return user != null 
                    ? new Maybe<User>(user.ToDto())
                    : Maybe<User>.Fail;
        }

        private IMongoQueryable<DbUser> Filter (RsMongoContext ctx, UserFilter filter) 
        {
            var query = ctx.Users.AsQueryable();

            if (filter.ClientId.NotEmpty()) {
                query = query.Where(x => x.ClientId == filter.ClientId);
            }

            if (filter.FirstName.NotEmpty()) {
                query = query.Where(x => x.FirstName.CaseInsensitiveEquals(filter.FirstName));
            }

            if (filter.LastName.NotEmpty()) {
                query = query.Where(x => x.LastName.CaseInsensitiveEquals(filter.LastName));
            }

            if (filter.Email.NotEmpty()) {
                query = query.Where(x => x.Email.CaseInsensitiveEquals(filter.Email));
            }

            if (filter.Username.NotEmpty()) {
                query = query.Where(x => x.Username.CaseInsensitiveEquals(filter.Username));
            }

            if (filter.Gender.HasValue) {
                query = query.Where(x => x.Gender == filter.Gender);
            }

            return query;
        }
    }
}