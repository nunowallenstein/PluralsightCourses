using CityInfo.API.DbContexts;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {

        private readonly ILogger<CitiesController> _logger;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
        public CitiesController(ILogger<CitiesController> logger, ICityInfoRepository cityInfoRepository,  IMapper mapper )
        {
            _logger = logger;
            _cityInfoRepository = cityInfoRepository ??throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ??throw new ArgumentNullException(nameof(mapper)); 
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCities()
        {
           var citiesEntities=await _cityInfoRepository.GetCitiesAsync();
           var cities= _mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(citiesEntities);
     
            return Ok(cities);
            //return Ok(_citiesDataStore.Cities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id,bool includePointsOfInterest=false)
        {
            var city =await _cityInfoRepository.GetCityAsync(id, includePointsOfInterest);

            if(city==null)
                return NotFound();  

            if (includePointsOfInterest)
                return Ok(_mapper.Map<CityDto>(city));
            else
                return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(city));
        }
    }
}
