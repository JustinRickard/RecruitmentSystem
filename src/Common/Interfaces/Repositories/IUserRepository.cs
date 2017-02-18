using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Classes;
using Common.Dto;
using Common.SearchFilters;

namespace Common.Interfaces.Repositories
{
    public interface IUserRepository
    {
         Task<Maybe<User>> GetById (string id);

         Task<Maybe<User>> GetByUsername(string username);

         Task<Maybe<User>> GetByLoginCredentials (LoginCredentials credentials);

         Task<IEnumerable<User>> GetAll();

         Task<IEnumerable<User>> Get(UserFilter filter);

         Task<Maybe<User>> Add (User user);

         Task<Maybe<User>> Update (User user);

         Task Delete(string id);

         Task Obliterate(string id);
    }
}