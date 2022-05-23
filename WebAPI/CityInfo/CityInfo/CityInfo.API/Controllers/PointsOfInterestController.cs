using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly ILogger<PointsOfInterestController> _logger;
        private readonly ILocalMailService _mailService;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, ILocalMailService mailService, ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<List<PointOfInterestDto>>> GetPointsOfInterest(int cityId)
        {
            try
            {
                if (await _cityInfoRepository.HasCityAsync(cityId))
                {
                    _logger.LogInformation($"City with Id {cityId} wasn't found when accessing the point of interest.");
                    return NotFound();
                }

                var pointsOfInterest = await _cityInfoRepository.GetPointsOfInterestForCityAsync(cityId);
                return Ok(_mapper.Map<PointOfInterestDto>(pointsOfInterest));
            }
            catch (Exception ex)
            {
                _logger.LogCritical("An error occured while trying to access the points of interest for city {cityId} with the exeption {ex}", cityId, ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }

        }

        [HttpGet("{pointofinterestId}", Name = "GetPointOfInterest")]
        public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(int cityId, int pointOfInterestId)
        {
            if (await _cityInfoRepository.HasCityAsync(cityId))
                return NotFound();


            var pointOfInterest = await _cityInfoRepository.GetPointOfInterestForCityAsync(cityId, pointOfInterestId);
            if (pointOfInterest == null)
                return NotFound();

            return Ok(_mapper.Map<PointOfInterestDto>(pointOfInterest));


        }

        //[HttpPost]
        //public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, PointOfInterestForCreationDto pointOfInterest)
        //{
        //    var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    var maxPointOfInterestId = _citiesDataStore.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

        //    var finalPointOfInterest = new PointOfInterestDto()
        //    {
        //        Id = maxPointOfInterestId++,
        //        Name = pointOfInterest.Name,
        //        Description = pointOfInterest.Description

        //    };

        //    city.PointsOfInterest.Add(finalPointOfInterest);

        //    return CreatedAtRoute("GetPointOfInterest",
        //        new
        //        {
        //            cityId = cityId,
        //            pointOfInterestId = finalPointOfInterest.Id
        //        },
        //        finalPointOfInterest);

        //}

        //[HttpPut("{pointofInterestId}")]

        //public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId, PointOfInterestForUpdateDto pointOfInterest)
        //{
        //    CityDto city = _citiesDataStore.Cities.FirstOrDefault(city => city.Id == cityId);



        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    PointOfInterestDto pointOfInterestStore = city.PointsOfInterest.FirstOrDefault(point => point.Id == pointOfInterestId);

        //    if (pointOfInterest == null)
        //    {
        //        return NotFound();
        //    }

        //    pointOfInterestStore.Name = pointOfInterest.Name;
        //    pointOfInterestStore.Description = pointOfInterest.Description;

        //    return NoContent();

        //}
        //[HttpPatch("{pointofInterestId}")]

        //public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId, JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        //{
        //    CityDto city = _citiesDataStore.Cities.FirstOrDefault(city => city.Id == cityId);



        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    PointOfInterestDto pointOfInterestStore = city.PointsOfInterest.FirstOrDefault(point => point.Id == pointOfInterestId);

        //    if (pointOfInterestStore == null)
        //    {
        //        return NotFound();
        //    }


        //    PointOfInterestForUpdateDto pointOfInterestToPatch = new PointOfInterestForUpdateDto()
        //    {
        //        Name = pointOfInterestStore.Name,
        //        Description = pointOfInterestStore.Description
        //    };

        //    patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }


        //    if (!TryValidateModel(pointOfInterestToPatch))
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    pointOfInterestStore.Name = pointOfInterestToPatch.Name;
        //    pointOfInterestStore.Description = pointOfInterestToPatch.Description;

        //    return NoContent();

        //}
        //[HttpDelete("{pointofinterestId}")]

        //public ActionResult DeletePointOfInterest(int cityId, int pointOfInterestId)
        //{

        //    CityDto city = _citiesDataStore.Cities.FirstOrDefault(city => city.Id == cityId);
        //    if (city == null)
        //    {
        //        return NotFound();
        //    }

        //    PointOfInterestDto pointOfInterestStore = city.PointsOfInterest.FirstOrDefault(point => point.Id == pointOfInterestId);

        //    if (pointOfInterestStore == null)
        //    {
        //        return NotFound();
        //    }

        //    city.PointsOfInterest.Remove(pointOfInterestStore);

        //    _mailService.Send("Point of interest deleted",
        //        $"Point of interest {pointOfInterestStore.Name} with id {pointOfInterestStore.Id} was deleted.");
        //    return NoContent();

        //}

    }
}
