using VME.incasso.Business.Interfaces;
using VME.incasso.Data.DTOs;
using VME.incasso.Data.Entities;
using VME.incasso.Data.Interfaces;

namespace VME.incasso.Business.Services
{
    public class AdminSettingsService : IAdminSettingsService
    {
        private readonly IAdminSettingsRepository _repo;

        public AdminSettingsService(IAdminSettingsRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Retrieves the current admin settings.
        /// </summary>
        /// <returns></returns>
        public async Task<AdminSettingsDto?> GetCurrentAsync()
        {
            var entity = await _repo.GetCurrentSettingsAsync();
            if (entity == null) return null;

            return new AdminSettingsDto
            {
                Id = entity.Id,
                ReminderEmailCost = entity.ReminderEmailCost,
                ReminderMailCost = entity.ReminderMailCost,
                InterestRate = entity.InterestRate,
                PenaltyRate = entity.PenaltyRate
            };
        }

        /// <summary>
        /// Updates the admin settings.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<AdminSettingsDto> UpdateAsync(AdminSettingsDto dto)
        {
            var updated = new AdminSettings
            {
                Id = dto.Id,
                ReminderEmailCost = dto.ReminderEmailCost,
                ReminderMailCost = dto.ReminderMailCost,
                InterestRate = dto.InterestRate,
                PenaltyRate = dto.PenaltyRate,
                SysDate = DateTime.UtcNow,
                IsDeleted = false
            };

            //TODO: Implement update method in repository
            //await _repo.UpdateAsync(updated);
            return dto;
        }
    }
}
