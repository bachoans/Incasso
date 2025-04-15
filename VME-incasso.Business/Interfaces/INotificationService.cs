using VME.incasso.Data.DTOs;
using VME.incasso.Data.Entities;

namespace VME.incasso.Business.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDto>> GetNotificationsByDebtRecordAsync(int debtRecordId);

        Task<NotificationDto> AddAsync(NotificationDto dto);
    }
}
