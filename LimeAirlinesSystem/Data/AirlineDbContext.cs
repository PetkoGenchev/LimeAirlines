namespace LimeAirlinesSystem.Data
{
    using LimeAirlinesSystem.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class AirlineDbContext : IdentityDbContext<Passanger>
    {

        public AirlineDbContext(DbContextOptions<AirlineDbContext> options)
            : base(options)
        {
        }

        public DbSet<Plane> Planes { get; init; }
        public DbSet<Flight> Flights { get; init; }
        public DbSet<Category> Categories { get; init; }
        public DbSet<Passanger> Passangers { get; init; }
        public DbSet<TripType> TripTypes { get; init; }
        public DbSet<FlightBooking> FlightBookings { get; init; }
        public DbSet<FAQ> FAQs { get; init; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Flight>()
                .HasOne(p => p.Plane)
                .WithMany(f => f.Flights)
                .HasForeignKey(p => p.PlaneId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<FlightBooking>()
                .HasOne(p => p.Flight)
                .WithMany(f => f.FlightBookings)
                .HasForeignKey(p => p.FlightId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Plane>()
                .HasOne(p => p.Category)
                .WithMany(f => f.Planes)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
