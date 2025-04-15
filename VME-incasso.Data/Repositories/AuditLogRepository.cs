using Microsoft.EntityFrameworkCore;
using VME.incasso.Data.DbContexts;
using VME.incasso.Data.Entities;
using VME.incasso.Data.Interfaces;

namespace VME.incasso.Data.Repositories
{
    public class AuditLogRepository : RepositoryBase<AuditLog>, IAuditLogRepository
    {
        private readonly VMEIncassoContext _context;

        public AuditLogRepository(VMEIncassoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AuditLog>> GetByUserIdAsync(int userId)
        {
            return await _context.AuditLogs
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.SysDate)
                .ToListAsync();
        }
    }
}
