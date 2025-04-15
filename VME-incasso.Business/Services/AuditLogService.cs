using VME.incasso.Business.Interfaces;
using VME.incasso.Data.DTOs;
using VME.incasso.Data.Entities;
using VME.incasso.Data.Interfaces;

namespace VME.incasso.Business.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _auditRepo;

        public AuditLogService(IAuditLogRepository auditRepo)
        {
            _auditRepo = auditRepo;
        }

        public async Task<IEnumerable<AuditLogDto>> GetByUserIdAsync(int userId)
        {
            var logs = await _auditRepo.GetByUserIdAsync(userId);
            return logs.Select(l => new AuditLogDto
            {
                Id = l.Id,
                UserId = l.UserId,
                Action = l.Action,
                IPAddress = l.IPAddress,
                SysDate = l.SysDate
            });
        }

        public async Task AddAsync(AuditLogDto dto)
        {
            var entity = new AuditLog
            {
                UserId = dto.UserId,
                Action = dto.Action,
                IPAddress = dto.IPAddress,
                SysDate = DateTime.UtcNow
            };
            await _auditRepo.AddAsync(entity);
        }
    }
}
