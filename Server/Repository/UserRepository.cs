using CompanyBankAccountsApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.Repository
{
    public class UserRepository
    {
        private readonly CompanyBankAccountsDB _context;

        public UserRepository(CompanyBankAccountsDB context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(string id)
        {
            try
            {
                return await _context.Users.FindAsync(id);
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }

        public async Task<User> GetUserAsync(string id, string password)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(e => e.ID == id && e.Password == password);
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }

        public async Task<bool> UpdateLastLoginDateAsync(User user)
        {
            try
            {
                user.LastLoginDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                //Error handle
                return false;
            }
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            try
            {
                var excluded = new[] { "Password", "LastLoginDate" };
                var entry = _context.Entry(user);
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
    }
}
