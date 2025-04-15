using VME.incasso.Data.Entities;
using System.Linq.Expressions;

namespace VME.incasso.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task SaveChangesAsync();
    }


    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<User?> GetByEmailAndPasswordAsync(string email, string passwordHash);
        Task<User> AddAsync(User user);
        Task UpdateAsync(User user);
        Task<User?> GetUserByIdAsync(int userId);
    }

    public interface ICompanyRepository : IRepository<Company>
    {
        Task<IEnumerable<Company>> GetCompaniesWithUsersAsync();
        Task<Company> AddCompanyAsync(Company company);
    }

    public interface IBuildingRepository : IRepository<Building>
    {
        Task<IEnumerable<Building>> GetBuildingsByCompanyAsync(int companyId);
        Task UpdateAsync(Building building);
        Task RemoveAsync(Building building);
    }

    public interface IDebtorRepository : IRepository<Debtor>
    {
        Task<IEnumerable<Debtor>> GetDebtorsByBuildingAsync(int buildingId);
    }

    public interface IDebtRecordRepository : IRepository<DebtRecord>
    {
        Task<IEnumerable<DebtRecord>> GetDebtRecordsByDebtorAsync(int debtorId);
    }

    public interface INotificationRepository : IRepository<Notification>
    {
        Task<IEnumerable<Notification>> GetNotificationsByDebtRecordAsync(int debtRecordId);
    }
    public interface IAuditLogRepository : IRepository<AuditLog>
    {
        Task<IEnumerable<AuditLog>> GetByUserIdAsync(int userId);
    }
    public interface IAdminSettingsRepository : IRepository<AdminSettings>
    {
        Task<AdminSettings?> GetCurrentSettingsAsync();
    }
}
