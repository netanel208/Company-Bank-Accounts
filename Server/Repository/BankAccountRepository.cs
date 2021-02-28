using CompanyBankAccountsApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.Repository
{
    public class BankAccountRepository
    {
        private readonly CompanyBankAccountsDB _context;

        public BankAccountRepository(CompanyBankAccountsDB context)
        {
            _context = context;
        }

        public async Task<List<BankAccount>> GetBankAccountsAsync(string userId)
        {
            try
            {
                return await _context.BankAccounts.Where(e => e.UserID == userId).ToListAsync();
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }

        public async Task<BankAccount> GetBankAccountAsync(int bankId)
        {
            try
            {
                return await _context.BankAccounts.FirstOrDefaultAsync(e => e.ID == bankId);
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }

        public async Task<bool> CreateBankAccountAsync(BankAccount bankAccount)
        {
            try
            {
                await _context.BankAccounts.AddAsync(bankAccount);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                //Error handle
                return false;
            }
        }

        public async Task<bool> UpdateBankAccountAsync(BankAccount bankAccount)
        {
            try
            {
                var excluded = new[] { "ID" };
                var entry = _context.Entry(bankAccount);
                entry.State = EntityState.Modified;
                foreach (var name in excluded)
                {
                    entry.Property(name).IsModified = false;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                //Error handle
                return false;
            }
        }

        public async Task<bool> DeleteBankAccountAsync(int bankId)
        {
            try
            {
                var bankAccount = await _context.BankAccounts.Where(e => e.ID == bankId).FirstOrDefaultAsync();
                if(bankAccount == null)
                {
                    return false;
                }
                _context.BankAccounts.Remove(bankAccount);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                //Error handle
                return false;
            }
        }
    }
}
