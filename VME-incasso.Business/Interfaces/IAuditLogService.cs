using VME.incasso.Data.DTOs;

namespace VME.incasso.Business.Interfaces
{
    public interface IAuditLogService
    {
        Task<IEnumerable<AuditLogDto>> GetByUserIdAsync(int userId);
        Task AddAsync(AuditLogDto dto);
    }
}
