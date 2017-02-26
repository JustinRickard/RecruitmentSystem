using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Classes;
using Common.Dto;

namespace Common.Interfaces.Services
{
    public interface IRoleService
    {
        Task<Result<Role>> GetById(string id);

        Task<Result<Role>> GetByName(string name);

         Task<IEnumerable<Role>> GetAll();

         Task<Result<Role>> Add(Role role);

         Task<Result<Role>> Update(Role role);

         Task<Result> Delete(string id);

         Task<Result> Obliterate(string id);
    }
}