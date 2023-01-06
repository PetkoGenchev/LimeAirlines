namespace LimeAirlinesSystem.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Models.Planes;
    using LimeAirlinesSystem.Services.Planes;
    using LimeAirlinesSystem.Services.Planes.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PlanesController : Controller

    {
        private readonly IPlaneService planes;
        private readonly IMapper mapper;

        public PlanesController(IPlaneService planes, IMapper mapper)
        {
            this.planes = planes;
            this.mapper = mapper;
        }


        public IActionResult All()
        {
            var planes = this.data
                .Planes
                .OrderByDescending(p => p.Id)
                .Select(p => new PlaneListingServiceModel
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    Model = p.Model,
                    ImageUrl = p.ImageUrl,
                    NumberOfSeats = p.NumberOfSeats,
                    Year = p.Year,
                    Category = p.Category.Name
                })
                .ToList();

            return View(planes);
        }



        public IActionResult Add() => View(new PlaneFormModel
        {
            Categories = this.planes.AllCategories()
        });


        [HttpPost]
        [Authorize]
        public IActionResult Add(PlaneFormModel plane)
        {
            if (!this.planes.CategoryExists(plane.CategoryId))
            {
                this.ModelState.AddModelError(nameof(plane.CategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                plane.Categories = this.planes.AllCategories();

                return View(plane);
            }

            var planeId = this.planes.Create(
                plane.Brand,
                plane.Model,
                plane.NumberOfSeats,
                plane.ImageUrl,
                plane.Year,
                plane.CategoryId);

            return RedirectToAction(nameof(All));

        }




    }
}
