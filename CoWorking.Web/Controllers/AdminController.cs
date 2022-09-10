using CoWorking.Contracts.DTO.AdminPanelDTO;
using CoWorking.Contracts.DTO.BookingDTO;
using CoWorking.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoWorking.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;
        public AdminController(IAdminService service)
        {
            _service = service;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsersWithRoles()
        {
            var result = await _service.GetAllUsersAsync();
            return Ok(result);
        }

        [HttpPut("users")]
        public async Task<IActionResult> PutUser([FromBody] UserInfoDTO model)
        {
            var result = await _service.PutUserAsync(model);
            return Ok(result);
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _service.DeleteUserAsync(id);
            return Ok();
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await _service.GetUserByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("booking")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDTO model)
        {
            await _service.AddBookingAsync(model);
            return Ok();
        }

        [HttpPost("bookings")]
        public async Task<IActionResult> CreateRangeOfBooking([FromBody] List<CreateBookingDTO> models)
        {
            await _service.AddRangeOfBooking(models);
            return Ok();
        }
    }
}
