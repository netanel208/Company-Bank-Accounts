using CompanyBankAccountsApp.Models;
using CompanyBankAccountsApp.Services;
using CompanyBankAccountsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.Maps
{
    public class UserMap
    {
        private readonly UserService _userService;

        public UserMap(UserService userService)
        {
            _userService = userService;
        }

        public async Task<UserVM> GetUser(string id)
        {
            try
            {
                var user = await _userService.GetUser(id);
                return MapToViewModel(user);
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }

        public async Task<bool> UpdateUser(UserVM userVM)
        {
            try
            {
                var user = MapToDBModel(userVM);
                if (user == null)
                {
                    return false;
                }
                return await _userService.UpdateUser(user);
            }
            catch (Exception)
            {
                //Error handle
                return false;
            }
        }

        #region Private Methods
        private User MapToDBModel(UserVM userVM)
        {
            try
            {
                return new User()
                {
                    ID = userVM.ID,
                    FirstName = userVM.FirstName,
                    FamilyName = userVM.FamilyName,
                    Email = userVM.Email,
                    CompanyName = userVM.CompanyName,
                    CompanyNumber = userVM.CompanyNumber,
                    DateOfBirth = DateTime.Parse(userVM.DateOfBirth),
                    PhoneNumber = userVM.PhoneNumber
                };
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }

        private UserVM MapToViewModel(User user)
        {
            try
            {
                return new UserVM()
                {
                    ID = user.ID,
                    FirstName = user.FirstName,
                    FamilyName = user.FamilyName,
                    Email = user.Email,
                    CompanyName = user.CompanyName,
                    CompanyNumber = user.CompanyNumber,
                    DateOfBirth = user.DateOfBirth.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PhoneNumber = user.PhoneNumber
                };
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }
        #endregion
    }
}
