using VME.incasso.Data.DbContexts;
using VME.incasso.Data.Entities;
using VME.incasso.Data.Interfaces;
using VME.incasso.Data.Repositories;
using Microsoft.EntityFrameworkCore;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    private readonly VMEIncassoContext _context;

    public UserRepository(VMEIncassoContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
    }

    public async Task<User?> GetByEmailAndPasswordAsync(string email, string passwordHash)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == passwordHash && !u.IsDeleted);
    }

    public async Task<User> AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserByIdAsync(int userId)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId && !u.IsDeleted);
    }
}
