using CityInfo.API.Application.Dtos;
using CityInfo.API.Domain.Models;
using CityInfo.API.Infrastructure.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Application.Controllers.PointsOfInterest
{
    [Tags("Points of Interest")]
    [Route("api/cities/{cityId}/pointsofinterest/{id}")]
    [ApiController]
    public class PatchController : ControllerBase
    {
        [HttpPatch]
        public ActionResult<PointOfInterest> PatchPointOfInterest(int cityId, int id, JsonPatchDocument<PatchPointOfInterest> patchDocument)
        {
            City? city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => cityId == c.Id);

            if (null == city)
            {
                return NotFound();
            }

            PointOfInterest? pointOfInterestToPatch = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (null == pointOfInterestToPatch)
            {
                return NotFound();
            }

            PatchPointOfInterest patchDto = new() { Name = pointOfInterestToPatch.Name, Description = pointOfInterestToPatch.Description };
            patchDocument.ApplyTo(patchDto, ModelState);

            if (!ModelState.IsValid || !TryValidateModel(patchDto))
            {
                return BadRequest(ModelState);
            }

            pointOfInterestToPatch.Name = patchDto.Name;
            pointOfInterestToPatch.Description = patchDto.Description;

            return NoContent();
        }
    }
}
