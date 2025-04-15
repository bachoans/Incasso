using VME.incasso.Data.Entities;

namespace VME.incasso.Business.Interfaces
{
    public interface IDebtorService : IService<Debtor>
    {
        Task<IEnumerable<Debtor>> GetDebtorsByBuildingAsync(int buildingId);
    }
}
