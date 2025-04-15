using VME.incasso.Data.DbContexts;
using VME.incasso.Data.Entities;
using VME.incasso.Data.Interfaces;
using VME.incasso.Data.Repositories;
using Microsoft.EntityFrameworkCore;

public class DebtRecordRepository : RepositoryBase<DebtRecord>, IDebtRecordRepository
{
    public DebtRecordRepository(VMEIncassoContext context) : base(context) { }

    public async Task<IEnumerable<DebtRecord>> GetDebtRecordsByDebtorAsync(int debtorId)
    {
        return await _dbSet.Where(dr => dr.DebtorId == debtorId && !dr.IsDeleted).ToListAsync();
    }
}
