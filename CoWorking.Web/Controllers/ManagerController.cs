using CoWorking.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoWorking.Web.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        private readonly IBookingService _bookingService;
        private readonly ICommentService _commentService;
        public ManagerController(IManagerService managerService, 
            IBookingService bookingService,
            ICommentService commentService)
        {
            _managerService = managerService;
            _bookingService = bookingService;
            _commentService = commentService;
        }
    }
}
