using CityInfo.API.Application.Dtos;
using CityInfo.API.Domain.Models;
using CityInfo.API.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Application.Controllers.PointsOfInterest
{
    [Tags("Points of Interest")]
    [Route("api/cities/{cityId}/pointsofinterest/{id}")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        [HttpPut]
        public ActionResult<PointOfInterest> UpdatePointOfInterest(int cityId, int id, UpdatePointOfInterest updateDto)
        {
            City? city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => cityId == c.Id);

            if (null == city)
            {
                return NotFound();
            }

            PointOfInterest? pointOfInterestToUpdate = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (null == pointOfInterestToUpdate)
            {
                return NotFound();
            }

            pointOfInterestToUpdate.Name = updateDto.Name;
            pointOfInterestToUpdate.Description = updateDto.Description;

            return NoContent();
        }
    }
}
