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
        private readonly IAdminService _adminService;
        private readonly IBookingService _bookingService;
        public AdminController(IAdminService service, IBookingService bookingService)
        {
            _adminService = service;
            _bookingService = bookingService;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsersWithRoles()
        {
            var result = await _adminService.GetAllUsersAsync();
            return Ok(result);
        }

        [HttpPut("users")]
        public async Task<IActionResult> PutUser([FromBody] UserInfoDTO model)
        {
            await _adminService.PutUserAsync(model);
            return Ok();
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _adminService.DeleteUserAsync(id);
            return Ok();
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await _adminService.GetUserByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("bookings")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDTO model)
        {
            await _bookingService.AddBookingAsync(model);
            return Ok();
        }

        [HttpGet("bookings")]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _bookingService.GetAllBookingsAsync();
            return Ok(result);
        }

        [HttpDelete("bookings/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return Ok();
        }

        [HttpPut("bookings")]
        public async Task<IActionResult> PutBooking([FromBody] BookingInfoDTO model)
        {
            await _bookingService.PutBookingAsync(model);
            return Ok();
        }

        [HttpGet("bookings/{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var result = await _bookingService.GetBookingByIdAsync(id);
            return Ok(result);
        }

    }
}
