namespace LimeAirlinesSystem.Services.Planes
{
    using System.Collections.Generic;
    using LimeAirlinesSystem.Services.Planes.Models;

    public interface IPlaneService
    {

        PlaneServiceModel Details(int planeId);


        PlaneQueryServiceModel All(
            int currentPage = 1,
            int planesPerPage = int.MaxValue);



        int Create(
            string brand,
            string model,
            int numberofSeats,
            string imageUrl,
            int year,
            int categoryId
            );

        bool Edit(
            int planeId,
            string brand,
            string model,
            int numberofSeats,
            string imageUrl,
            int year,
            int categoryId
            );

        IEnumerable<PlaneCategoryServiceModel> AllCategories();

        bool CategoryExists(int categoryId);

    }
}
