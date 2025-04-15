using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VME.incasso.Business.Interfaces;
using VME.incasso.Data.DTOs;

namespace VME.incasso.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminSettingsController : ControllerBase
    {
        private readonly IAdminSettingsService _service;

        public AdminSettingsController(IAdminSettingsService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets the latest admin settings.
        /// </summary>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var settings = await _service.GetCurrentAsync();
            if (settings == null)
                return NotFound();

            return Ok(settings);
        }

        /// <summary>
        /// Updates global admin settings.
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AdminSettingsDto dto)
        {
            var result = await _service.UpdateAsync(dto);
            return Ok(result);
        }
    }
}
