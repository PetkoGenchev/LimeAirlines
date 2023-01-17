namespace LimeAirlinesSystem.Infrastructure
{
    using AutoMapper;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Models.Planes;
    using LimeAirlinesSystem.Services.Flights.Models;
    using LimeAirlinesSystem.Services.Planes.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Category, PlaneCategoryServiceModel>();

            this.CreateMap<PlaneServiceModel, PlaneFormModel>();

            this.CreateMap<Flight, CheapestFlightServiceModel>();

            this.CreateMap<Plane, PlaneServiceModel>()
            .ForMember(p => p.CategoryName, cfg => cfg.MapFrom(p => p.Category.Name));

            this.CreateMap<Flight, FlightServiceModel>();
        }
    }
}
