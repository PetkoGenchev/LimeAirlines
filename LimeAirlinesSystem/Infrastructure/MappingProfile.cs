namespace LimeAirlinesSystem.Infrastructure
{
    using AutoMapper;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Services.Planes.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Category, PlaneCategoryServiceModel>();
        }
    }
}
