namespace LimeAirlinesSystem.Infrastructure
{
    using System.Linq;
    using LimeAirlinesSystem.Data;
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

            return app;
        }
    }
}
