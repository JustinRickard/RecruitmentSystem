using System.Threading.Tasks;
using System.Collections.Generic;
using Common.Interfaces.Repositories;
using Common.Interfaces.Services;
using Common.Dto;

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

        public Task<User> GetById(string id) 
        {
            return userRepository.GetById(id);
        }

        public Task<User> GetByLoginCredentials(LoginCredentials credentials)
        {
            return userRepository.GetByLoginCredentials(credentials);
        }

        public Task<IEnumerable<User>> GetAll() {
            return userRepository.GetAll();
        }

        public Task Add(User user) 
        {
            return userRepository.Add(user);
        }

        public Task<User> Update(User user) 
        {
            return userRepository.Update(user);
        }

        public Task Delete(string id) {
            return userRepository.Delete(id);
        }

        public Task Obliterate(string id) {
            return userRepository.Obliterate(id);
        }

    }
}