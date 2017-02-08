using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Dto;

namespace Common.Interfaces.Services
{
    public interface IUserService
    {
         Task<User> GetById(string id);

         Task<User> GetByLoginCredentials(LoginCredentials credentials);

         Task<IEnumerable<User>> GetAll();

         Task Add(User user);

         Task<User> Update(User user);

         Task Delete(string id);

         Task Obliterate(string id);

    }
}