using CityInfo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            CityDto? city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => c.Id == cityId);

            if (null == city)
            {
                return NotFound();
            }

            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{id}", Name = "GetPointOfInterest")]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointOfInterest(int cityId, int id)
        {
            CityDto? city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => c.Id == cityId);

            if (null == city)
            {
                return NotFound();
            }

            PointOfInterestDto? pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (null == pointOfInterest)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, PointOfInterestDto pointOfInterest)
        {
            CityDto? city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => cityId == c.Id);

            if (null == city)
            {
                return NotFound();
            }

            city.PointsOfInterest.Add(pointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new { cityId, id = pointOfInterest.Id }, pointOfInterest);
        }
    }
}
