using IDS.Core.Interfaces;
using IDS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Core.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(IdsbookingSystemContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Role>> GetAllWithRoleAsync()
        {
            return await MyDbContext.Roles.ToListAsync();
        }

    
    

        public Task<Role> GetWithRolesByIdAsync(int id)
        {
            return MyDbContext.Roles
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<IEnumerable<Role>> GetAllWithRolesByRoleIdAsync(int id)
        {
            throw new NotImplementedException();
        }

     
        public async Task<Role> GetRoleById(int id)
        {
            return await MyDbContext.Roles.FindAsync(id);
        }
        public async Task<Role> CreateRole(Role newRole)
        {
            await MyDbContext.Roles.AddAsync(newRole);
            await MyDbContext.SaveChangesAsync();
            return newRole;
        }


        public async Task UpdateRole(Role role)
        {
            MyDbContext.Roles.Update(role);
            await MyDbContext.SaveChangesAsync();
        }

        public async Task DeleteRole(Role role)
        {
            MyDbContext.Roles.Remove(role);
            await MyDbContext.SaveChangesAsync();
        }

        public Task Insert(Role role)
        {
            throw new NotImplementedException();
        }

     

        private IdsbookingSystemContext MyDbContext
        {
            get { return Context as IdsbookingSystemContext; }
        }
    }
}
