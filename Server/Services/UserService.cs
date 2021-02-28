using CompanyBankAccountsApp.Models;
using CompanyBankAccountsApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUser(string id)
        {
            try
            {
                return await _userRepository.GetUserAsync(id);
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                return await _userRepository.UpdateUserAsync(user);
            }
            catch (Exception)
            {
                //Error handle
                return false;
            }
        }
    }
}
