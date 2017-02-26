using System.Threading.Tasks;
using Common.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using Common.Dto;
using Common.Classes;
using System.Collections.Generic;

namespace Common.Security
{
    public class UserStore : IUserStore<User>
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
                var result = userService.Add(user);
                
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken) 
        {

        }

        public async Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var userResult = await userService.GetById(userId);
            return userResult.Value;
        }

        public async Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {

        }

        public async Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            var dbUserResult = await userService.GetById(user.Id);
            return dbUserResult.Value.Username;
        }

        public async Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {

        }

        public async Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {

        }

        public async Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
        }

        public async Task SetUserNameAsync(TUser user, string userName, CancellationToken cancellationToken)
        {

        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            Result<User> result = await userService.Update(user);
            var identityResults = new List<IdentityResult> ();
            var identityErrors = new List<IdentityError>();

            
            // var identityResults = new IdentityResult [IdentityResult. ];

            
            return result.IsSuccess 
                ? IdentityResult.Success
                : IdentityResult.Failed(identityResults)
            
        }
    }
}