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
using Common.Enums;

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

        public async Task<Maybe<User>> GetById (string id) 
        {
                var dbUser = await GetOne<DbUser>(id);
                return MaybeUser(dbUser);
        }

        public async Task<IEnumerable<User>> Get(UserFilter filter)
        {
            using (var ctx = GetContext()) {
                var users = await Filter(ctx, filter).ToListAsync();
                return users.ToDto();
            }
        }        

        public async Task<Maybe<User>> GetByUsername (string username) 
        {
            using (var ctx = GetContext()) {
                var user = await ctx.Users.AsQueryable().Where(x => x.Username == username).SingleOrDefaultAsync();
                return MaybeUser(user);
            };
        }

        public async Task<Maybe<User>> GetByNormalizedUsername(string normalizedUsername)
        {
            using (var ctx = GetContext()) {
                var user = await ctx.Users.AsQueryable().Where(x => x.NormalizedUserName == normalizedUsername).SingleOrDefaultAsync();                
                return MaybeUser(user);
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
            var maybeUser = await GetOne<DbUser>(userId);

            return  maybeUser.HasValue && maybeUser.Value.PasswordHash.NotEmpty()
                ? new Maybe<string>(maybeUser.Value.PasswordHash)
                : Maybe<string>.Fail;
        }

        // ADD
        public async Task<Maybe<User>> Add(User user) 
        {
            var addedUser = await Add<DbUser>(user.ToDb());
            return MaybeUser(addedUser);
        }

        // UPDATE
        public async Task<Maybe<User>> Update(User user) 
        {
            var update = Builders<DbUser>.Update
                .Set(x => x.Email, user.Email)
                .Set(x => x.FirstName, user.FirstName)
                .Set(x => x.LastName, user.LastName)
                .Set(x => x.EmailConfirmed, user.EmailConfirmed);

            return await UpdateAndReturn<DbUser>(user.Id, update);           
        }

        public async Task<Maybe<User>> UpdateUsername (User user, string username, CancellationToken cancellationToken)
        {
            var update = Builders<DbUser>.Update
                        .Set(x => x.Username, username);
            return await UpdateAndReturn<DbUser>(user.Id, update);
        }

        public async Task<Maybe<User>> UpdateNormalizedUsername (User user, string normalizedUsername, CancellationToken cancellationToken)
        {
            var update = Builders<DbUser>.Update
                .Set(x => x.NormalizedUserName, normalizedUsername);
            return await UpdateAndReturn<DbUser>(user.Id, update);
        }
    

        public async Task<Maybe<User>> UpdatePassword(User user, string passwordHash, CancellationToken cancellationToken)
        {
            var update = Builders<DbUser>.Update
                        .Set(x => x.PasswordHash, passwordHash);
            return await UpdateAndReturn<DbUser>(user.Id, update);
        }

        // DELETE
        public async Task Delete(string id) 
        {
            await Delete<DbUser>(id);
        }
        
        public async Task Obliterate (string id) 
        {
            await Obliterate<DbUser>(id);
        }

        // HELPER METHODS

        private Maybe<User> MaybeUser(Maybe<DbUser> user) 
        {
            return user.HasValue
                    ? MaybeUser(user.Value)
                    : Maybe<User>.Fail;
        }

        private Maybe<User> MaybeUser(DbUser user) 
        {
            return user != null 
                    ? new Maybe<User>(user.ToDto())
                    : Maybe<User>.Fail;
        }

        private async Task<Maybe<User>> UpdateAndReturn<TEntity>(string id, UpdateDefinition<DbUser> update)
        {
            var updatedUser = await Update<DbUser>(id, update);
            return MaybeUser(updatedUser);
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

            return query;
        }
    }
}