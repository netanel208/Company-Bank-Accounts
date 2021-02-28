using CompanyBankAccountsApp.Models;
using CompanyBankAccountsApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.Services
{
    public class CompanyHoldingService
    {
        private readonly CompanyHoldingRepository _companyHoldingRepository;

        public CompanyHoldingService(CompanyHoldingRepository companyHoldingRepository)
        {
            _companyHoldingRepository = companyHoldingRepository;
        }

        public async Task<CompanyHolding> GetCompanyHolding(string userId, string companyId)
        {
            try
            {
                return await _companyHoldingRepository.GetCompanyHoldingAsync(userId, companyId);
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }

        // 1. Create new company holding if not exists
        // 2. Update company holding if already exists
        public async Task<bool> SaveCompanyHolding(CompanyHolding companyHolding)
        {
            try
            {
                var responseCompanyHolding = await _companyHoldingRepository.GetCompanyHoldingAsync(companyHolding.UserID, companyHolding.CompanyID);
                if(responseCompanyHolding == null)
                {
                    return await _companyHoldingRepository.CreateCompanyHoldingAsync(companyHolding);
                }
                else
                {
                    return await _companyHoldingRepository.UpdateCompanyHoldingAsync(responseCompanyHolding, companyHolding.Holding);
                }
            }
            catch (Exception)
            {
                //Error handle
                return false;
            }
        }
    }
}
