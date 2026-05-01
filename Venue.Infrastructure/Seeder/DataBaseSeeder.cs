using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using NetTopologySuite.Geometries;
using Venue.Domain.Common;
using Venue.Domain.Entities;
using Venue.Domain.Enums;
using Venue.Domain.Interfaces;
using Venue.Infrastructure.DbContext;

namespace Venue.Infrastructure.Seeder
{
    public class DataBaseSeeder
    {
        private readonly ILogger<DataBaseSeeder> _logger;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly AppDbContext _appDbContext;
        private readonly IUnitOfWork _unitOfWork;

        public DataBaseSeeder(ILogger<DataBaseSeeder> logger, UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager, AppDbContext appDbContext, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _appDbContext = appDbContext;
            _unitOfWork = unitOfWork;
        }

        public async Task SeedAsync()
        {
            _logger.LogInformation("Starting database seeding...");

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
                _logger.LogError(ex, "Error occurred during OpenIddict seeding.");
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
            var adminEmail = "admin@venue.com";
            var adminUser = await _userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = "Admin",
                    Email = adminEmail,
                    EmailConfirmed = true,
                };

                var result = await _userManager.CreateAsync(adminUser, "Admin@123");
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

            var ownerEmail = "owner@venue.com";
            var ownerUser = await _userManager.FindByEmailAsync(ownerEmail);
            if (ownerUser == null)
            {
                ownerUser = new User
                {
                    UserName = "Owner",
                    Email = ownerEmail,
                    EmailConfirmed = true,
                };

                var result = await _userManager.CreateAsync(ownerUser, "Owner@123");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(ownerUser, UserRole.Owner.ToString());
                    _logger.LogInformation($"Created owner user: {ownerEmail}");
                }
                else
                {
                    _logger.LogError($"Failed to create owner user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }

            await SeedVenuesAsync(ownerUser.Id);
        }

        private async Task SeedVenuesAsync(Guid ownerId)
        {
            var venues = new List<VenueEntity>
            {
                new VenueEntity
                {
                    Name = "Grand Hall",
                    Description = "A spacious venue for large events.",
                    ImagePath = "https://unsplash.com/photos/white-folding-chair-in-front-of-body-of-water-jTnipV64uLo",
                    ContactInfo = new VenueContactInfo
                    {
                        Phone = "+201000000001",
                        Email = "grandhall@venues.com",
                        Address = "123 Main St, Cityville",
                        Location = new Point(30.0444, 31.2357)
                    },
                    Info = new VenueConfiguration
                    {
                        AvailableDays = new List<DayOfWeek> { DayOfWeek.Friday, DayOfWeek.Saturday },
                        SeatingCapacity = 500,
                        PricePerEvent = 15000m
                    }
                },

                new VenueEntity
                {
                    Name = "Cozy Corner",
                    Description = "A small, intimate venue for private gatherings.",
                    ImagePath = "https://unsplash.com/photos/a-large-room-with-tables-and-chairs-in-it-neAMdikyhEQ",
                    ContactInfo = new VenueContactInfo
                    {
                        Phone = "+201000000002",
                        Email = "cozycorner@venues.com",
                        Address = "456 Elm St, Townsville",
                        Location = new Point(30.0500, 31.2000)
                    },
                    Info = new VenueConfiguration
                    {
                        AvailableDays = new List<DayOfWeek> { DayOfWeek.Sunday, DayOfWeek.Monday },
                        SeatingCapacity = 50,
                        PricePerEvent = 3000m
                    }
                },

                new VenueEntity
                {
                    Name = "Skyline Rooftop",
                    Description = "Rooftop venue with city skyline view.",
                    ImagePath = "https://unsplash.com/photos/a-large-room-with-tables-and-chairs-in-it-neAMdikyhEQ",
                    ContactInfo = new VenueContactInfo
                    {
                        Phone = "+201000000003",
                        Email = "skyline@venues.com",
                        Address = "88 Tower Rd, Metropolis",
                        Location = new Point(30.0610, 31.2200)
                    },
                    Info = new VenueConfiguration
                    {
                        AvailableDays = new List<DayOfWeek> { DayOfWeek.Thursday, DayOfWeek.Friday },
                        SeatingCapacity = 200,
                        PricePerEvent = 9000m
                    }
                },

                new VenueEntity
                {
                    Name = "Garden Bliss",
                    Description = "Outdoor garden venue surrounded by greenery.",
                    ImagePath = "https://unsplash.com/photos/a-courtyard-with-white-flowers-aRQrz0fclB8",
                    ContactInfo = new VenueContactInfo
                    {
                        Phone = "+201000000004",
                        Email = "gardenbliss@venues.com",
                        Address = "12 Green Ave, Riverside",
                        Location = new Point(30.0700, 31.2100)
                    },
                    Info = new VenueConfiguration
                    {
                        AvailableDays = new List<DayOfWeek> { DayOfWeek.Saturday, DayOfWeek.Sunday },
                        SeatingCapacity = 150,
                        PricePerEvent = 7000m
                    }
                },

                new VenueEntity
                {
                    Name = "Crystal Ballroom",
                    Description = "Elegant ballroom for weddings and formal events.",
                    ImagePath = "https://unsplash.com/photos/a-courtyard-with-white-flowers-aRQrz0fclB8",
                    ContactInfo = new VenueContactInfo
                    {
                        Phone = "+201000000005",
                        Email = "crystal@venues.com",
                        Address = "500 Royal St, Capital City",
                        Location = new Point(30.0800, 31.2300)
                    },
                    Info = new VenueConfiguration
                    {
                        AvailableDays = new List<DayOfWeek> { DayOfWeek.Friday, DayOfWeek.Saturday, DayOfWeek.Sunday },
                        SeatingCapacity = 600,
                        PricePerEvent = 20000m
                    }
                },

                new VenueEntity
                {
                    Name = "Studio Loft",
                    Description = "Modern industrial-style venue for creative events.",
                    ImagePath = "https://unsplash.com/photos/white-folding-chair-in-front-of-body-of-water-jTnipV64uLo",
                    ContactInfo = new VenueContactInfo
                    {
                        Phone = "+201000000006",
                        Email = "studio@venues.com",
                        Address = "77 Art District, Downtown",
                        Location = new Point(30.0555, 31.2155)
                    },
                    Info = new VenueConfiguration
                    {
                        AvailableDays = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday },
                        SeatingCapacity = 120,
                        PricePerEvent = 5000m
                    }
                }
            };

            _appDbContext.Venues.AddRange(venues);
        }
        #endregion
    }
}
