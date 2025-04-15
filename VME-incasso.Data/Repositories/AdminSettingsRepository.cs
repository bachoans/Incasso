using Microsoft.EntityFrameworkCore;
using VME.incasso.Data.DbContexts;
using VME.incasso.Data.Entities;
using VME.incasso.Data.Interfaces;

namespace VME.incasso.Data.Repositories
{
    public class AdminSettingsRepository : RepositoryBase<AdminSettings>, IAdminSettingsRepository
    {
        private readonly VMEIncassoContext _context;

        public AdminSettingsRepository(VMEIncassoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AdminSettings?> GetCurrentSettingsAsync()
        {
            return await _context.AdminSettings
                .OrderByDescending(a => a.SysDate)
                .FirstOrDefaultAsync();
        }
    }
}
