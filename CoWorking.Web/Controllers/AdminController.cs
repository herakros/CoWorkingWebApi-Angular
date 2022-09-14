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
            await _service.PutUserAsync(model);
            return Ok();
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

        [HttpPost("bookings")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDTO model)
        {
            await _service.AddBookingAsync(model);
            return Ok();
        }

        [HttpGet("bookings")]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _service.GetAllBooingsAsync();
            return Ok(result);
        }

        [HttpDelete("bookings/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _service.DeleteBookingAsync(id);
            return Ok();
        }

        [HttpPut("bookings")]
        public async Task<IActionResult> PutBooking([FromBody] BookingInfoDTO model)
        {
            await _service.PutBookingAsync(model);
            return Ok();
        }

        [HttpGet("bookings/{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var result = await _service.GetBookingByIdAsync(id);
            return Ok(result);
        }

    }
}
