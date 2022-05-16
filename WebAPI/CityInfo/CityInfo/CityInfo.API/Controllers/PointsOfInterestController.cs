using CityInfo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);
            if (city == null)
                return NotFound();

            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{pointofinterestId}", Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);
            if (city == null)
                return NotFound();

            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(point => point.Id == pointOfInterestId);
            if (pointOfInterest == null)
                return NotFound();

            return Ok(pointOfInterest);





        }

        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, PointOfInterestForCreationDto pointOfInterest)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = maxPointOfInterestId++,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description

            };

            city.PointsOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    cityId = cityId,
                    pointOfInterestId = finalPointOfInterest.Id
                },
                finalPointOfInterest);

        }

        [HttpPut("{pointofInterestId}")]

        public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId, PointOfInterestForUpdateDto pointOfInterest)
        {
            CityDto city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);



            if (city == null)
            {
                return NotFound();
            }

            PointOfInterestDto pointOfInterestStore = city.PointsOfInterest.FirstOrDefault(point => point.Id == pointOfInterestId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            pointOfInterestStore.Name = pointOfInterest.Name;
            pointOfInterestStore.Description = pointOfInterest.Description;

            return NoContent();

        }
        [HttpPatch("{pointofInterestId}")]

        public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId, JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        {
            CityDto city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);



            if (city == null)
            {
                return NotFound();
            }

            PointOfInterestDto pointOfInterestStore = city.PointsOfInterest.FirstOrDefault(point => point.Id == pointOfInterestId);

            if (pointOfInterestStore == null)
            {
                return NotFound();
            }


            PointOfInterestForUpdateDto pointOfInterestToPatch = new PointOfInterestForUpdateDto()
            {
                Name = pointOfInterestStore.Name,
                Description = pointOfInterestStore.Description
            };

            patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!TryValidateModel(pointOfInterestToPatch))
            {
                return BadRequest(ModelState);
            }
            pointOfInterestStore.Name = pointOfInterestToPatch.Name;
            pointOfInterestStore.Description = pointOfInterestToPatch.Description;

            return NoContent();

        }
        [HttpDelete("{pointofinterestId}")]

        public ActionResult DeletePointOfInterest(int cityId, int pointOfInterestId)
        {

            CityDto city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            PointOfInterestDto pointOfInterestStore = city.PointsOfInterest.FirstOrDefault(point => point.Id == pointOfInterestId);

            if (pointOfInterestStore == null)
            {
                return NotFound();
            }

            city.PointsOfInterest.Remove(pointOfInterestStore);

            return NoContent();
        }

    }
}
