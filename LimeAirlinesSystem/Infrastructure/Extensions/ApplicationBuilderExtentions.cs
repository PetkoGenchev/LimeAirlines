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
                new Plane{Brand = "Airbus" , Model = "ACH160", NumberOfSeats = 10, ImageUrl = "../Images/PlaneImages/AirbusACH160.jpg", Year = 2020, CategoryId = 1, IsPublic = true},
                new Plane{Brand = "Bell", Model = "206B", NumberOfSeats = 4, ImageUrl = "../Images/PlaneImages/Bell206B.jpg", Year = 2015, CategoryId = 1, IsPublic = true},
                new Plane{Brand = "Pilatus", Model = "PC-12", NumberOfSeats = 10, ImageUrl = "../Images/PlaneImages/PilatusPC12.jpg", Year = 2016, CategoryId = 2, IsPublic = true},
                new Plane{Brand = "TBM", Model = "940", NumberOfSeats = 6, ImageUrl = "../Images/PlaneImages/TBM940.jpg", Year = 2019, CategoryId = 2, IsPublic = true},
                new Plane{Brand = "Embraer", Model = "Phenom 300", NumberOfSeats = 11, ImageUrl = "../Images/PlaneImages/EmbraerPhenom300.jpg", Year = 2019, CategoryId = 3, IsPublic = true},
                new Plane{Brand = "Gulfstream", Model = "G280", NumberOfSeats = 10, ImageUrl = "../Images/PlaneImages/GulfstreamG280.jpg", Year = 2021, CategoryId = 4, IsPublic = true},
                new Plane{Brand = "Airbus", Model = "A320", NumberOfSeats = 244, ImageUrl = "../Images/PlaneImages/AirbusA320.jpg", Year = 2013, CategoryId = 4, IsPublic = true},
                new Plane{Brand = "Boeing", Model = "B737", NumberOfSeats = 220, ImageUrl = "../Images/PlaneImages/Boeing737.jpg", Year = 2016, CategoryId = 4, IsPublic = true},
                new Plane{Brand = "Airbus", Model = "A220", NumberOfSeats = 160, ImageUrl = "../Images/PlaneImages/AirbusA220.jpg", Year = 2017, CategoryId = 4, IsPublic = true},
                new Plane{Brand = "Boeing", Model = "777", NumberOfSeats = 420, ImageUrl = "../Images/PlaneImages/Boeing777.jpg", Year = 2018, CategoryId = 5, IsPublic = true},
                new Plane{Brand = "Boeing", Model = "747", NumberOfSeats = 400, ImageUrl = "../Images/PlaneImages/Boeing747.jpg", Year = 2015, CategoryId = 5, IsPublic = true},
                new Plane{Brand = "Airbus", Model = "A380", NumberOfSeats = 644, ImageUrl = "../Images/PlaneImages/AirbusA380.jpg", Year = 2020, CategoryId = 5, IsPublic = true},
            });
            }

            data.SaveChanges();


            if (!data.Flights.Any())
            {
                data.Flights.AddRange(new[]
                {
                new Flight{StartLocation = "Sofia", EndLocation = "Berlin", FlightDate = new DateTime(2024,10,18), FlightDuration = new TimeSpan(2,10,0), Transfer = 1, Price = 200, ImageUrl = "../Images/LocationImages/Berlin.jpg", IsPublic = true, PlaneId = 7},
                new Flight{StartLocation = "Sofia", EndLocation = "Berlin", FlightDate = new DateTime(2024,11,12), FlightDuration = new TimeSpan(2,10,0), Transfer = 1, Price = 300, ImageUrl = "../Images/LocationImages/Berlin.jpg", IsPublic = true, PlaneId = 7},
                new Flight{StartLocation = "Sofia", EndLocation = "Berlin", FlightDate = new DateTime(2024,10,20), FlightDuration = new TimeSpan(2,10,0), Transfer = 0, Price = 400, ImageUrl = "../Images/LocationImages/Berlin.jpg", IsPublic = true, PlaneId = 7},
                new Flight{StartLocation = "Sofia", EndLocation = "Berlin", FlightDate = new DateTime(2024,11,12), FlightDuration = new TimeSpan(2,10,0), Transfer = 0, Price = 500, ImageUrl = "../Images/LocationImages/Berlin.jpg", IsPublic = true, PlaneId = 7},
                new Flight{StartLocation = "Sofia", EndLocation = "Berlin", FlightDate = new DateTime(2024,11,12), FlightDuration = new TimeSpan(2,10,0), Transfer = 0, Price = 600, ImageUrl = "../Images/LocationImages/Berlin.jpg", IsPublic = true, PlaneId = 8},
                new Flight{StartLocation = "Sofia", EndLocation = "Berlin", FlightDate = new DateTime(2024,10,24), FlightDuration = new TimeSpan(2,10,0), Transfer = 0, Price = 700, ImageUrl = "../Images/LocationImages/Berlin.jpg", IsPublic = true, PlaneId = 6},
                new Flight{StartLocation = "Sofia", EndLocation = "Berlin", FlightDate = new DateTime(2024,11,12), FlightDuration = new TimeSpan(2,10,0), Transfer = 0, Price = 800, ImageUrl = "../Images/LocationImages/Berlin.jpg", IsPublic = true, PlaneId = 5},
                new Flight{StartLocation = "Sofia", EndLocation = "Berlin", FlightDate = new DateTime(2024,11,12), FlightDuration = new TimeSpan(2,10,0), Transfer = 0, Price = 900, ImageUrl = "../Images/LocationImages/Berlin.jpg", IsPublic = true, PlaneId = 4},
                new Flight{StartLocation = "Sofia", EndLocation = "Berlin", FlightDate = new DateTime(2024,11,12), FlightDuration = new TimeSpan(2,10,0), Transfer = 0, Price = 1000, ImageUrl = "../Images/LocationImages/Berlin.jpg", IsPublic = true, PlaneId = 7},
                new Flight{StartLocation = "Sofia", EndLocation = "Berlin", FlightDate = new DateTime(2024,11,15), FlightDuration = new TimeSpan(3,30,0), Transfer = 0, Price = 400, ImageUrl = "../Images/LocationImages/Berlin.jpg", IsPublic = true, PlaneId = 1},
                new Flight{StartLocation = "Berlin", EndLocation ="Sofia", FlightDate = new DateTime(2024,11,17), FlightDuration = new TimeSpan(2,10,0), Transfer = 0, Price = 210, ImageUrl = "../Images/LocationImages/Sofia.jpg", IsPublic = true, PlaneId = 8},
                new Flight{StartLocation = "Berlin", EndLocation ="Sofia", FlightDate = new DateTime(2024,10,25), FlightDuration = new TimeSpan(2,10,0), Transfer = 0, Price = 240, ImageUrl = "../Images/LocationImages/Sofia.jpg", IsPublic = true, PlaneId = 7},
                new Flight{StartLocation = "Sofia", EndLocation = "Phuket", FlightDate = new DateTime(2024,10,25), FlightDuration = new TimeSpan(10,30,0), Transfer = 1, Price = 1900, ImageUrl = "../Images/LocationImages/Phuket.jpg", IsPublic = true, PlaneId = 11},
                new Flight{StartLocation = "Phuket", EndLocation = "Sofia", FlightDate = new DateTime(2024,11,05), FlightDuration = new TimeSpan(10,30,0), Transfer = 1, Price = 1900, ImageUrl = "../Images/LocationImages/Sofia.jpg", IsPublic = true, PlaneId = 11},
                new Flight{StartLocation = "Sofia", EndLocation = "Phuket", FlightDate = new DateTime(2024,11,15), FlightDuration = new TimeSpan(10,30,0), Transfer = 0, Price = 3000, ImageUrl = "../Images/LocationImages/Phuket.jpg", IsPublic = true, PlaneId = 2},
                new Flight{StartLocation = "Phuket", EndLocation = "Sofia", FlightDate = new DateTime(2024,11,22), FlightDuration = new TimeSpan(10,30,0), Transfer = 0, Price = 3000, ImageUrl = "../Images/LocationImages/Sofia.jpg", IsPublic = true, PlaneId = 2},
                new Flight{StartLocation = "Sofia", EndLocation = "Burgas", FlightDate = new DateTime(2025,02,10), FlightDuration = new TimeSpan(0,40,0), Transfer = 0, Price = 150, ImageUrl = "../Images/LocationImages/Burgas.jpg", IsPublic = true, PlaneId = 8},
                new Flight{StartLocation = "Burgas", EndLocation = "Sofia", FlightDate = new DateTime(2025,02,15), FlightDuration = new TimeSpan(0,40,0), Transfer = 0, Price = 110, ImageUrl = "../Images/LocationImages/Sofia.jpg", IsPublic = true, PlaneId = 8},
                new Flight{StartLocation = "Sofia", EndLocation = "Burgas", FlightDate = new DateTime(2024,10,20), FlightDuration = new TimeSpan(0,40,0), Transfer = 0, Price = 100, ImageUrl = "../Images/LocationImages/Burgas.jpg", IsPublic = true, PlaneId = 9},
                new Flight{StartLocation = "Burgas", EndLocation = "Sofia", FlightDate = new DateTime(2024,10,30), FlightDuration = new TimeSpan(0,40,0), Transfer = 0, Price = 750, ImageUrl = "../Images/LocationImages/Sofia.jpg", IsPublic = true, PlaneId = 3},
                new Flight{StartLocation = "Burgas", EndLocation = "Sofia", FlightDate = new DateTime(2024,12,24), FlightDuration = new TimeSpan(1,00,0), Transfer = 0, Price = 80, ImageUrl = "../Images/LocationImages/Sofia.jpg", IsPublic = true, PlaneId = 4},
                new Flight{StartLocation = "Burgas", EndLocation = "Sofia", FlightDate = new DateTime(2025,01,30), FlightDuration = new TimeSpan(1,10,0), Transfer = 0, Price = 120, ImageUrl = "../Images/LocationImages/Sofia.jpg", IsPublic = true, PlaneId = 3},
                new Flight{StartLocation = "Sofia", EndLocation = "NewYork", FlightDate = new DateTime(2024,12,30), FlightDuration = new TimeSpan(7,00,0), Transfer = 0, Price = 3000, ImageUrl = "../Images/LocationImages/NewYork.jpg", IsPublic = true, PlaneId = 3},
                new Flight{StartLocation = "Sofia", EndLocation = "NewYork", FlightDate = new DateTime(2024,10,21), FlightDuration = new TimeSpan(12,30,0), Transfer = 1, Price = 1800, ImageUrl = "../Images/LocationImages/NewYork.jpg", IsPublic = true, PlaneId = 6},
                new Flight{StartLocation = "Sofia", EndLocation = "NewYork", FlightDate = new DateTime(2024,12,10), FlightDuration = new TimeSpan(14,30,0), Transfer = 2, Price = 1200, ImageUrl = "../Images/LocationImages/NewYork.jpg", IsPublic = true, PlaneId = 9},
                new Flight{StartLocation = "NewYork", EndLocation = "Sofia", FlightDate = new DateTime(2024,12,15), FlightDuration = new TimeSpan(14,30,0), Transfer = 2, Price = 1300, ImageUrl = "../Images/LocationImages/Sofia.jpg", IsPublic = true, PlaneId = 9},
                new Flight{StartLocation = "Burgas", EndLocation = "NewYork", FlightDate = new DateTime(2024,12,01), FlightDuration = new TimeSpan(13,30,0), Transfer = 2, Price = 1500, ImageUrl = "../Images/LocationImages/NewYork.jpg", IsPublic = true, PlaneId = 8},
                new Flight{StartLocation = "NewYork", EndLocation = "Burgas", FlightDate = new DateTime(2024,12,10), FlightDuration = new TimeSpan(13,30,0), Transfer = 2, Price = 1000, ImageUrl = "../Images/LocationImages/Burgas.jpg", IsPublic = true, PlaneId = 8},
                new Flight{StartLocation = "Berlin", EndLocation = "NewYork", FlightDate = new DateTime(2025,01,15), FlightDuration = new TimeSpan(9,00,0), Transfer = 0, Price = 1150, ImageUrl = "../Images/LocationImages/NewYork.jpg", IsPublic = true, PlaneId = 7},
                new Flight{StartLocation = "Berlin", EndLocation = "NewYork", FlightDate = new DateTime(2025,01,16), FlightDuration = new TimeSpan(8,00,0), Transfer = 0, Price = 2000, ImageUrl = "../Images/LocationImages/NewYork.jpg", IsPublic = true, PlaneId = 4},
                new Flight{StartLocation = "NewYork", EndLocation = "Berlin", FlightDate = new DateTime(2025,01,21), FlightDuration = new TimeSpan(9,00,0), Transfer = 0, Price = 1050, ImageUrl = "../Images/LocationImages/Berlin.jpg", IsPublic = true, PlaneId = 7},
                new Flight{StartLocation = "Sofia", EndLocation = "Berlin", FlightDate = new DateTime(2024,11,12), FlightDuration = new TimeSpan(2,10,0), Transfer = 0, Price = 500, ImageUrl = "../Images/LocationImages/Berlin.jpg", IsPublic = true, PlaneId = 7},
                new Flight{StartLocation = "Sofia", EndLocation = "Berlin", FlightDate = new DateTime(2024,11,12), FlightDuration = new TimeSpan(2,10,0), Transfer = 0, Price = 500, ImageUrl = "../Images/LocationImages/Berlin.jpg", IsPublic = true, PlaneId = 7},
                new Flight{StartLocation = "Sofia", EndLocation = "London", FlightDate = new DateTime(2024,10,20), FlightDuration = new TimeSpan(3,30,0), Transfer = 0, Price = 80, ImageUrl = "../Images/LocationImages/London.jpg", IsPublic = true, PlaneId = 7},
                new Flight{StartLocation = "London", EndLocation = "Sofia", FlightDate = new DateTime(2024,10,25), FlightDuration = new TimeSpan(3,30,0), Transfer = 0, Price = 100, ImageUrl = "../Images/LocationImages/Sofia.jpg", IsPublic = true, PlaneId = 7},
                new Flight{StartLocation = "Sofia", EndLocation = "London", FlightDate = new DateTime(2024,10,29), FlightDuration = new TimeSpan(3,00,0), Transfer = 0, Price = 250, ImageUrl = "../Images/LocationImages/London.jpg", IsPublic = true, PlaneId = 3},
                new Flight{StartLocation = "London", EndLocation = "Sofia", FlightDate = new DateTime(2024,11,24), FlightDuration = new TimeSpan(3,00,0), Transfer = 0, Price = 300, ImageUrl = "../Images/LocationImages/Sofia.jpg", IsPublic = true, PlaneId = 3},
                new Flight{StartLocation = "Burgas", EndLocation = "London", FlightDate = new DateTime(2024,11,01), FlightDuration = new TimeSpan(3,40,0), Transfer = 0, Price = 90, ImageUrl = "../Images/LocationImages/London.jpg", IsPublic = true, PlaneId = 6},
                new Flight{StartLocation = "London", EndLocation = "Burgas", FlightDate = new DateTime(2024,11,04), FlightDuration = new TimeSpan(3,40,0), Transfer = 0, Price = 90, ImageUrl = "../Images/LocationImages/Burgas.jpg", IsPublic = true, PlaneId = 6},
                new Flight{StartLocation = "Burgas", EndLocation = "London", FlightDate = new DateTime(2024,12,24), FlightDuration = new TimeSpan(3,10,0), Transfer = 0, Price = 200, ImageUrl = "../Images/LocationImages/London.jpg", IsPublic = true, PlaneId = 4},
                new Flight{StartLocation = "London", EndLocation = "Burgas", FlightDate = new DateTime(2024,12,30), FlightDuration = new TimeSpan(3,10,0), Transfer = 0, Price = 200, ImageUrl = "../Images/LocationImages/Burgas.jpg", IsPublic = true, PlaneId = 4},
                new Flight{StartLocation = "London", EndLocation ="NewYork", FlightDate = new DateTime(2024,11,17), FlightDuration = new TimeSpan(7,00,0), Transfer = 0, Price = 1200, ImageUrl = "../Images/LocationImages/NewYork.jpg", IsPublic = true, PlaneId = 8},
                new Flight{StartLocation = "NewYork", EndLocation ="London", FlightDate = new DateTime(2024,11,17), FlightDuration = new TimeSpan(7,00,0), Transfer = 0, Price = 1300, ImageUrl = "../Images/LocationImages/London.jpg", IsPublic = true, PlaneId = 8},
                new Flight{StartLocation = "London", EndLocation ="NewYork", FlightDate = new DateTime(2024,11,17), FlightDuration = new TimeSpan(6,00,0), Transfer = 0, Price = 2800, ImageUrl = "../Images/LocationImages/NewYork.jpg", IsPublic = true, PlaneId = 5},
                new Flight{StartLocation = "NewYork", EndLocation ="London", FlightDate = new DateTime(2024,11,17), FlightDuration = new TimeSpan(6,00,0), Transfer = 0, Price = 2900, ImageUrl = "../Images/LocationImages/London.jpg", IsPublic = true, PlaneId = 5},
            });
            }

            data.SaveChanges();


            if (!data.FAQs.Any())
            {
                data.FAQs.AddRange(new[]
                {
                new FAQ{ Title = "Baggage", ImageUrl = "../Images/FAQImages/Baggage.jpg", IsPublic = true,
                    Description = "You’re always allowed to bring:\r\n1 item of hand baggage with a maximum size of 55 x 35 x 25 cm including handles and wheels;\r\n1 accessory (such as a small handbag or laptop bag) with a maximum size of 40 x 30 x 15 cm.\r\nYour hand baggage can have a combined weight of up to 12 kg." },
                new FAQ{ Title = "Ticket options and services", ImageUrl = "../Images/FAQImages/tickets.jpg", IsPublic = true,
                    Description = "Buy a ticket that fits your travel plans best – there are no wrong choices! Not sure which ticket is the right one for you? We’ll explain all options.\r\n\r\nChoose your ticket\r\nOur ticket options allow you to find the ideal ticket to fit your travel needs. We offer 3 ticket options for travelling in Economy Class on most routes: Light, Standard, and Flex. Next to that, you can also choose to travel in Premium Comfort Class or Business Class.\r\nAre you booking an Economy Class trip with multiple destinations via KLM.com? In that case, we can only offer you the Light ticket option.\r\nTicket conditions\r\nNote that the exact ticket conditions may vary per flight and per airline. You’ll see the conditions that apply to your specific flight when booking online. After booking, you can find them in your booking confirmation e-mail and in My Trip.\r\nDepending on your ticket conditions, it's sometimes possible to change your flight. Note, though: if you have to pay a change fee and/or fare difference, we may charge this in the local currency. The amount charged is equivalent to the amount in EUR or USD, based on the currency exchange rate." },
                new FAQ{ Title = "Managing your booking", ImageUrl = "../Images/FAQImages/managebooking.jpg", IsPublic = true,
                    Description = "Already checked in?\r\nMake sure to cancel your check-in first to be able to make changes to your flight.\r\nExtra options\r\nDid you reserve extra options for your original flight, such as a seat or meal? We’ll automatically book the same ones for your new flight. Please note that the price of the extra options could be higher. In this case, you’ll need to pay for these additional costs, or you can cancel the extra options. If they’re cheaper than on your original flight, you’ll receive a voucher with the remaining value." },
                new FAQ{ Title = "Extra options for your trip", ImageUrl = "../Images/FAQImages/extraoptions.jpg", IsPublic = true,
                    Description = "Want to experience extra service, privacy, and comfort? Make the most of your trip – treat yourself to an upgrade to Premium Comfort Class or Business Class.r\nLast-minute upgrades\r\nDuring or after check-in, you might receive a last-minute offer to upgrade. Note that last-minute upgrades are only possible for a specific flight, not for your entire booking." },
                new FAQ{ Title = "Refund and compensation", ImageUrl = "../Images/FAQImages/refund.jpg", IsPublic = true,
                    Description = "Don’t want to take your planned KLM flight anymore? Most likely, you would like a refund of your ticket. We’ll explain our policy: when you’re eligible for a refund and how to request it.\r\nou can request a cash refund for the unused part of your trip via our online refund system. This system checks if you’re eligible for a full cash refund or only part of it. You can also give us a call, but please note that a fee may be charged." },
                new FAQ{ Title = "Travel documents", ImageUrl = "../Images/FAQImages/documents.jpg", IsPublic = true,
                    Description = "Check if you need to bring a passport, visa, or other travel documents. You’ll find detailed information in our travel documents tool.Which travel documents you need depends on a couple of factors:\r\nyour country of departure, transfer, and destination;\r\nyour nationality;\r\nyour country of residence.\r\nWe advise checking the embassy website of the country you’re visiting. For detailed information suitable for your trip, check our travel documents tool." },
                new FAQ{ Title = "At the airport", ImageUrl = "../Images/FAQImages/airport.jpg", IsPublic = true,
                    Description = "Want to wait until you’re at the airport before checking in? Please check your local airport’s website for possible information on the waiting times. You’ve got 2 options at the airport: checking in at a self-service kiosk or at the check-in desk.\r\nSelf-service kiosk\r\nThe quickest way to check in at the airport is to go to a self-service kiosk. You can find them near the check-in desks. Here, you can check in from 30 hours before departure – or 24 hours before departure for flights to or from the United States.\r\nNote that at some airports, there are no self-service kiosks available.\r\nCheck-in desks\r\nPrefer to check in at the desk? Make sure you’re on time; there might be a queue. The regular opening hours of the check-in desks at most airports are:\r\nEuropean flights: until 40 minutes before departure.\r\nIntercontinental flights: until 60 minutes before departure." },
                new FAQ{ Title = "Onboard experience and services", ImageUrl = "../Images/FAQImages/onboard.jpg", IsPublic = true,
                    Description = "Spot a WiFi logo while booking your trip or during your flight? This means you can stay connected with your friends and family during the entire flight, even when you’re thousands of feet up in the sky. Read more about how to arrange and use inflight WiFi.\r\n\r\nWiFi passes\r\nIf there’s WiFi on your flight, you can buy one of the WiFi passes. Which passes are available depends on your destination and the aircraft type you’re flying on. You can purchase your WiFi pass during check-in or once you’ve boarded your flight." },
                new FAQ{ Title = "Traveling with kids", ImageUrl = "../Images/FAQImages/kids.jpg", IsPublic = true,
                    Description = "Whether it’s their very 1st flight or they are already worldly-wise globetrotters – here's everything you need to know to prepare your children for their next flight.\r\n\r\nSitting next to your kids\r\nTravelling as a family? Children up to and including 11 years old that have their own seat will always sit next to an adult from your group. We'll assign the seats free of charge during the check-in. Of course, you’re welcome to select seats for your family at an earlier stage to ensure you’re all seated together." },
                new FAQ{ Title = "Traveling with pets", ImageUrl = "../Images/FAQImages/pets.jpg", IsPublic = true,
                    Description = "While we love all pets, we only transport cats and dogs in our cabin and hold. This way, we can safeguard the health, safety, and comfort of all our passengers – including animals. By doing so, we’re following animal welfare guidelines and the regulations of the International Air Transport Association (IATA).\r\nThere’s limited space for pets in our aircraft; the number of pets we can bring depends on the type of aircraft, destination, and operating airline. Please make a reservation for your pet as soon as possible after booking your flight. Make the reservation no later than 48 hours before the departure of your flight.\r\nNote that your pet should travel on the same flight as you and should be at least 15 weeks old.\r\nPets in the cabin\r\nYou can bring 1 cat or dog with you in the cabin when travelling in Economy Class, or when travelling in Business Class within Europe. Your pet should fit in a closed pet travel bag or kennel with a maximum of 46 x 28 x 24 cm because they’ll need to travel underneath the seat in front of you. Together with your pet, the travel bag or kennel can weigh no more than 8 kg. You’re not allowed to take your pet out of the kennel during the flight, so please make sure they’re small enough to move comfortably.\r\nYou cannot bring a pet in the cabin if you fly Premium Comfort Class or Business Class on an intercontinental route. In these travel classes, it’s not possible to put a kennel underneath the seat in front of you." },
                new FAQ{ Title = "Assistance and health", ImageUrl = "../Images/FAQImages/disability.jpg", IsPublic = true,
                    Description = "Are you travelling with your own electric or manual wheelchair? We will transport it for you free of charge. Read how to arrange it.\r\n\r\nMaking a reservation\r\nAre you travelling with your own electric or manual wheelchair? We’ll transport it for you free of charge. Make sure to request the transport during booking or by contacting us at least 48 hours before departure. We can only transport a limited number of wheelchairs per flight, depending on the aircraft type and the size and weight of your wheelchair." },
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
