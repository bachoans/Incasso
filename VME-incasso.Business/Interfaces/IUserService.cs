using VME.incasso.Data.Entities;

namespace VME.incasso.Business.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<User?> GetByEmailAndPasswordAsync(string email, string passwordHash);
        Task<User> RegisterUserAsync(User user, Company company);
        Task ResetPasswordAsync(User user, string newPassword);
        int? GetUserIdFromToken(string token);
    }
}
