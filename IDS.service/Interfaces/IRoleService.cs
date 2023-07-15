using IDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllRoles
            ();
        Task<Role> GetRoleById(int id);
        Task<IEnumerable<Role>> GetRolesByRoleId(int id);
        Task<Role> CreateRole(Role newRole);
        Task UpdateRole(Role existingRole);
        Task DeleteRole(Role role);
        Task<IEnumerable<Reservation>> GetAllWithRole();
    }
}
