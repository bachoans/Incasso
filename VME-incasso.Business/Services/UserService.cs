using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using VME.incasso.Business.Helpers;
using VME.incasso.Business.Interfaces;
using VME.incasso.Data.Entities;
using VME.incasso.Data.Interfaces;

namespace VME.incasso.Business.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;

        public UserService(IUserRepository userRepository, ICompanyRepository companyRepository) : base(userRepository)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task<User> RegisterUserAsync(User user, Company company)
        {
            // Add company to the database
            var createdCompany = await _companyRepository.AddCompanyAsync(company);

            // Generate salt and hash password
            user.PasswordSalt = PasswordHelper.GenerateSalt();
            user.PasswordHash = PasswordHelper.HashPassword(user.PasswordHash, user.PasswordSalt);

            // Assign the company to the user
            user.CompanyId = createdCompany.Id;

            // Add user to the database
            return await _userRepository.AddAsync(user);
        }

        public async Task<User?> GetByEmailAndPasswordAsync(string email, string password)
        {
            // Get the user by email
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null || !PasswordHelper.VerifyPassword(password, user.PasswordSalt, user.PasswordHash))
            {
                return null; // Invalid credentials
            }

            return user;
        }

        public async Task ResetPasswordAsync(User user, string newPassword)
        {
            // Generate a new salt and hash the password
            user.PasswordSalt = PasswordHelper.GenerateSalt();
            user.PasswordHash = PasswordHelper.HashPassword(newPassword, user.PasswordSalt);

            // Update the user's last password change date
            user.LastPasswordChangeDate = DateTime.UtcNow;

            // Save changes
            await _userRepository.UpdateAsync(user);
        }

        public int? GetUserIdFromToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                return null;

            // Ensure the token doesn't contain the "Bearer " prefix
            if (token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                token = token.Substring("Bearer ".Length).Trim();
            }

            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(token))
                return null;

            var jwtToken = handler.ReadJwtToken(token);
            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out var userId))
                return null;

            return userId;
        }

        public async Task<User?> GetByIdAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }
    }
}
