using Application.DTO;
using Application.DTO.Request;
using Data.Entity;
using ecommerce_api.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private ILogger<LoginController> _logger;
        private TokenHelper _tokenHelper;
        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<LoginController> logger, TokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        
        [HttpPost]
        public async Task<IActionResult> OnLogin([FromBody] LoginRequest req)
        {
            ApiResult<object> result = new ApiResult<object>();
            if(!ModelState.IsValid)
            {
                result.Msg = "Invalid Request";
                result.Code = 501;
                return BadRequest(result);
            }

            var user = await _userManager.FindByEmailAsync(req.Email);
            if (user == null)
            {
                result.Msg = "Invalid email or password";
                result.Code = 401;
                return Unauthorized(result);

            }

            var passwordHasher = new PasswordHasher<AppUser>();
            var resultCheck = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, req.Password);
            if (resultCheck == PasswordVerificationResult.Failed || req.Email != user.Email)
            {
                result.Code = 401;
                result.Msg = "Invalid email or password";
                return Unauthorized(result);
            }

            var login = await _signInManager.PasswordSignInAsync(user.UserName, req.Password, req.RememberMe, lockoutOnFailure: true);
            var role = await _userManager.GetRolesAsync(user);
            if (login.Succeeded)
            {
                var token = _tokenHelper.GenerateToken(user.Id, user.UserName, role.ToString());
                result.Msg = "Success";
                result.Status = true;
                result.Code = 200;
                result.Data =  token ;
                return Ok(result);
            }

            if (login.IsLockedOut)
            {
                result.Msg = "Account is locked";
                result.Code = 403;
                return Unauthorized(result);
            }

            return Unauthorized(result);
        }
    }
}