using Microsoft.AspNetCore.Mvc;

namespace Webinars.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}