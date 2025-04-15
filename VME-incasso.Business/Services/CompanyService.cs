using VME.incasso.Business.Interfaces;
using VME.incasso.Data.Entities;
using VME.incasso.Data.Interfaces;

namespace VME.incasso.Business.Services
{
    public class CompanyService : BaseService<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository) : base(companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<Company>> GetCompaniesWithUsersAsync()
        {
            return await _companyRepository.GetCompaniesWithUsersAsync();
        }
    }
}
