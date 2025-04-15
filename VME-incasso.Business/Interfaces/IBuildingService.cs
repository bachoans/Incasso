using VME.incasso.Data.Entities;

namespace VME.incasso.Business.Interfaces
{
    public interface IBuildingService : IService<Building>
    {
        Task<IEnumerable<Building>> GetAuthorizedBuildingsAsync();
        Task<Building> AddAuthorizedBuildingAsync(Building building);
        Task UpdateAuthorizedBuildingAsync(Building building);
        Task DeleteAuthorizedBuildingAsync(int buildingId);
    }
}
