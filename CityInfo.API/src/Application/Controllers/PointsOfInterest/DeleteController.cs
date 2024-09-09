using CityInfo.API.Domain.Models;
using CityInfo.API.Domain.Services;
using CityInfo.API.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Application.Controllers.PointsOfInterest
{
    [Tags("Points of Interest")]
    [Route("api/cities/{cityId}/pointsofinterest/{id}")]
    [ApiController]
    public class DeleteController(IMail mail) : ControllerBase
    {
        private readonly IMail _mailService = mail ?? throw new ArgumentNullException(nameof(mail));

        [HttpDelete]
        public ActionResult<PointOfInterest> DeletePointOfInterest(int cityId, int id)
        {
            City? city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => cityId == c.Id);

            if (null == city)
            {
                return NotFound();
            }

            PointOfInterest? pointOfInterestToDelete = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (null == pointOfInterestToDelete)
            {
                return NotFound();
            }

            city.PointsOfInterest.Remove(pointOfInterestToDelete);

            _mailService.Send(
                "Point of interest deleted",
                $"Point of interest {pointOfInterestToDelete.Name} with ID {pointOfInterestToDelete.Id} was deleted."
            );

            return NoContent();
        }
    }
}
