using VME.incasso.Data.DbContexts;
using VME.incasso.Data.Entities;
using VME.incasso.Data.Interfaces;
using VME.incasso.Data.Repositories;
using Microsoft.EntityFrameworkCore;

public class DebtorRepository : RepositoryBase<Debtor>, IDebtorRepository
{
    public DebtorRepository(VMEIncassoContext context) : base(context) { }

    public async Task<IEnumerable<Debtor>> GetDebtorsByBuildingAsync(int buildingId)
    {
        return await _dbSet.Where(d => d.BuildingId == buildingId && !d.IsDeleted).ToListAsync();
    }
}
