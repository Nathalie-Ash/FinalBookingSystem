using IDS.Core.Interfaces;
using IDS.Core.Models;
using IDS.Core.Repositories;
using IDS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _roleRepository;
        public RoleService(IUnitOfWork unitOfWork, IRoleRepository roleRepository)
        {
            this._unitOfWork = unitOfWork;
            this._roleRepository = roleRepository;
        }
        public async Task<Role> GetRoleById(int id)
{
    return await _roleRepository.GetRoleById(id);
}

        public async Task<Role> CreateRole(Role newRole)
        {
            await _unitOfWork.Roles.AddAsync(newRole);
            await _unitOfWork.CommitAsync();
            return newRole;
        }


        public async Task UpdateRole(Role role)
        {
            await _roleRepository.UpdateRole(role);
        }
     

        public async Task DeleteRole(Role role)
        {
            await _roleRepository.DeleteRole(role);
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _unitOfWork.Roles.GetAllAsync();
        }

  

        public Task UpdateRole(Role roleToBeUpdated, Role role)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetRolesByRoleId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetAllWithRole()
        {
            throw new NotImplementedException();
        }
    }
}
