namespace LimeAirlinesSystem.Services.Planes
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Services.Planes.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class PlaneService : IPlaneService
    {
        private readonly AirlineDbContext data;
        private readonly IConfigurationProvider mapper;

        public PlaneService(AirlineDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper.ConfigurationProvider;
        }



        public int Create(string brand, string model, int numberofSeats, string imageUrl, int year, int categoryId)
        {
            var planeData = new Plane
            {
                Brand = brand,
                Model = model,
                NumberOfSeats = numberofSeats,
                ImageUrl = imageUrl,
                Year = year,
                CategoryId = categoryId
            };

            this.data.Planes.Add(planeData);
            this.data.SaveChanges();

            return planeData.Id;
        }


        public IEnumerable<PlaneCategoryServiceModel> AllCategories()
        => this.data
            .Categories
            .ProjectTo<PlaneCategoryServiceModel>(this.mapper)
            .ToList();


        public bool CategoryExists(int categoryId) 
            => this.data
            .Categories
            .Any(c => c.Id == categoryId);


    }
}
