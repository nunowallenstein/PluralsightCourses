using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {

        private readonly ILogger<CitiesController> _logger;
        private readonly CitiesDataStore _citiesDataStore;
        public CitiesController(ILogger<CitiesController> logger, CitiesDataStore citiesDataStore )
        {
            _logger = logger;
            _citiesDataStore = citiesDataStore;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok(_citiesDataStore.Cities);
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id)
        {
            var cityToReturn = _citiesDataStore.Cities.FirstOrDefault(city => city.Id == id);

            if (cityToReturn == null)
                return NotFound();

            else
            return Ok(cityToReturn);
        }
    }
}
