using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers.PointsOfInterest
{
    [Route("api/cities/{cityId}/pointsofinterest/{id}")]
    [ApiController]
    public class GetByIdController : ControllerBase
    {
       [HttpGet(Name = "GetPointOfInterest")]
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
    }
}
