using System.Threading.Tasks;
using System.Collections.Generic;
using Common.Interfaces.Repositories;
using Common.Interfaces.Services;
using Common.Dto;
using Common.Classes;
using Common.Enums;
using Common.Interfaces.Helpers;
using System.Threading;

namespace Common.Services
{
    public class UserService : ServiceBase, IUserService
    {
        IUserRepository userRepository;

        public UserService (
            IUserRepository userRepository,
            IAuditRepository auditRepository,
            IJsonHelper jsonHelper
        ) : base (auditRepository, jsonHelper)
        {
            this.userRepository = userRepository;
        }

        public async Task<Result<User>> GetById(string id) 
        {
            var user = await userRepository.GetById(id);
            return ReturnMaybeUser(user);
        }

        public async Task<Result<User>> GetByUsername(string username)
        {
            var user = await userRepository.GetByUsername(username);
            return ReturnMaybeUser(user);
        }

        public async Task<Result<User>> GetByLoginCredentials(LoginCredentials credentials)
        {
            var user = await userRepository.GetByLoginCredentials(credentials);
            return ReturnMaybeUser(user);
        }

        public async Task<IEnumerable<User>> GetAll() {
            var users = await userRepository.GetAll();
            return users;
        }

        public async Task<Result<User>> Add(User user) 
        {
            Audit<User>(AuditType.UserRecord, Constants.Resources.Keycodes.User.AttemptAdd, user);

            // Validate user object

            var existingUser = await userRepository.GetByUsername(user.Username);
            if (existingUser.HasValue) {
                return Result<User>.Fail(ResultCode.AlreadyExists, user.Username);
            }

            await userRepository.Add(user);
            var newUser = await userRepository.GetByUsername(user.Username);
            Audit<User>(AuditType.UserRecord, Constants.Resources.Keycodes.User.AddComplete, newUser.Value);
            
            return Result<User>.Succeed(newUser.Value);
        }

        public async Task<Result<string>> GetPasswordHash(string userId, CancellationToken cancellationToken)
        {
            var dbUserResult = await userRepository.GetById(userId);

            if (dbUserResult.HasValue) {
                return Result<string>.Fail(ResultCode.NotFound, userId.ToString());
            }

            var passwordResult = await userRepository.GetPasswordHash(userId);

            return passwordResult.HasValue
                ? Result<string>.Succeed(passwordResult.Value)
                : Result<string>.Fail(ResultCode.NotFound);
        }

        public async Task<Result<User>> Update(User user) 
        {
            Audit<User>(AuditType.UserRecord, Constants.Resources.Keycodes.User.AttemptEdit, user);

            var newUser = await userRepository.Update(user);

            Audit<User>(AuditType.UserRecord, Constants.Resources.Keycodes.User.EditComplete, newUser.Value);

            return ReturnMaybeUser(newUser);
        }

        public async Task<Result> UpdatePassword(User user, string passwordHash, CancellationToken cancellationToken)
        {
            Audit<User>(AuditType.UserRecord, Constants.Resources.Keycodes.User.AttemptUpdatePassword, user);

            var result = await userRepository.UpdatePassword(user, passwordHash, cancellationToken);    
            if (result.HasNoValue)
            {
                return Result.Fail(ResultCode.NotFound);
            }

            Audit<User>(AuditType.UserRecord, Constants.Resources.Keycodes.User.UpdatePasswordComplete, user);
            return Result.Succeed();
        }

        public async Task<Result<User>> SetUsername(User user, string username, CancellationToken cancellationToken)
        {
            Audit<User>(AuditType.UserRecord, Constants.Resources.Keycodes.User.AttemptEditUsername, user);

            var result = await userRepository.UpdateUsername(user, username, cancellationToken);

            if (result.HasNoValue)
            {
                return Result<User>.Fail(ResultCode.NotFound);
            }

            Audit<User>(AuditType.UserRecord, Constants.Resources.Keycodes.User.EditUsernameComplete, user);
            return Result<User>.Succeed(result.Value);
        }

        public async Task<Result<User>> SetNormalizedUsername(User user, string normalizedUsername, CancellationToken cancellationToken)
        {
            Audit<User, object>(AuditType.UserRecord, Constants.Resources.Keycodes.User.AttemptEditNormalizedUsername, user, new { NormalizedUsername = normalizedUsername });

            var result = await userRepository.UpdateNormalizedUsername(user, normalizedUsername, cancellationToken);

            // JR Temp 
            Audit<Maybe<User>>(AuditType.UserRecord, "Update normalized username response", result);

            if (result.HasNoValue)
            {
                return Result<User>.Fail(ResultCode.NotFound);
            }

            Audit<User>(AuditType.UserRecord, Constants.Resources.Keycodes.User.EditNormalizedUsernameComplete, user);
            return Result<User>.Succeed(result.Value);
        }

        public async Task<Result> Delete(string id) {
            await userRepository.Delete(id);
            return Result.Succeed();
        }

        public async Task<Result> Obliterate(string id) {
            await userRepository.Obliterate(id);
            return Result.Succeed();
        }

        private Result<User> ReturnMaybeUser(Maybe<User> user) {
            if (user.HasValue) {
                return Result<User>.Succeed(user.Value);
            }

            return Result<User>.Fail(ResultCode.NotFound);
        }

    }
}