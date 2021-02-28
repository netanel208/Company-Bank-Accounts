using CompanyBankAccountsApp.Models;
using CompanyBankAccountsApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.Services
{
    public class BankAccountService
    {
        private readonly BankAccountRepository _bankAccountRepository;

        public BankAccountService(BankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task<List<BankAccount>> GetBankAccounts(string userId)
        {
            try
            {
                return await _bankAccountRepository.GetBankAccountsAsync(userId);
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }

        // 1. Create new bank account if not exists
        // 2. Update bank account if already exists
        public async Task<bool> SaveBankAccount(BankAccount bankAccount)
        {
            try
            {
                var responseBankAccount = await _bankAccountRepository.GetBankAccountAsync(bankAccount.ID);
                if (responseBankAccount == null)
                {
                    return await _bankAccountRepository.CreateBankAccountAsync(bankAccount);
                }
                else
                {
                    return await _bankAccountRepository.UpdateBankAccountAsync(bankAccount);
                }
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
                return await _bankAccountRepository.DeleteBankAccountAsync(bankId);
            }
            catch (Exception)
            {
                //Error handle
                return false;
            }
        }
    }
}
