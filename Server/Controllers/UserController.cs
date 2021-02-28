using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CompanyBankAccountsApp.Models;
using Microsoft.AspNetCore.Authorization;
using CompanyBankAccountsApp.ViewModels;
using CompanyBankAccountsApp.Maps;
using CompanyBankAccountsApp.Helpers;

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
    public class UserController : ControllerBase
    {
        private readonly UserMap _userMap;
        private readonly JWTHelper _jwtHelper;

        public UserController(UserMap userMap, JWTHelper jwtHelper)
        {
            _userMap = userMap;
            _jwtHelper = jwtHelper;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserVM>> GetUser(string id)
        {
            try
            {
                //Check if this is right user
                if (_jwtHelper.GetUserId() != id)
                {
                    return BadRequest();
                }

                var user = await _userMap.GetUser(id);
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }
            catch (Exception)
            {
                //Error handle
            }
            return StatusCode(500);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserVM user)
        {
            try
            {
                if (id != user.ID || _jwtHelper.GetUserId() != id || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var updateResponse = await _userMap.UpdateUser(user);
                if (updateResponse)
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
