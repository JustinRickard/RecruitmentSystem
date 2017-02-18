using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Classes;
using Common.Dto;

namespace Common.Interfaces.Services
{
    public interface IUserService
    {
         Task<Result<User>> GetById(string id);

         Task<Result<User>> GetByLoginCredentials(LoginCredentials credentials);

         Task<IEnumerable<User>> GetAll();

         Task<Result<User>> Add(User user);

         Task<Result<User>> Update(User user);

         Task<Result> Delete(string id);

         Task<Result> Obliterate(string id);

    }
}