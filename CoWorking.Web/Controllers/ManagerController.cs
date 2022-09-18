using CoWorking.Contracts.DTO.ManagerDTO;
using CoWorking.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoWorking.Web.Controllers
{
    [Authorize(Roles = "Manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        private readonly IBookingService _bookingService;
        public ManagerController(IManagerService managerService, 
            IBookingService bookingService)
        {
            _managerService = managerService;
            _bookingService = bookingService;
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> SubscribeUser([FromBody] SubscribeUserDTO model)
        {
            await _managerService.SubscribeUserToBookingAsync(model);
            return Ok();
        }
    }
}
