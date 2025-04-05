using Application.DTO;
using Application.DTO.Response;
using Application.Service.Interface;
using ecommerce_api.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Utilities.Constant;

namespace ecommerce_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {
        private readonly IFunctionService _functionService;
        public HomeController(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        [HttpGet]
        public async Task<ApiResult<object>> GetUserClaims()
        {
            var claims = new
            {
                UserId = User.GetUserId(),
                Email = User.FindFirst(ClaimTypes.Email)?.Value,
                FullName = User.FindFirst("FullName")?.Value,
                Avatar = User.FindFirst("Avatar")?.Value,
                Roles = User.FindFirst("Roles")?.Value
            };

            if (claims.UserId == null)
            {
                return await Task.FromResult(ApiResult<object>.Error("User is not authenticated"));
            }

            return await Task.FromResult(ApiResult<object>.Success(data: claims));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ApiResult<List<SidebarResponse>>> GetSideBar()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return new ApiResult<List<SidebarResponse>>
                {
                    Status = false,
                    Code = 401,
                    Msg = "User Not Login",
                    Data = null
                };
            }

            List<SidebarResponse> sideBar = await _functionService.GetSideBar();

            if (sideBar == null || !sideBar.Any())
            {
                return new ApiResult<List<SidebarResponse>>
                {
                    Status = false,
                    Code = 404,
                    Msg = "No data found",
                    Data = new List<SidebarResponse>()
                };
            }

            return new ApiResult<List<SidebarResponse>>
            {
                Status = true,
                Code = 200,
                Msg = "Success",
                Data = sideBar
            };
        }
       

    }
}
