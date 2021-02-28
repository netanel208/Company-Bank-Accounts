using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyBankAccountsApp.Helpers;
using CompanyBankAccountsApp.Maps;
using CompanyBankAccountsApp.Models;
using CompanyBankAccountsApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    public class BankAccountsController : ControllerBase
    {
        private readonly BankAccountMap _bankAccountMap;
        private readonly JWTHelper _jwtHelper;

        public BankAccountsController(BankAccountMap bankAccountMap, JWTHelper jwtHelper)
        {
            _bankAccountMap = bankAccountMap;
            _jwtHelper = jwtHelper;
        }

        // GET api/BankAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<BankAccountVM>>> GetBankAccounts(string id)
        {
            try
            {
                if (_jwtHelper.GetUserId() != id)
                {
                    return BadRequest();
                }

                var bankAccounts = await _bankAccountMap.GetBankAccounts(id);
                if (bankAccounts != null)
                {
                    return Ok(bankAccounts);
                }
            }
            catch (Exception)
            {
                //Error handle
            }
            return StatusCode(500);
        }

        // POST: api/BankAccounts/5
        [HttpPost("{id}")]
        public async Task<IActionResult> SaveBankAccount(string userId, [FromBody] BankAccountVM bankAccount)
        {
            try
            {
                if (userId != bankAccount.UserID || _jwtHelper.GetUserId() != userId || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var saveResponse = await _bankAccountMap.SaveBankAccount(bankAccount);
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

        // DELETE api/BankAccounts
        [HttpDelete]
        public async Task<IActionResult> Delete(string userId, int bankId)
        {
            try
            {
                if (_jwtHelper.GetUserId() != userId)
                {
                    return BadRequest();
                }

                var deleteResponse = await _bankAccountMap.DeleteBankAccount(bankId);
                if (deleteResponse)
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
