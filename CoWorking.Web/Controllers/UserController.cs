using CoWorking.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoWorking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private string UserId => User.FindFirst(ClaimTypes.NameIdentifier).Value;
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetUserInfo()
        {
            var result = await _userService.GetUserInfo(UserId);
            return Ok(result);
        }
    }
}
