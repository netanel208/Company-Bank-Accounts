using CompanyBankAccountsApp.Models;
using CompanyBankAccountsApp.Repository;
using CompanyBankAccountsApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;

        public AuthService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // 1. Find user by email and password
        // 2. Update last login date
        public async Task<bool> AuthenticateAsync(LoginVM login)
        {
            try
            {
                var user = await _userRepository.GetUserAsync(login.Id, login.Password);
                if(user == null)
                {
                    return false;
                }
                return await _userRepository.UpdateLastLoginDateAsync(user);
            }
            catch (Exception)
            {
                //Error handle
                return false;
            }
        }
    }
}
