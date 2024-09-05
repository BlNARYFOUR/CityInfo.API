using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers.PointsOfInterest
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class GetListController(ILogger<GetListController> logger) : ControllerBase
    {
        private readonly ILogger<GetListController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            CityDto? city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => c.Id == cityId);

            if (null == city)
            {
                _logger.LogInformation("City not found: for ID {Id}.", cityId);

                return NotFound();
            }

            return Ok(city.PointsOfInterest);
        }
    }
}
