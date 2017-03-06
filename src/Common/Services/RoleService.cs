using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Classes;
using Common.Dto;
using Common.Enums;
using Common.Interfaces.Repositories;
using Common.Interfaces.Services;

namespace Common.Services
{
    public class RoleService : IRoleService
    {
        private IRoleRepository roleRepository;

        public RoleService(
            IRoleRepository roleRepository
        )
        {
            this.roleRepository = roleRepository;
        }
        public async Task<Result<Role>> GetById(string id)
        {
            var role = await roleRepository.GetById(id);
            
            return ReturnMaybeRole(role);
        }

        public async Task<Result<Role>> GetByName(string name)
        {
            var role = await roleRepository.GetByName(name);

            return ReturnMaybeRole(role);
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await roleRepository.GetAll();
        }

        public async Task<Result<Role>> Add(Role role)
        {
            var addResult = await roleRepository.Add(role);
            if (addResult.HasNoValue)
            {
                return Result<Role>.Fail(ResultCode.CouldNotAdd, role.Name);
            }

            return Result<Role>.Succeed(addResult.Value);
        }

        public async Task<Result<Role>> Update(Role role)
        {
            var updateResult = await roleRepository.Update(role);
            if (updateResult.HasNoValue)
            {
                return Result<Role>.Fail(ResultCode.CouldNotUpdate, role.Id);
            }

            return Result<Role>.Succeed(updateResult.Value);
        }

        public async Task<Result> Delete(string id)
        {
            await roleRepository.Delete(id);
            return Result.Succeed();
        }

        public async Task<Result> Obliterate(string id)
        {
            await roleRepository.Obliterate(id);
            return Result.Succeed();
        }

        private Result<Role> ReturnMaybeRole(Maybe<Role> maybeRole) 
        {
            if (maybeRole.HasNoValue)
            {
                return Result<Role>.Fail(ResultCode.NotFound);
            }

            return Result<Role>.Succeed(maybeRole.Value);
        }
    }
}