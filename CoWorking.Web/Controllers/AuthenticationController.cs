using CoWorking.Contracts.Constants;
using CoWorking.Contracts.Data.Entities.UserEntity;
using CoWorking.Contracts.DTO.AuthenticationDTO;
using CoWorking.Contracts.DTO.UserDTO;
using CoWorking.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoWorking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginDTO logDTO)
        {
            var tokens = await authenticationService.LoginAsync(logDTO.Email, logDTO.Password);

            return Ok(tokens);
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> RegistrationAsync([FromBody] UserRegistrationDTO regDTO)
        {
            var user = new User()
            {
                UserName = regDTO.Username,
                Surname = regDTO.Surname,
                Name = regDTO.Name,
                Email = regDTO.Email
            };

            await authenticationService.RegistrationAsync(user, regDTO.Password, SystemRoles.User);

            return Ok();
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] UserAutorizationDTO userTokensDTO)
        {
            var tokens = await authenticationService.RefreshTokenAsync(userTokensDTO);

            return Ok(tokens);
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> LogoutAsync([FromBody] UserAutorizationDTO userTokensDTO)
        {
            await authenticationService.LogoutAsync(userTokensDTO);

            return NoContent();
        }
    }
}
