﻿namespace LimeAirlinesSystem.Infrastructure.Extensions
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

            if (!data.Categories.Any())
            {
                data.Categories.AddRange(new[]
                {
                new Category{Name = "Helicopter"},
                new Category{Name = "Turboprop Aircraft"},
                new Category{Name = "Mid-Size Jet"},
                new Category{Name = "Narrow Body Aircraft"},
                new Category{Name = "Wide Body Airliner"},
            });
            }

            if (!data.TripTypes.Any())
            {
                data.TripTypes.AddRange(new[]
{
                new TripType{Name = "One-Way"},
                new TripType{Name = "Round Trip"}
            });
            }

            data.SaveChanges();


            if (!data.Planes.Any())
            {
                data.Planes.AddRange(new[]
                {
                new Plane{Brand = "Airbus" , Model = "ACH160", NumberOfSeats = 10, ImageUrl = "https://mediaassets.airbus.com/permalinks/505999/win/-cdph-7171-0070.jpg", Year = 2020, CategoryId = 1, IsPublic = true},
                new Plane{Brand = "Bell", Model = "206B", NumberOfSeats = 4, ImageUrl = "https://aircharterservice-globalcontent-live.cphostaccess.com/images/aircraft-guide-images/private/bell20206b20ex20pic_tcm36-3766.jpg", Year = 2015, CategoryId = 1, IsPublic = true},
                new Plane{Brand = "Pilatus", Model = "PC-12", NumberOfSeats = 10, ImageUrl = "https://generalaviationnews.com/wp-content/uploads/2021/03/pc-12-mount-rushmore-usa-768x512.jpg", Year = 2016, CategoryId = 2, IsPublic = true},
                new Plane{Brand = "TBM", Model = "940", NumberOfSeats = 6, ImageUrl = "https://www.daher.com/app/uploads/2019/05/TBM-Notre-offre-TBM-940.jpg", Year = 2019, CategoryId = 2, IsPublic = true},
                new Plane{Brand = "Embraer", Model = "Phenom 300", NumberOfSeats = 11, ImageUrl = "https://aerospace.honeywell.com/content/dam/aerobt/en/images/learn/platforms/citation/horizontal/AeroBT-aero-bk-embraer-Phenom-300_2880x1440.jpg", Year = 2019, CategoryId = 3, IsPublic = true},
                new Plane{Brand = "Gulfstream", Model = "G280", NumberOfSeats = 10, ImageUrl = "https://www.gulfstream.com/assets/images/aircraft/g280/d_g280_a_mkt_00721_web.jpg", Year = 2021, CategoryId = 4, IsPublic = true},
                new Plane{Brand = "Airbus", Model = "A320", NumberOfSeats = 244, ImageUrl = "https://worldaviationato.com/backend/wp-content/uploads/2021/04/877865_airbus-a320-large_tcm71-3644.jpeg", Year = 2013, CategoryId = 4, IsPublic = true},
                new Plane{Brand = "Boeing", Model = "B737", NumberOfSeats = 220, ImageUrl = "https://cdn.businesstraveller.com/wp-content/uploads/fly-images/934636/737-916x516.jpg", Year = 2016, CategoryId = 4, IsPublic = true},
                new Plane{Brand = "Airbus", Model = "A220", NumberOfSeats = 160, ImageUrl = "https://www.avioforum.com/wp-content/uploads/2018/07/Airbus-A220-300-new-member-of-the-airbus-Single-aisle-Family.jpg", Year = 2017, CategoryId = 4, IsPublic = true},
                new Plane{Brand = "Boeing", Model = "777", NumberOfSeats = 420, ImageUrl = "https://www.super-hobby.bg/zdjecia/7/0/5/15098_rd.jpg", Year = 2018, CategoryId = 5, IsPublic = true},
                new Plane{Brand = "Boeing", Model = "747", NumberOfSeats = 400, ImageUrl = "https://www.avioforum.com/wp-content/uploads/2021/02/Boeing_747-8_first_flight_Everett_WA.jpg", Year = 2015, CategoryId = 5, IsPublic = true},
                new Plane{Brand = "Airbus", Model = "A380", NumberOfSeats = 644, ImageUrl = "http://www.infotourism.net/documents/43834_airbusa.jpg", Year = 2020, CategoryId = 5, IsPublic = true}
            });
            }

            data.SaveChanges();


            if (!data.Flights.Any())
            {
                data.Flights.AddRange(new[]
                {
                new Flight{StartLocation = "Sofia", EndLocation = "Berlin", FlightDate = new DateTime(2023,05,12), FlightDuration = new TimeSpan(2,10,0), Transfer = 0, Price = 200, ImageUrl = "https://www.germany.travel/media/redaktion/content/bundeslaender/berlin/Berlin_Brandenburger_Tor_im_Sonnenuntergang_Leitmotiv_German_Summer_Cities.jpg", IsPublic = true, PlaneId = 7},
                new Flight{StartLocation = "Sofia", EndLocation = "Berlin", FlightDate = new DateTime(2023,05,15), FlightDuration = new TimeSpan(3,30,0), Transfer = 0, Price = 400, ImageUrl = "https://www.germany.travel/media/redaktion/content/bundeslaender/berlin/Berlin_Brandenburger_Tor_im_Sonnenuntergang_Leitmotiv_German_Summer_Cities.jpg", IsPublic = true, PlaneId = 1},
                new Flight{StartLocation = "Berlin", EndLocation ="Sofia", FlightDate = new DateTime(2023,05,17), FlightDuration = new TimeSpan(2,10,0), Transfer = 0, Price = 240, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/79/Cathedral_Saint_Alexander_Nevsky_%2823997168458%29.jpg/800px-Cathedral_Saint_Alexander_Nevsky_%2823997168458%29.jpg", IsPublic = true, PlaneId = 8},
                new Flight{StartLocation = "Sofia", EndLocation = "Phuket", FlightDate = new DateTime(2023,06,12), FlightDuration = new TimeSpan(10,30,0), Transfer = 1, Price = 1900, ImageUrl = "https://touringhighlights.com/wp-content/uploads/2020/09/Phang-Nga-Bay-Phuket-Thailand.jpg", IsPublic = true, PlaneId = 11},
                new Flight{StartLocation = "Sofia", EndLocation = "Burgas", FlightDate = new DateTime(2023,05,25), FlightDuration = new TimeSpan(0,40,0), Transfer = 0, Price = 50, ImageUrl = "https://bulgaria.it/wp-content/uploads/2015/02/burgas-960x389.jpg", IsPublic = true, PlaneId = 3},
                new Flight{StartLocation = "Burgas", EndLocation = "Sofia", FlightDate = new DateTime(2023,05,24), FlightDuration = new TimeSpan(1,0,0), Transfer = 0, Price = 80, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/79/Cathedral_Saint_Alexander_Nevsky_%2823997168458%29.jpg/800px-Cathedral_Saint_Alexander_Nevsky_%2823997168458%29.jpg", IsPublic = true, PlaneId = 4},
                new Flight{StartLocation = "Burgas", EndLocation = "Sofia", FlightDate = new DateTime(2023,05,31), FlightDuration = new TimeSpan(1,10,0), Transfer = 0, Price = 120, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/79/Cathedral_Saint_Alexander_Nevsky_%2823997168458%29.jpg/800px-Cathedral_Saint_Alexander_Nevsky_%2823997168458%29.jpg", IsPublic = true, PlaneId = 3},
            });
            }

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
