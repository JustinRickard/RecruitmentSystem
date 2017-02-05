using System.Threading.Tasks;
using Common.Dto;

namespace Common.Interfaces.Repositories
{
    public interface IUserRepository
    {
         Task<User> GetById (string id);

         Task Add (User user);
    }
}