using CityInfo.API.Application.Dtos;
using CityInfo.API.Domain.Exceptions;
using CityInfo.API.Domain.Models;
using CityInfo.API.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Application.Controllers.PointsOfInterest
{
    [Tags("Points of Interest")]
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class CreateController(IPointOfInterestRepository repository) : ControllerBase
    {
        private readonly IPointOfInterestRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        [HttpPost]
        public ActionResult<PointOfInterest> CreatePointOfInterest(int cityId, CreatePointOfInterest createDto)
        {
            PointOfInterest pointOfInterest;

            try
            {
                pointOfInterest = _repository.Create(cityId, createDto.Name, createDto.Description);
            }
            catch (CityNotFoundException)
            {
                return NotFound();
            }

            return CreatedAtRoute("GetPointOfInterest", new { cityId, id = pointOfInterest.Id }, pointOfInterest);
        }
    }
}
