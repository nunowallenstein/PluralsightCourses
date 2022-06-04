using CityInfo.API.DbContexts;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {

        private readonly ILogger<CitiesController> _logger;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
        private const int citiesMaxPageSize = 30;
        public CitiesController(ILogger<CitiesController> logger, ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _logger = logger;
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCities(
            [FromQuery(Name = "name")] string? name,
            [FromQuery(Name ="searchQuery")] string? searchQuery,
            int pageSize=citiesMaxPageSize,
            int pageNumber=1)
        {
            if(pageSize>citiesMaxPageSize)
                pageSize = citiesMaxPageSize;



           var (citiesEntities, paginationMetadata)=await _cityInfoRepository.GetCitiesAsync(name,searchQuery,pageSize,pageNumber);

            //adicionar ao header
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

           var cities= _mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(citiesEntities);
     
            return Ok(cities);
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
