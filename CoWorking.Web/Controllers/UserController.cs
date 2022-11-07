using CoWorking.Contracts.DTO.UserDTO;
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

        [HttpPut("info")]
        public async Task<IActionResult> EditUserInfo(UserEditPersonalInfoDTO model)
        {
            await _userService.EditUserInfo(model, UserId);
            return Ok();
        }

        [HttpPut("password")]
        public async Task<IActionResult> EditUserPassword(UserEditPasswordDTO model)
        {
            await _userService.EditUserPassword(model, UserId);
            return Ok();
        }
    }
}
