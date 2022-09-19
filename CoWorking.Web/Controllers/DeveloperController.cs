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
        private readonly IBookingService _bookingService;
        public DeveloperController(IDeveloperService developerService,
            IBookingService bookingService)
        {
            _developerService = developerService;
            _bookingService = bookingService;
        }

        [HttpPost("is-reservation")]
        public async Task<IActionResult> UserReservation([FromBody] UserIdDTO model)
        {
            var result = await _developerService.IsUserHasReservation(model);
            return Ok(result);
        }
    }
}
