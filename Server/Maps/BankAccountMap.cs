using CompanyBankAccountsApp.Models;
using CompanyBankAccountsApp.Services;
using CompanyBankAccountsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.Maps
{
    public class BankAccountMap
    {
        private readonly BankAccountService _bankAccountService;

        public BankAccountMap(BankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        public async Task<List<BankAccountVM>> GetBankAccounts(string userId)
        {
            try
            {
                var bankAccounts = await _bankAccountService.GetBankAccounts(userId);
                return MapToViewModel(bankAccounts);
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }

        public async Task<bool> SaveBankAccount(BankAccountVM bankAccountVM)
        {
            try
            {
                var bankAccount = MapToDBModel(bankAccountVM);
                if (bankAccount == null)
                {
                    return false;
                }
                return await _bankAccountService.SaveBankAccount(bankAccount);
            }
            catch (Exception)
            {
                //Error handle
                return false;
            }
        }

        public async Task<bool> DeleteBankAccount(int bankId)
        {
            try
            {
                return await _bankAccountService.DeleteBankAccount(bankId);
            }
            catch (Exception)
            {
                //Error handle
                return false;
            }
        }

        #region Private Methods
        private List<BankAccount> MapToDBModel(List<BankAccountVM> bankAccounts)
        {
            try
            {
                var bankAccountsList = new List<BankAccount>();
                foreach (var item in bankAccounts)
                {
                    bankAccountsList.Add(MapToDBModel(item));
                }
                return bankAccountsList;
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }

        private List<BankAccountVM> MapToViewModel(List<BankAccount> bankAccounts)
        {
            try
            {
                var bankAccountsList = new List<BankAccountVM>();
                foreach (var item in bankAccounts)
                {
                    bankAccountsList.Add(MapToViewModel(item));
                }
                return bankAccountsList;
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }

        private BankAccount MapToDBModel(BankAccountVM bankAccountVM)
        {
            try
            {
                return new BankAccount()
                {
                    ID = !string.IsNullOrEmpty(bankAccountVM.ID) ? int.Parse(bankAccountVM.ID) : 0,
                    UserID = bankAccountVM.UserID,
                    CompanyID = bankAccountVM.CompanyID,
                    BankName = bankAccountVM.BankName,
                    BankBranch = bankAccountVM.BankBranch,
                    AccountNumber = bankAccountVM.AccountNumber
                };
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }

        private BankAccountVM MapToViewModel(BankAccount bankAccount)
        {
            try
            {
                return new BankAccountVM()
                {
                    ID = bankAccount.ID.ToString(),
                    UserID = bankAccount.UserID,
                    CompanyID = bankAccount.CompanyID,
                    BankName = bankAccount.BankName,
                    BankBranch = bankAccount.BankBranch,
                    AccountNumber = bankAccount.AccountNumber
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
