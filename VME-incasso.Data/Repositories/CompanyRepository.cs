using VME.incasso.Data.DbContexts;
using VME.incasso.Data.Entities;
using VME.incasso.Data.Interfaces;
using VME.incasso.Data.Repositories;
using Microsoft.EntityFrameworkCore;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    private readonly VMEIncassoContext _context;

    public CompanyRepository(VMEIncassoContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Company>> GetCompaniesWithUsersAsync()
    {
        return await _dbSet.Include(c => c.Users).Where(c => !c.IsDeleted).ToListAsync();
    }

    public async Task<Company> AddCompanyAsync(Company company)
    {
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
        return company;
    }
}
