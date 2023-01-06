namespace LimeAirlinesSystem.Services.Planes
{
    using System.Collections.Generic;
    using LimeAirlinesSystem.Services.Planes.Models;

    public interface IPlaneService
    {
        int Create(
            string brand,
            string model,
            int numberofSeats,
            string imageUrl,
            int year,
            int categoryId
            );

        bool Edit(
            int carId,
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
