using CompanyBankAccountsApp.Helpers;
using CompanyBankAccountsApp.Maps;
using CompanyBankAccountsApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyBankAccountsApp.Controllers
{
    /// <summary>
    /// It remains to wrap all returned objects from the controllers in the response object that the base class of each response contains:
    ///  - isSuccess
    ///  - error messages
    ///  - our object
    /// </summary
    [Route("api/[controller]")]
    [Authorize]
    public class CompanyHoldingController : ControllerBase
    {
        private readonly CompanyHoldingMap _companyHoldingMap;
        private readonly JWTHelper _jwtHelper;

        public CompanyHoldingController(CompanyHoldingMap companyHoldingMap, JWTHelper jwtHelper)
        {
            _companyHoldingMap = companyHoldingMap;
            _jwtHelper = jwtHelper;
        }

        // GET: api/CompanyHolding?userId=5&companyId=7
        [HttpGet]
        public async Task<ActionResult<CompanyHoldingVM>> GetCompanyHolding(string userId, string companyId)
        {
            try
            {
                if (_jwtHelper.GetUserId() != userId)
                {
                    return BadRequest();
                }

                var companyHolding = await _companyHoldingMap.GetCompanyHolding(userId, companyId);
                if (companyHolding == null)
                {
                    return NotFound();
                }
                return companyHolding;
            }
            catch (Exception)
            {
                //Error handle
            }
            return StatusCode(500);
        }

        // POST: api/CompanyHolding/5
        [HttpPost("{userId}")]
        public async Task<IActionResult> SaveCompanyHolding(string userId, [FromBody] CompanyHoldingVM companyHolding)
        {
            try
            {
                if (userId != companyHolding.UserID || _jwtHelper.GetUserId() != userId || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var saveResponse = await _companyHoldingMap.SaveCompanyHolding(companyHolding);
                if (saveResponse)
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                //Error handle
            }
            return StatusCode(500);
        }
    }
}
