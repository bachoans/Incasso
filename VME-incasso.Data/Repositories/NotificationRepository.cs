using VME.incasso.Data.DbContexts;
using VME.incasso.Data.Entities;
using VME.incasso.Data.Interfaces;
using VME.incasso.Data.Repositories;
using Microsoft.EntityFrameworkCore;

public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
{
    private readonly VMEIncassoContext _context;

    public NotificationRepository(VMEIncassoContext context) : base(context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves all notifications related to a specific debt record.
    /// </summary>
    public async Task<IEnumerable<Notification>> GetNotificationsByDebtRecordAsync(int debtRecordId)
    {
        return await _context.Notifications
                .Where(n => n.DebtRecordId == debtRecordId && !n.IsDeleted)
                .OrderByDescending(n => n.SentDate)
                .ToListAsync();
    }
}
