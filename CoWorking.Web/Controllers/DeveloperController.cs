using CoWorking.Contracts.DTO.DeveloperDTO;
using CoWorking.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoWorking.Web.Controllers
{
    [Authorize(Roles = "Developer")]
    [ApiController]
    [Route("api/[controller]")]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperService _developerService;
        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        [HttpPost("is-reservation")]
        public async Task<IActionResult> UserReservation([FromBody] UserIdDTO model)
        {
            var result = await _developerService.IsUserHasReservationAsync(model);
            return Ok(result);
        }

        [HttpPost("is-it-user-reservation")]
        public async Task<IActionResult> IsItUserBooking([FromBody] UsedBookingIdDTO model)
        {
            var retuls = await _developerService.IsItUserBookingAsync(model);
            return Ok(retuls);
        }

        [HttpPut("change-booking-date")]
        public async Task<IActionResult> ChangeBookingDateOfEnd([FromBody] ChangeBookingDateDTO model)
        {
            await _developerService.ChangeBookingDateAsync(model);
            return Ok();
        }
    }
}
