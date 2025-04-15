using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace VME.incasso.Api.Controllers
{
    [ApiController]
    [Route("api/version")]
    public class VersionController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "Unknown";
            return Ok(new { version });
        }
    }
}
