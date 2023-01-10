namespace LimeAirlinesSystem.Controllers
{
    using AutoMapper;
    using LimeAirlinesSystem.Infrastructure;
    using LimeAirlinesSystem.Models.Planes;
    using LimeAirlinesSystem.Services.Planes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PlanesController : Controller

    {
        private readonly IPlaneService planes;
        private readonly IMapper mapper;

        public PlanesController(
            IPlaneService planes,
            IMapper mapper)
        {
            this.planes = planes;
            this.mapper = mapper;
        }


        public IActionResult All([FromQuery] AllPlanesQueryModel query)
        {
            var queryResult = this.planes.All(
                query.CurrentPage,
                AllPlanesQueryModel.PlanesPerPage);

            query.TotalPlanes = queryResult.TotalPlanes;
            query.Planes = queryResult.Planes;

            return View(query);
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


        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var plane = this.planes.Details(id);

            var planeForm = this.mapper.Map<PlaneFormModel>(plane);

            planeForm.Categories = this.planes.AllCategories();

            return View(planeForm); 
        }


        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, PlaneFormModel plane)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            if (!this.planes.CategoryExists(plane.CategoryId))
            {
                this.ModelState.AddModelError(nameof(plane.CategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                plane.Categories = this.planes.AllCategories();

                return View(plane);
            }

            var edited = this.planes.Edit(
                id,
                plane.Brand,
                plane.Model,
                plane.NumberOfSeats,
                plane.ImageUrl,
                plane.Year,
                plane.CategoryId);

            if (!edited)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }


    }
}
