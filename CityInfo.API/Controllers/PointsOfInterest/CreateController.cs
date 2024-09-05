using CityInfo.API.Commands;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers.PointsOfInterest
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    [Tags("Points of Interest")]
    public class CreateController : ControllerBase
    {
        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, CreatePointOfInterest createCommand)
        {
            CityDto? city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => cityId == c.Id);

            if (null == city)
            {
                return NotFound();
            }

            PointOfInterestDto pointOfInterest = new() { Name = createCommand.Name, Description = createCommand.Description };
            city.PointsOfInterest.Add(pointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new { cityId, id = pointOfInterest.Id }, pointOfInterest);
        }
    }
}
