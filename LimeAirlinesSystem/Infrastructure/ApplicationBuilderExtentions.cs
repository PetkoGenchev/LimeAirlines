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

            SeedCategoriesAndClasses(data);

            return app;

        }

        private static void SeedCategoriesAndClasses(AirlineDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            if (data.Classes.Any())
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


            data.Classes.AddRange(new[]
{
                new Class{Name = "First Class"},
                new Class{Name = "Business Class"},
                new Class{Name = "Economy Class"},

            });

            data.SaveChanges();

        }

    }
}
