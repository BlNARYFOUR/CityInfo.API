using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers.PointsOfInterest
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class GetListController : ControllerBase
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
    }
}
