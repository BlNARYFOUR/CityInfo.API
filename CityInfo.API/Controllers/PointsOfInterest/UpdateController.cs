using CityInfo.API.Commands;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers.PointsOfInterest
{
    [Route("api/cities/{cityId}/pointsofinterest/{id}")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        [HttpPut]
        public ActionResult<PointOfInterestDto> UpdatePointOfInterest(int cityId, int id, UpdatePointOfInterest updateComnand)
        {
            CityDto? city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => cityId == c.Id);

            if (null == city)
            {
                return NotFound();
            }

            PointOfInterestDto? pointOfInterestToUpdate = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (null == pointOfInterestToUpdate)
            {
                return NotFound();
            }

            pointOfInterestToUpdate.Name = updateComnand.Name;
            pointOfInterestToUpdate.Description = updateComnand.Description;

            return NoContent();
        }
    }
}
