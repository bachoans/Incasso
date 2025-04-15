using VME.incasso.Data.Entities;

namespace VME.incasso.Business.Interfaces
{
    public interface ICompanyService : IService<Company>
    {
        Task<IEnumerable<Company>> GetCompaniesWithUsersAsync();
    }
}
