using CompanyBankAccountsApp.Models;
using CompanyBankAccountsApp.Services;
using CompanyBankAccountsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.Maps
{
    public class CompanyHoldingMap
    {
        private readonly CompanyHoldingService _companyHoldingService;

        public CompanyHoldingMap(CompanyHoldingService companyHoldingService)
        {
            _companyHoldingService = companyHoldingService;
        }

        public async Task<CompanyHoldingVM> GetCompanyHolding(string userId, string companyId)
        {
            try
            {
                var companyHolding = await _companyHoldingService.GetCompanyHolding(userId, companyId);
                return MapToViewModel(companyHolding);
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }

        public async Task<bool> SaveCompanyHolding(CompanyHoldingVM companyHoldingVM)
        {
            try
            {
                var companyHolding = MapToDBModel(companyHoldingVM);
                if (companyHolding == null)
                {
                    return false;
                }
                return await _companyHoldingService.SaveCompanyHolding(companyHolding);
            }
            catch (Exception)
            {
                //Error handle
                return false;
            }
        }

        #region Private Methods
        private CompanyHolding MapToDBModel(CompanyHoldingVM companyHoldingVM)
        {
            try
            {
                return new CompanyHolding()
                {
                    UserID = companyHoldingVM.UserID,
                    CompanyID = companyHoldingVM.CompanyID,
                    Holding = int.Parse(companyHoldingVM.Holding)
                };
            }
            catch (Exception)
            {
                //Error handle
                return null;
            }
        }

        private CompanyHoldingVM MapToViewModel(CompanyHolding companyHolding)
        {
            try
            {
                return new CompanyHoldingVM()
                {
                    CompanyID = companyHolding.CompanyID,
                    Holding = companyHolding.Holding.ToString()
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
