using CoWorking.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoWorking.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IManagerService _managerService;
        private readonly IBookingService _bookingService;
        private readonly ICommentService _commentService;
        public HomeController(IManagerService managerService,
            IBookingService bookingService,
            ICommentService commentService)
        {
            _managerService = managerService;
            _bookingService = bookingService;
            _commentService = commentService;
        }

        [HttpGet("bookings/reserved")]
        public async Task<IActionResult> GetReservedBookings()
        {
            var result = await _bookingService.GetReservedBookingList();
            return Ok(result);
        }

        [HttpGet("bookings/unreserved")]
        public async Task<IActionResult> GetUnReservedBookings()
        {
            var result = await _bookingService.GetUnReservedBookingList();
            return Ok(result);
        }

        [HttpGet("bookings/{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var result = await _bookingService.GetBookingByIdWithUserAsync(id);
            return Ok(result);
        }
    }
}
