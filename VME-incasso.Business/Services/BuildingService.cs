using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using VME.incasso.Business.Interfaces;
using VME.incasso.Data.Entities;
using VME.incasso.Data.Interfaces;

namespace VME.incasso.Business.Services
{
    public class BuildingService : BaseService<Building>, IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BuildingService(IBuildingRepository buildingRepository, IHttpContextAccessor httpContextAccessor)
            : base(buildingRepository)
        {
            _buildingRepository = buildingRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetAuthorizedUserCompanyId()
        {
            var companyIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("CompanyId");
           
            if (companyIdClaim == null)
            {
                throw new UnauthorizedAccessException("No CompanyId claim found for the authorized user.");
            }

            return int.Parse(companyIdClaim.Value);
        }

        public async Task<IEnumerable<Building>> GetAuthorizedBuildingsAsync()
        {
            var companyId = GetAuthorizedUserCompanyId();
            return await _buildingRepository.GetBuildingsByCompanyAsync(companyId);
        }

        public async Task<Building> AddAuthorizedBuildingAsync(Building building)
        {
            building.CompanyId = GetAuthorizedUserCompanyId();
            return await _buildingRepository.AddAsync(building);
        }

        public async Task UpdateAuthorizedBuildingAsync(Building building)
        {
            var companyId = GetAuthorizedUserCompanyId();
            if (building.CompanyId != companyId)
            {
                throw new UnauthorizedAccessException("You are not authorized to update this building.");
            }

            await _buildingRepository.UpdateAsync(building);
        }

        public async Task DeleteAuthorizedBuildingAsync(int buildingId)
        {
            var companyId = GetAuthorizedUserCompanyId();
            var building = await _buildingRepository.GetByIdAsync(buildingId);

            if (building == null || building.CompanyId != companyId)
            {
                throw new UnauthorizedAccessException("You are not authorized to delete this building.");
            }

            await _buildingRepository.RemoveAsync(building);
        }
    }
}
