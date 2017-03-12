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

namespace Common.Security
{
    public class UserStore : ServiceBase, IUserStore<User>, IUserPasswordStore<User> //, IUserLoginStore<User>
    {
        private IUserService userService;

        public UserStore (
            IUserService userService,
            IAuditRepository auditRepository,
            IJsonHelper jsonHelper
        ) : base (auditRepository, jsonHelper)
        {
            this.userService = userService;
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            Audit<User>(Keycodes.AttemptCreateAsync, user);

            var result = await userService.Add(user);

            Audit<User>(Keycodes.CreateAsyncComplete, user);

            return result.IsSuccess
                ? IdentityResult.Success
                : IdentityResult.Failed(result.ToIdentityErrors());
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken) 
        {
            Audit<User>(Keycodes.AttemptDeleteAsync, user);

            var result = await userService.Delete(user.Id);

            Audit<Result>(Keycodes.DeleteAsyncComplete, result);

            return result.IsSuccess
                    ? IdentityResult.Success
                    : IdentityResult.Failed(result.ToIdentityErrors());
        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            Audit<string>(Keycodes.AttemptFindByIdAsync, userId);

            var result = await userService.GetById(userId);

            Audit<Result<User>>(Keycodes.FindByIdAsyncComplete, result);

            return result.IsSuccess 
                ? result.Value 
                : null;
        }

        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            Audit<string>(Keycodes.AttemptFindByNameAsync, normalizedUserName);

            var result = await userService.GetByUsername(normalizedUserName);

            Audit<Result<User>>(Keycodes.FindByNameAsyncComplete, result);

            return result.IsSuccess
                ? result.Value
                : null;
        }

        public async Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            Audit<User>(Keycodes.AttemptGetNormalizedUserNameAsync, user);

            var result = await userService.GetById(user.Id);

            Audit<Result<User>>(Keycodes.GetNormalizedUserNameAsyncComplete, result);

            return result.IsSuccess 
                ? result.Value.Username
                : string.Empty;
        }

        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            Audit<User>(Keycodes.AttemptGetUserIdAsync, user);

            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            Audit<User>(Keycodes.AttemptGetUserNameAsync, user);

            return Task.FromResult(user.Username);
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            Audit<User, object>(Keycodes.AttemptSetNormalizedUserNameAsync, user, new { normalizedName = normalizedName});

            // var result = await userService.SetUsername(user, normalizedName, cancellationToken);

            // Audit<Result<User>>(Keycodes.SetNormalizedUserNameAsyncComplete, result);

            user.NormalizedUserName = normalizedName;
            return Task.CompletedTask;
        }

        public async Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            Audit<User, object>(Keycodes.AttemptSetUserNameAsync, user, new { userName = userName});

            var result = await userService.SetUsername(user, userName, cancellationToken);

            Audit<Result<User>>(Keycodes.SetUserNameAsyncComplete, result);
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            Audit<User>(Keycodes.AttemptUpdateAsync, user);

            var getUserResult = await userService.GetById(user.Id);
            

            if (getUserResult.IsFailure) 
            {
                return IdentityResult.Failed(getUserResult.ToIdentityErrors());
            }

            var updateUserResult = await userService.Update(user);

            Audit<Result<User>>(Keycodes.UpdateAsyncComplete, updateUserResult);
            
            return updateUserResult.IsSuccess 
                ? IdentityResult.Success
                : IdentityResult.Failed(updateUserResult.ToIdentityErrors());            
        }

        public async Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken) 
        {
            Audit<User>(Keycodes.AttemptGetPasswordHashAsync, user);

            var result = await userService.GetPasswordHash(user.Id, cancellationToken);   

            Audit<Result<string>>(Keycodes.GetPasswordHashAsyncComplete, result);        

            return result.IsSuccess
                ? result.Value
                : string.Empty;
        }

        public async Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            Audit<User>(Keycodes.AttemptHasPasswordAsync, user);

            var password = await GetPasswordHashAsync(user, cancellationToken);

            Audit<object>(Keycodes.HasPasswordAsyncComplete, new { password = password });

            return password.NotEmpty();
        }

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            Audit<User, object>(Keycodes.AttemptSetPasswordHashAsync, user, new { passwordHash = passwordHash });

            // var result = await userService.UpdatePassword(user, passwordHash, cancellationToken);
            user.PasswordHash = passwordHash;
            
            // Audit<Result>(Keycodes.SetPasswordHashAsyncComplete, result);
            return Task.CompletedTask;
        }

        public async Task RemoveLoginAsync(User user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            Audit<User, object>(Keycodes.AttemptRemoveLoginAsync, user, new { loginProvider =  loginProvider, providerKey = providerKey });

            var result = await userService.Delete(user.Id);

            Audit<Result>(Keycodes.RemoveLoginAsyncComplete, result);
        }

        public void Dispose () {
            this.userService = null;
        }

        private void Audit<T>(string prefix, T objectToSerialize)
        {
            Audit<T>(AuditType.UserStore, prefix, objectToSerialize);
        }

        private void Audit<T1,T2>(string prefix, T1 objectToSerialize, T2 parameters)
        {
            Audit<T1,T2>(AuditType.UserStore, prefix, objectToSerialize, parameters);
        }
    }
}