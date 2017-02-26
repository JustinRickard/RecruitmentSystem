using System.Threading.Tasks;
using Common.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using Common.Dto;
using Common.Classes;
using System.Collections.Generic;
using Common.ExtensionMethods;

namespace Common.Security
{
    public class UserStore : IUserStore<User>, IUserPasswordStore<User>
    {
        private IUserService userService;

        public UserStore (
            IUserService userService
        )
        {
            this.userService = userService;
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken) 
        {
                var result = await userService.Add(user);

                return result.IsSuccess
                    ? IdentityResult.Success
                    : IdentityResult.Failed(result.ToIdentityErrors());
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken) 
        {
            var result = await userService.Delete(user.Id);

            return result.IsSuccess
                    ? IdentityResult.Success
                    : IdentityResult.Failed(result.ToIdentityErrors());
        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var userResult = await userService.GetById(userId);

            return userResult.IsSuccess 
                ? userResult.Value 
                : null;
        }

        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var result = await userService.GetByUsername(normalizedUserName);

            return result.IsSuccess
                ? result.Value
                : null;
        }

        public async Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            var dbUserResult = await userService.GetById(user.Id);

            return dbUserResult.IsSuccess 
                ? dbUserResult.Value.Username
                : string.Empty;

        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Username);
        }

        public async Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            await userService.SetUsername(user, normalizedName, cancellationToken);           
        }

        public async Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            await userService.SetUsername(user, userName, cancellationToken);
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            var getUserResult = await userService.GetById(user.Id);

            if (getUserResult.IsFailure) 
            {
                return IdentityResult.Failed(getUserResult.ToIdentityErrors());
            }

            var updateUserResult = await userService.Update(user);
            
            return updateUserResult.IsSuccess 
                ? IdentityResult.Success
                : IdentityResult.Failed(updateUserResult.ToIdentityErrors());            
        }

        Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken) 
        {
            return userService.GetPasswordHash(user, cancellationToken);
        }

        Task<bool> HasPasswordAsync(TUser user, CancellationToken cancellationToken)
        {

        }

        Task SetPasswordHashAsync(TUser user, string passwordHash, CancellationToken cancellationToken)
        {

        }

        

        public void Dispose () {
            this.userService = null;
        }
    }
}