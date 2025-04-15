using Microsoft.AspNetCore.Mvc;
using VME.incasso.Data.Entities;
using System.Security.Cryptography;
using System.Text;
using VME.incasso.Business.Interfaces;
using VME.incasso.Business.Services;
using Microsoft.AspNetCore.Identity.Data;
using VME.incasso.Business.DTOs;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly TokenService _tokenService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IUserService userService, TokenService tokenService, ILogger<AuthController> logger)
    {
        _userService = userService;
        _tokenService = tokenService;
        _logger = logger;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        try
        {
            _logger.LogInformation("🔐 Login attempt for email: {Email}", model.Email);

            var user = await _userService.GetByEmailAndPasswordAsync(model.Email, model.Password);

            if (user == null)
            {
                _logger.LogWarning("❌ Login failed for email: {Email} - invalid credentials", model.Email);
                return Unauthorized(new { message = "Invalid email or password." });
            }

            var token = _tokenService.GenerateToken(user.Id, user.Email, user.Role, user.CompanyId);

            _logger.LogInformation("✅ Login successful for user: {Email}, Role: {Role}", user.Email, user.Role);

            return Ok(new { token });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "🔥 Exception occurred during login for email: {Email}", model.Email);
            return StatusCode(500, new { message = ex.Message + "test", inner = ex.InnerException });
        }
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var company = new Company
        {
            Name = model.CompanyName,
            Address = model.Address,
            City = model.City,
            PostalCode = model.PostalCode,
            Country = model.Country,
            Phone = model.Phone,
            Email = model.CompanyEmail,
            SysDate = DateTime.UtcNow,
            IsDeleted = false
        };

        var user = new User
        {
            Name = model.Name,
            Email = model.Email,
            PasswordHash = model.Password,
            Role = "Admin", //TODO: Default role for the first user in a company
            SysDate = DateTime.UtcNow,
            IsDeleted = false,
            IsActive = true
        };

        var registeredUser = await _userService.RegisterUserAsync(user, company);

        return Ok(new { message = "Registration successful", userId = registeredUser.Id });
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (model.NewPassword != model.ConfirmPassword)
        {
            return BadRequest(new { message = "Passwords do not match." });
        }

        var user = await _userService.GetByEmailAsync(model.Email);
        if (user == null)
        {
            return NotFound(new { message = "User not found." });
        }

        // Reset the password
        await _userService.ResetPasswordAsync(user, model.NewPassword);

        return Ok(new { message = "Password reset successful." });
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetUser()
    {
        var token = Request.Headers["Authorization"].FirstOrDefault();
        if (string.IsNullOrEmpty(token))
        {
            return Unauthorized(new { message = "Token is required" });
        }

        var userId = _userService.GetUserIdFromToken(token);
        if (userId == null)
        {
            return Unauthorized(new { message = "Invalid token" });
        }

        var user = await _userService.GetByIdAsync(userId.Value);
        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }

        return Ok(new
        {
            user.Id,
            user.Name,
            user.Email,
            user.Role
        });
    }

}
