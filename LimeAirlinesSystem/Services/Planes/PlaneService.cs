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

        public PlaneServiceModel Details(int planeId)
            => this.data
            .Planes
            .Where(p => p.Id == planeId)
            .ProjectTo<PlaneServiceModel>(this.mapper)
            .FirstOrDefault();



        public PlaneQueryServiceModel All(
            int currentPage = 1,
            int planesPerPage = int.MaxValue,
            bool publicOnly = true)
        {
            var planesQuery = this.data.Planes
                .Where(c => !publicOnly || c.IsPublic);

            var totalPlanes = planesQuery.Count();

            var planes = GetPlanes(planesQuery
                .Skip((currentPage - 1) * planesPerPage)
                .Take(planesPerPage));

            return new PlaneQueryServiceModel
            {
                TotalPlanes = totalPlanes,
                CurrentPage = currentPage,
                PlanesPerPage = planesPerPage,
                Planes = planes
            };
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


        public bool Edit(
            int id,
            string brand,
            string model,
            int numberofSeats,
            string imageUrl,
            int year,
            int categoryId)
        {
            var planeData = this.data.Planes.Find(id);

            if (planeData == null)
            {
                return false;
            }

            planeData.Brand = brand;
            planeData.Model = model;
            planeData.NumberOfSeats = numberofSeats;
            planeData.ImageUrl = imageUrl;
            planeData.Year = year;
            planeData.CategoryId = categoryId;

            this.data.SaveChanges();

            return true;
        }



        //public void ChangeVisibility(int planeId)
        //{
        //    var plane = this.data.Planes
        //        .Where(p => p.Id == planeId)
        //        .FirstOrDefault();

        //    plane.IsPublic = !plane.IsPublic;
        //}


        public void ChangeVisibility(int planeId)
        {
            var plane = this.data.Planes.Find(planeId);

            plane.IsPublic = !plane.IsPublic;

            this.data.SaveChanges();
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


        private IEnumerable<PlaneServiceModel> GetPlanes(IQueryable<Plane> planeQuery)
             => planeQuery
            .ProjectTo<PlaneServiceModel>(this.mapper)
            .ToList();

    }
}
