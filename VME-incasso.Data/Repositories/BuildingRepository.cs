using VME.incasso.Data.DbContexts;
using VME.incasso.Data.Entities;
using VME.incasso.Data.Interfaces;
using VME.incasso.Data.Repositories;
using Microsoft.EntityFrameworkCore;

public class BuildingRepository : RepositoryBase<Building>, IBuildingRepository
{
    private readonly VMEIncassoContext _context;

    public BuildingRepository(VMEIncassoContext context) : base(context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Building>> GetBuildingsByCompanyAsync(int companyId)
    {
        return await _dbSet.Where(b => b.CompanyId == companyId && !b.IsDeleted).ToListAsync();
    }

    public async Task RemoveAsync(Building building)
    {
        _context.Buildings.Remove(building);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Building building)
    {
        _context.Buildings.Update(building);
        await _context.SaveChangesAsync();
    }
}
