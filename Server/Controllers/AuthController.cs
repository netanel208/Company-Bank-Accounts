using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CompanyBankAccountsApp.Helpers;
using CompanyBankAccountsApp.Services;
using CompanyBankAccountsApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CompanyBankAccountsApp.Controllers
{
    /// <summary>
    /// It remains to wrap all returned objects from the controllers in the response object that the base class of each response contains:
    ///  - isSuccess
    ///  - error messages
    ///  - our object
    /// </summary
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AuthService _authService;
        private readonly JWTHelper _jwtHelper;

        public AuthController(IConfiguration config, AuthService authService, JWTHelper jwtHelper)
        {
            _config = config;
            _authService = authService;
            _jwtHelper = jwtHelper;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginVM login)
        {
            IActionResult response = Unauthorized();
            var isAuthSuccess = await _authService.AuthenticateAsync(login);
            if (isAuthSuccess)
            {
                var jwtToken = _jwtHelper.SignInJWT(login.Id);
                response = Ok(new { token = jwtToken });
            }
            return response;
        }
    }
}
