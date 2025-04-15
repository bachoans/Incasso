using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VME.incasso.Business.Interfaces;
using VME.incasso.Data.DTOs;

namespace VME.incasso.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        /// <summary>
        /// Gets all notifications for a specific debt record.
        /// </summary>
        [Authorize]
        [HttpGet("by-debt/{debtRecordId}")]
        public async Task<IActionResult> GetByDebtRecord(int debtRecordId)
        {
            var result = await _notificationService.GetNotificationsByDebtRecordAsync(debtRecordId);
            return Ok(result);
        }

        /// <summary>
        /// Adds a new notification entry.
        /// </summary>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] NotificationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _notificationService.AddAsync(dto);
            return CreatedAtAction(nameof(GetByDebtRecord), new { debtRecordId = dto.DebtRecordId }, created);
        }
    }
}
