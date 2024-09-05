using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers.PointsOfInterest
{
    [Route("api/cities/{cityId}/pointsofinterest/{id}")]
    [ApiController]
    [Tags("Points of Interest")]
    public class DeleteController : ControllerBase
    {
        [HttpDelete]
        public ActionResult<PointOfInterestDto> DeletePointOfInterest(int cityId, int id)
        {
            CityDto? city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => cityId == c.Id);

            if (null == city)
            {
                return NotFound();
            }

            PointOfInterestDto? pointOfInterestToDelete = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (null == pointOfInterestToDelete)
            {
                return NotFound();
            }

            city.PointsOfInterest.Remove(pointOfInterestToDelete);

            return NoContent();
        }
    }
}
