using System.Threading.Tasks;
using Common.Interfaces.Repositories;
using Common.Dto;

namespace Common.Services
{
    public class UserService
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

        public Task Add(User user) 
        {
            return userRepository.Add(user);
        }

    }
}