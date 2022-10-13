namespace LimeAirlinesSystem.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Models.Planes;
    using Microsoft.AspNetCore.Mvc;

    public class PlanesController : Controller

    {
        private readonly AirlineDbContext data;

        public PlanesController(AirlineDbContext data)
            => this.data = data;


        public IActionResult All()
        {
            var cars = this.data
                .Planes
                .OrderByDescending(p => p.Id)
                .Select(p => new PlaneListingViewModel
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    Model = p.Model,
                    ImageUrl = p.ImageUrl,
                    Year = p.Year,
                    Category = p.Category.Name
                })
                .ToList();

            return View(cars);
        }





        public IActionResult Add() => View(new AddPlaneFormModel
        {
            Categories = this.GetPlaneCategories()
        });


        [HttpPost]
        public IActionResult Add(AddPlaneFormModel plane)
        {
            if (!this.data.Categories.Any(c => c.Id == plane.CategoryId))
            {
                this.ModelState.AddModelError(nameof(plane.CategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                plane.Categories = this.GetPlaneCategories();

                return View(plane);
            }

            var planeAdd = new Plane
            {
                Brand = plane.Brand,
                Model = plane.Model,
                NumberOfSeats = plane.NumberOfSeats,
                ImageUrl = plane.ImageUrl,
                Year = plane.Year,
                CategoryId = plane.CategoryId
            };

            this.data.Planes.Add(planeAdd);

            this.data.SaveChanges();


            return RedirectToAction("Index", "Home");

        }


        private IEnumerable<PlaneCategoryViewModel> GetPlaneCategories()
        => this.data
            .Categories
            .Select(c => new PlaneCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToList();
    }
}
