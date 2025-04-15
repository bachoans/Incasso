using VME.incasso.Business.Interfaces;
using VME.incasso.Data.Entities;
using VME.incasso.Data.Interfaces;

namespace VME.incasso.Business.Services
{
    public class DebtorService : BaseService<Debtor>, IDebtorService
    {
        private readonly IDebtorRepository _debtorRepository;

        public DebtorService(IDebtorRepository debtorRepository) : base(debtorRepository)
        {
            _debtorRepository = debtorRepository;
        }

        public async Task<IEnumerable<Debtor>> GetDebtorsByBuildingAsync(int buildingId)
        {
            return await _debtorRepository.GetDebtorsByBuildingAsync(buildingId);
        }
    }
}
