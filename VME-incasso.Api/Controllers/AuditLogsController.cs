using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VME.incasso.Business.Interfaces;
using VME.incasso.Data.DTOs;

namespace VME.incasso.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditLogsController : ControllerBase
    {
        private readonly IAuditLogService _auditService;

        public AuditLogsController(IAuditLogService auditService)
        {
            _auditService = auditService;
        }

        [Authorize]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var result = await _auditService.GetByUserIdAsync(userId);
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AuditLogDto dto)
        {
            await _auditService.AddAsync(dto);
            return Ok(new { message = "Audit log recorded." });
        }
    }
}
