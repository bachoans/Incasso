using VME.incasso.Business.Interfaces;
using VME.incasso.Data.Entities;
using VME.incasso.Data.Interfaces;

namespace VME.incasso.Business.Services
{
    public class DebtRecordService : BaseService<DebtRecord>, IDebtRecordService
    {
        private readonly IDebtRecordRepository _debtRecordRepository;

        public DebtRecordService(IDebtRecordRepository debtRecordRepository) : base(debtRecordRepository)
        {
            _debtRecordRepository = debtRecordRepository;
        }

        public async Task<IEnumerable<DebtRecord>> GetDebtRecordsByDebtorAsync(int debtorId)
        {
            return await _debtRecordRepository.GetDebtRecordsByDebtorAsync(debtorId);
        }
    }
}
