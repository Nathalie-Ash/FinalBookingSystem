using IDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {

        Task<IEnumerable<User>> GetAllWithUserAsync();
        Task<User> GetWithUserByIdAsync(int id);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllWithUsersByUserIdAsync(int id);
        Task<User> CreateUser(User newUser);
        Task UpdateUser(User newUser);
        Task DeleteUser(User user);
        Task Insert(User user);
    }

}