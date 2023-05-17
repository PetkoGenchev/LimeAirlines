namespace LimeAirlinesSystem.Infrastructure
{
    using AutoMapper;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Models.Bookings;
    using LimeAirlinesSystem.Models.FAQs;
    using LimeAirlinesSystem.Models.Flights;
    using LimeAirlinesSystem.Models.Planes;
    using LimeAirlinesSystem.Services.Bookings.Models;
    using LimeAirlinesSystem.Services.Flights.Models;
    using LimeAirlinesSystem.Services.Home;
    using LimeAirlinesSystem.Services.FAQs.Models;
    using LimeAirlinesSystem.Services.Planes.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Category, PlaneCategoryServiceModel>();

            this.CreateMap<PlaneServiceModel, PlaneFormModel>();

            this.CreateMap<FlightServiceModel, FlightFormModel>();

            this.CreateMap<Flight, CheapestFlightServiceModel>();

            this.CreateMap<FlightBookingServiceModel, BookingFormModel>();

            this.CreateMap<FlightBooking, FlightBookingServiceModel>()
            .ForMember(p => p.StartLocation, cfg => cfg.MapFrom(p => p.Flight.StartLocation))
            .ForMember(p => p.EndLocation, cfg => cfg.MapFrom(p => p.Flight.EndLocation))
            .ForMember(p => p.FlightDate, cfg => cfg.MapFrom(p => p.Flight.FlightDate))
            .ForMember(p => p.Price, cfg => cfg.MapFrom(p => p.Flight.Price));

            this.CreateMap<Plane, PlaneServiceModel>()
            .ForMember(p => p.CategoryName, cfg => cfg.MapFrom(p => p.Category.Name));

            this.CreateMap<Flight, FlightServiceModel>();

            this.CreateMap<TripType, FlightTypeServiceModel>();

            this.CreateMap<FAQServiceModel, FAQFormModel>();

            this.CreateMap<FAQ, FAQServiceModel>();
        }
    }
}
