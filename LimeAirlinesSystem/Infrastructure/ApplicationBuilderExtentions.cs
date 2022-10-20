namespace LimeAirlinesSystem.Infrastructure
{
    using System.Linq;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;


    public static class ApplicationBuilderExtentions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<AirlineDbContext>();

            data.Database.Migrate();

            SeedCategoriesAndFlightTypes(data);

            return app;

        }

        private static void SeedCategoriesAndFlightTypes(AirlineDbContext data)
        {
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
                new Category{Name = "Helicopter"},
                new Category{Name = "Turboprop Aircraft"},
                new Category{Name = "Mid-Size Jet"},
                new Category{Name = "Narrow Body Aircraft"},
                new Category{Name = "Wide Body Airliner"},
            });


            data.TripTypes.AddRange(new[]
{
                new TripType{Name = "One-Way"},
                new TripType{Name = "Round Trip"}
            });

            data.SaveChanges();

        }

    }
}
