using CompanyBankAccountsApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.Repository
{
    public class CompanyHoldingRepository
    {
        private readonly CompanyBankAccountsDB _context;
        
        public CompanyHoldingRepository(CompanyBankAccountsDB context)
        {
            _context = context;
        }

        public async Task<CompanyHolding> GetCompanyHoldingAsync(string userId, string companyId)
        {
            try
            {
                return await _context.CompaniesHoldings.FirstOrDefaultAsync(e => e.UserID == userId && e.CompanyID == companyId);
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }

        public async Task<bool> CreateCompanyHoldingAsync(CompanyHolding companyHolding)
        {
            try
            {
                _context.CompaniesHoldings.Add(companyHolding);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                //Error handle
                return false;
            }
        }

        public async Task<bool> UpdateCompanyHoldingAsync(CompanyHolding companyHolding, int holding)
        {
            try
            {
                companyHolding.Holding = holding;
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
