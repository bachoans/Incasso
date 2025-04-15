using VME.incasso.Data.DTOs;

namespace VME.incasso.Business.Interfaces
{
    public interface IAdminSettingsService
    {
        Task<AdminSettingsDto?> GetCurrentAsync();
        Task<AdminSettingsDto> UpdateAsync(AdminSettingsDto dto);
    }
}
