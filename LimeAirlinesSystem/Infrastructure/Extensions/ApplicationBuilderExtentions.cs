namespace LimeAirlinesSystem.Infrastructure.Extensions
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using static LimeAirlinesSystem.Areas.Admin.AdminConstants;

    public static class ApplicationBuilderExtentions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var services = scopedServices.ServiceProvider;

            MigrateDatabase(services);

            SeedCategoriesAndFlightTypes(services);
            SeedAdministrator(services);

            return app;

        }


        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<AirlineDbContext>();

            data.Database.Migrate();
        }

        private static void SeedCategoriesAndFlightTypes(IServiceProvider services)
        {
            var data = services.GetRequiredService<AirlineDbContext>();

            if (data.Categories.Any())
            {
                return;
            }

            if (data.TripTypes.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category{Id = 1, Name = "Helicopter"},
                new Category{Id = 2, Name = "Turboprop Aircraft"},
                new Category{Id = 3, Name = "Mid-Size Jet"},
                new Category{Id = 4, Name = "Narrow Body Aircraft"},
                new Category{Id = 5, Name = "Wide Body Airliner"},
            });


            data.TripTypes.AddRange(new[]
{
                new TripType{Id = 1, Name = "One-Way"},
                new TripType{Id = 2, Name = "Round Trip"}
            });

            data.SaveChanges();


            data.Categories.AddRange(new[]
{
                new Plane{Brand = , Model = , NumberOfSeats = , ImageUrl = , Year = , CategoryId = },
                new Plane{Brand = , Model = , NumberOfSeats = , ImageUrl = , Year = , CategoryId = },
            });

            data.SaveChanges();
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<Passanger>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
            {
                if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                {
                    return;
                }

                var role = new IdentityRole { Name = AdministratorRoleName };

                await roleManager.CreateAsync(role);

                const string adminEmail = "admin@limeair.com";
                const string adminPassword = "admin123";

                var user = new Passanger
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    FullName = "Admin"
                };

                await userManager.CreateAsync(user, adminPassword);

                await userManager.AddToRoleAsync(user, role.Name);
            })
            .GetAwaiter()
            .GetResult();
        }

    }
}
