using CityInfo.API.Domain.Models;
using CityInfo.API.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Application.Controllers.PointsOfInterest
{
    [Tags("Points of Interest")]
    [Route("api/cities/{cityId}/pointsofinterest/{id}")]
    [ApiController]
    public class GetByIdController(IPointOfInterestRepository repository) : ControllerBase
    {
        private readonly IPointOfInterestRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        [HttpGet(Name = "GetPointOfInterest")]
        public ActionResult<IEnumerable<PointOfInterest>> GetPointOfInterest(int cityId, int id)
        {
            PointOfInterest? pointOfInterest = _repository.GetById(cityId, id);

            if (null == pointOfInterest)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }
    }
}
