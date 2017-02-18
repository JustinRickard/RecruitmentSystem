using System.Threading.Tasks;
using System.Collections.Generic;
using Common.Interfaces.Repositories;
using Common.Interfaces.Services;
using Common.Dto;
using Common.Classes;
using Common.Enums;

namespace Common.Services
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;

        public UserService (
            IUserRepository userRepository
        )
        {
            this.userRepository = userRepository;
        }

        public async Task<Result<User>> GetById(string id) 
        {
            var user = await userRepository.GetById(id);
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
            // Validate user object

            var existingUser = await userRepository.GetByUsername(user.Username);
            if (existingUser.HasValue) {
                return Result<User>.Fail(ResultCode.AlreadyExists, user.Username);
            }

            await userRepository.Add(user);
            var newUser = await userRepository.GetByUsername(user.Username);
            
            return Result<User>.Succeed(newUser.Value);
        }

        public async Task<Result<User>> Update(User user) 
        {
            var newUser = await userRepository.Update(user);
            return ReturnMaybeUser(newUser);
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