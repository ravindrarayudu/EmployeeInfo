using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeInfo.Business.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            if (userRepository != null)
                this._userRepository = userRepository;
        }

        public async Task<int> AddEditUserAsync(User user)
        {
            return await _userRepository.AddEditUserAsync(user);
        }

        public async Task<User> GetUserByIdAsync(Guid UserId)
        {
            return await _userRepository.GetUserByIdAsync(UserId);
        }

        public async Task<User> GetUserByNameAsync(string UserName)
        {
            return await _userRepository.GetUserByNameAsync(UserName);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }
    }
}
