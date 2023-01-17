﻿namespace LimeAirlinesSystem.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using LimeAirlinesSystem.Data;
    using LimeAirlinesSystem.Data.Models;
    using LimeAirlinesSystem.Models.Flights;
    using LimeAirlinesSystem.Services.Flights;
    using LimeAirlinesSystem.Services.Planes.Models;
    using Microsoft.AspNetCore.Mvc;

    public class FlightsController : Controller
    {
        private readonly IFlightService flights;
        private readonly IMapper mapper;

        public FlightsController(IFlightService flights, IMapper mapper)
        {
            this.flights = flights;
            this.mapper = mapper;
        }


        public IActionResult All([FromQuery] AllFlightsQueryModel query)
        {
            var queryResult = this.flights.All(
                query.TripType,
                query.StartLocation,
                query.EndLocation,
                query.CurrentPage,
                //query.FlightDateTime,
                AllFlightsQueryModel.FlightsPerPage);

            var 
        }



    }
}
