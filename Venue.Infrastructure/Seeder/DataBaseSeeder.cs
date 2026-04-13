using Microsoft.Extensions.Logging;
using Venue.Infrastructure.Seeder.Users;

namespace Venue.Infrastructure.Seeder
{
    public class DataBaseSeeder
    {
        private readonly ILogger<DataBaseSeeder> _logger;
        private readonly DataBaseUsersSeeder _usersSeeder;

        public DataBaseSeeder(ILogger<DataBaseSeeder> logger, DataBaseUsersSeeder usersSeeder)
        {
            _logger = logger;
            _usersSeeder = usersSeeder;
        }

        public async Task SeedAsync()
        {
            _logger.LogInformation("Starting database seeding...");

            try
            {
                await _usersSeeder.SeedAsync();
                _logger.LogInformation("User and Roles seeding completed successfully.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during OpenIddict seeding.");
                throw;
            }
        }
    }
}
