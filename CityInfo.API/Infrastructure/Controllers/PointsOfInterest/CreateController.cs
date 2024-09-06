using CityInfo.API.Domain.Commands;
using CityInfo.API.Domain.Models;
using CityInfo.API.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Infrastructure.Controllers.PointsOfInterest
{
    [Tags("Points of Interest")]
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
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
