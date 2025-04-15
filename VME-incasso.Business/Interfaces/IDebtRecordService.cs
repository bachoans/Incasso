using VME.incasso.Data.Entities;

namespace VME.incasso.Business.Interfaces
{
    public interface IDebtRecordService : IService<DebtRecord>
    {
        Task<IEnumerable<DebtRecord>> GetDebtRecordsByDebtorAsync(int debtorId);
    }
}
