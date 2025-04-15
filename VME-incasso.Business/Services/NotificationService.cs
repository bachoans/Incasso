using VME.incasso.Business.Interfaces;
using VME.incasso.Data.DTOs;
using VME.incasso.Data.Entities;
using VME.incasso.Data.Interfaces;

namespace VME.incasso.Business.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        /// <summary>
        /// Gets notifications for a specific debt record.
        /// </summary>
        public async Task<IEnumerable<NotificationDto>> GetNotificationsByDebtRecordAsync(int debtRecordId)
        {
            var entities = await _notificationRepository.GetNotificationsByDebtRecordAsync(debtRecordId);

            return entities.Select(n => new NotificationDto
            {
                Id = n.Id,
                DebtRecordId = n.DebtRecordId,
                NotificationType = n.NotificationType,
                SentDate = n.SentDate,
                Status = n.Status
            });
        }

        /// <summary>
        /// Adds a new notification.
        /// </summary>
        public async Task<NotificationDto> AddAsync(NotificationDto dto)
        {
            var entity = new Notification
            {
                DebtRecordId = dto.DebtRecordId,
                NotificationType = dto.NotificationType,
                SentDate = dto.SentDate,
                Status = dto.Status,
                SysDate = DateTime.UtcNow,
                IsDeleted = false
            };

            var saved = await _notificationRepository.AddAsync(entity);

            dto.Id = saved.Id;
            return dto;
        }
    }
}
