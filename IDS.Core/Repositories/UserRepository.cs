using IDS.Core.Interfaces;
using IDS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Core.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IdsbookingSystemContext context)
            : base(context)
        { }
        public async Task<User> GetUserById(int id)
        {
            return await MyDbContext.Users.FindAsync(id);
        }
        public async Task<IEnumerable<User>> GetAllWithUserAsync()
        {
            return await MyDbContext.Users

                .ToListAsync();
        }

        public Task<User> GetWithUsersByIdAsync(int id)
        {
            return MyDbContext.Users
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllWithUsersByUserIdAsync(int id)
        {
            return await MyDbContext.Users
                .Where(u => u.Id == id)
                .ToListAsync();
        }

    

        public async Task<User> CreateUser(User newUser)
        {
            await MyDbContext.Users.AddAsync(newUser);
            await MyDbContext.SaveChangesAsync();
            return newUser;
        }

        public async Task UpdateUser(User user)
        {
            MyDbContext.Users.Update(user);
            await MyDbContext.SaveChangesAsync();
        }

  

        public async Task DeleteUser(User user)
        {
            MyDbContext.Users.Remove(user);
            await MyDbContext.SaveChangesAsync();
        }

        public async Task Insert(User user)
        {
            await MyDbContext.Users.AddAsync(user);
            await MyDbContext.SaveChangesAsync();
        }

        public Task<User> GetWithUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        private IdsbookingSystemContext MyDbContext
        {
            get { return Context as IdsbookingSystemContext; }
        }
    }
}
