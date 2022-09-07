using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoWorking.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("test")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> GetTest()
        {
            return Ok("Test");
        }
    }
}
