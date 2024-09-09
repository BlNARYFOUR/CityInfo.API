using CityInfo.API.Domain.Models;
using CityInfo.API.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Application.Controllers.PointsOfInterest
{
    [Tags("Points of Interest")]
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class GetListController(IPointOfInterestRepository repository, ILogger<GetListController> logger) : ControllerBase
    {
        private readonly IPointOfInterestRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        private readonly ILogger<GetListController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterest>> GetPointsOfInterest(int cityId)
        {
            ICollection<PointOfInterest>? pointsOfInterest = _repository.GetList(cityId);

            if (null == pointsOfInterest)
            {
                _logger.LogInformation("City not found: for ID {Id}.", cityId);

                return NotFound();
            }

            return Ok(pointsOfInterest);
        }
    }
}
