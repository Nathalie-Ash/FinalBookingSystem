using IDS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDS.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers
            ();
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetUsersByUserId(int id);
        Task<User> CreateUser(User newUser);
        Task UpdateUser(User existingUser);
        Task DeleteUser(User user);
        Task<IEnumerable<User>> GetAllWithUser();
    }
}
