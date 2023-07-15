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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            this._unitOfWork = unitOfWork;
            this._userRepository = userRepository;
        }

        public async Task<User> CreateUser(User newUser)
        {
            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.CommitAsync();
            return newUser;
        }


        public async Task UpdateUser(User user)
        {
            await _userRepository.UpdateUser(user);
        }
        public async Task DeleteUser(User user)
        {
            _unitOfWork.Users.Delete(user);
            await _unitOfWork.CommitAsync();
        }



        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _unitOfWork.Users
                .GetAllWithUserAsync();
        }


        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public Task UpdateUser(User userToBeUpdated, User user)
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<User>> GetAllWithUser()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
