using System.Threading;
using System.Threading.Tasks;
using Common.Classes;
using Common.Dto;
using Common.ExtensionMethods;
using Common.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace Common.Security
{
    public class RoleStore : IRoleStore<Role>
    {   
        private IRoleService roleService;

        public RoleStore(IRoleService roleService) {
            this.roleService = roleService;
        }

        public async Task<IdentityResult> CreateAsync(Role role, CancellationToken cancellationToken)
        {
            var result = await roleService.Add(role);

            return result.ToIdentityResult();
        }
 
        public async Task<IdentityResult> DeleteAsync(Role role, CancellationToken cancellationToken)
        {
            var result = await roleService.Delete(role.Id);

            return result.ToIdentityResult();
        }
        public async Task<Role> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            var result = await roleService.GetById(roleId);

            return result.IsSuccess
                ? result.Value
                : null;
        }
        public async Task<Role> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            var result = await roleService.GetByName(normalizedRoleName);

            return result.IsSuccess
                ? result.Value
                : null;            
        }

        public Task<string> GetNormalizedRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }
        
        public Task<string> GetRoleIdAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id);
        }
        
        public Task<string> GetRoleNameAsync(Role role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }
        
        public async Task SetNormalizedRoleNameAsync(Role role, string normalizedName, CancellationToken cancellationToken)
        {
            var newRole = new Role {
                Id = role.Id,
                Name = normalizedName
            };

            await roleService.Update(role);
        }
        
        public async Task SetRoleNameAsync(Role role, string roleName, CancellationToken cancellationToken)
        {
            var newRole = new Role {
                Id = role.Id,
                Name = roleName
            };

            await roleService.Update(role);
        }
        public async Task<IdentityResult> UpdateAsync(Role role, CancellationToken cancellationToken)
        {
            var result = await roleService.Update(role);

            return result.ToIdentityResult();
        }

        public void Dispose() 
        {
            this.roleService = null;
        }
    }
}