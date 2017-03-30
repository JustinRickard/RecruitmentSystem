using System.Threading.Tasks;
using Common.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using Common.Dto;
using Common.ExtensionMethods;
using Common.Interfaces.Repositories;
using Common.Interfaces.Helpers;
using Common.Services;
using Common.Enums;
using Common.Classes;
using Keycodes = Common.Constants.Resources.Keycodes.UserStore;
using System;

namespace Common.Security
{
    public class UserStore : ServiceBase, IUserStore<User>, IUserPasswordStore<User> //, IUserLoginStore<User>
    {
        private IUserService userService;

        public UserStore (
            IUserService userService,
            IAuditHelper auditHelper
        ) : base (auditHelper)
        {
            this.userService = userService;
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            await Audit<User>(Keycodes.AttemptCreateAsync, user);

            var result = await userService.Add(user);

            await Audit<User>(Keycodes.CreateAsyncComplete, user);

            return result.IsSuccess
                ? IdentityResult.Success
                : IdentityResult.Failed(result.ToIdentityErrors());
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken) 
        {
            await Audit<User>(Keycodes.AttemptDeleteAsync, user);

            var result = await userService.Delete(user.Id);

            await Audit<Result>(Keycodes.DeleteAsyncComplete, result);

            return result.IsSuccess
                    ? IdentityResult.Success
                    : IdentityResult.Failed(result.ToIdentityErrors());
        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            await Audit<string>(Keycodes.AttemptFindByIdAsync, userId);

            var result = await userService.GetById(userId);

            await Audit<Result<User>>(Keycodes.FindByIdAsyncComplete, result);

            return result.IsSuccess 
                ? result.Value 
                : null;
        }

        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            await Audit<string>(Keycodes.AttemptFindByNameAsync, normalizedUserName);

            var result = await userService.GetByNormalizedUsername(normalizedUserName);

            await Audit<Result<User>>(Keycodes.FindByNameAsyncComplete, result);

            return result.IsSuccess
                ? result.Value
                : null;
        }

        public async Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            await Audit<User>(Keycodes.AttemptGetNormalizedUserNameAsync, user);

            var result = user.Id.NotEmpty() 
                ? await userService.GetById(user.Id)
                : await userService.GetByUsername(user.Username);

            if (result.IsFailure)
            {
                throw new Exception(string.Format("GetNormalizedUserName: Failed to get user from DB. User: {0}", user));
            }

            await Audit<Result<User>>(Keycodes.GetNormalizedUserNameAsyncComplete, result);          
            return result.Value.NormalizedUserName;             
        }

        public async Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            await Audit<User>(Keycodes.AttemptGetUserIdAsync, user);

            if(user.Id.NotEmpty())
            {
                return user.Id;
            }
                
            var dbUserResult = await userService.GetByUsername(user.Username);
            if (dbUserResult.IsFailure)
            {
                throw new Exception(string.Format("GetUserIdAsync: Failed to get user from DB. User: {0}", user));
            };

            return dbUserResult.Value.Id;
        }

        public async Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            await Audit<User>(Keycodes.AttemptGetUserNameAsync, user);

            if (user.Username.NotEmpty())
            {
                return user.Username;
            }

            var dbUserResult = await userService.GetById(user.Id);
            if (dbUserResult.IsFailure)
            {
                throw new Exception(string.Format("GetUserNameAsync: Failed to get user from DB. User: {0}", user));
            }

            return dbUserResult.Value.Username;
        }

        public async Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            await Audit<User, object>(Keycodes.AttemptSetNormalizedUserNameAsync, user, new { normalizedName = normalizedName});

            var result = await userService.SetNormalizedUsername(user, normalizedName, cancellationToken);
            user.NormalizedUserName = normalizedName;

            await Audit<Result<User>>(Keycodes.SetNormalizedUserNameAsyncComplete, result);
        }

        public async Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            await Audit<User, object>(Keycodes.AttemptSetUserNameAsync, user, new { userName = userName});

            var result = await userService.SetUsername(user, userName, cancellationToken);
            user.Username = userName;

            await Audit<Result<User>>(Keycodes.SetUserNameAsyncComplete, result);
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            await Audit<User>(Keycodes.AttemptUpdateAsync, user);

            var getUserResult = await userService.GetById(user.Id);
            

            if (getUserResult.IsFailure) 
            {
                return IdentityResult.Failed(getUserResult.ToIdentityErrors());
            }

            var updateUserResult = await userService.Update(user);

            await Audit<Result<User>>(Keycodes.UpdateAsyncComplete, updateUserResult);
            
            return updateUserResult.IsSuccess 
                ? IdentityResult.Success
                : IdentityResult.Failed(updateUserResult.ToIdentityErrors());            
        }

        public async Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken) 
        {
            await Audit<User>(Keycodes.AttemptGetPasswordHashAsync, user);

            if (user.PasswordHash.NotEmpty())
            {
                return user.PasswordHash;
            }

            var result = await userService.GetPasswordHash(user.Id, cancellationToken);
            if (result.IsSuccess)
            {
                return result.Value;                
            }

            await Audit<Result<string>>(Keycodes.GetPasswordHashAsyncComplete, result);
            return null;                        
        }

        public async Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            await Audit<User>(Keycodes.AttemptHasPasswordAsync, user);

            if (user.PasswordHash.NotEmpty())
            {
                return true;
            }

            var password = await GetPasswordHashAsync(user, cancellationToken);

            await Audit<object>(Keycodes.HasPasswordAsyncComplete, new { password = password });

            return password.NotEmpty();
        }

        public async Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            await Audit<User, object>(Keycodes.AttemptSetPasswordHashAsync, user, new { passwordHash = passwordHash });

            var result = await userService.UpdatePassword(user, passwordHash, cancellationToken);
            user.PasswordHash = passwordHash;
            
            await Audit<Result>(Keycodes.SetPasswordHashAsyncComplete, result);
        }

        public async Task RemoveLoginAsync(User user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            await Audit<User, object>(Keycodes.AttemptRemoveLoginAsync, user, new { loginProvider =  loginProvider, providerKey = providerKey });

            var result = await userService.Delete(user.Id);
            if (result.IsFailure)
            {
                throw new Exception(string.Format("RemoveLoginAsync: Failed to delete user. User: {0}", user));
            }

            await Audit<Result>(Keycodes.RemoveLoginAsyncComplete, result);
        }

        public void Dispose () {
            this.userService = null;
        }

        private async Task Audit<T>(string prefix, T objectToSerialize)
        {
            await Audit<T>(AuditType.UserStore, prefix, objectToSerialize);
        }

        private async Task Audit<T1,T2>(string prefix, T1 objectToSerialize, T2 parameters)
        {
            await Audit<T1,T2>(AuditType.UserStore, prefix, objectToSerialize, parameters);
        }
    }
}