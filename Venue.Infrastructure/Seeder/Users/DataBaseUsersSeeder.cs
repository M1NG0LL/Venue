using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Venue.Domain.Common;
using Venue.Domain.Enums;
using Venue.Domain.Interfaces;

namespace Venue.Infrastructure.Seeder.Users
{
    public class DataBaseUsersSeeder
    {
        private readonly ILogger<DataBaseUsersSeeder> _logger;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public DataBaseUsersSeeder(ILogger<DataBaseUsersSeeder> logger, UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        public async Task SeedAsync()
        {
            try
            {
                _logger.LogInformation("Seeding roles...");
                await SeedRolesAsync();

                _logger.LogInformation("Seeding users...");
                await SeedUsersAsync();

                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database");
                throw;
            }   
        }

        #region Private Methods
        
        private async Task SeedRolesAsync()
        {
            foreach (var roleName in Enum.GetNames(typeof(UserRole)))
            {
                if (await _roleManager.FindByNameAsync(roleName) == null)
                {
                    var role = new IdentityRole<Guid>(roleName);

                    await _roleManager.CreateAsync(role);

                    _logger.LogInformation("Created role: {RoleName}", roleName);
                }
            }
        }

        private async Task SeedUsersAsync()
        {
            var adminEmail = "DoNotReply@wscdev.net";
            var adminUser = await _userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = "Admin",
                    Email = adminEmail,
                    EmailConfirmed = true,
                };

                var result = await _userManager.CreateAsync(adminUser, "1q2w3E*@");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, UserRole.Admin.ToString());
                    _logger.LogInformation($"Created admin user: {adminEmail}");
                }
                else
                {
                    _logger.LogError($"Failed to create admin user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
        #endregion
    }
}
