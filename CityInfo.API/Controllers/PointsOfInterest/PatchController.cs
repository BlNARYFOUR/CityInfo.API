using CityInfo.API.Commands;
using CityInfo.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers.PointsOfInterest
{
    [Route("api/cities/{cityId}/pointsofinterest/{id}")]
    [ApiController]
    public class PatchController : ControllerBase
    {
        [HttpPatch]
        public ActionResult<PointOfInterestDto> PatchPointOfInterest(int cityId, int id, JsonPatchDocument<PatchPointOfInterest> patchDocument)
        {
            CityDto? city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => cityId == c.Id);

            if (null == city)
            {
                return NotFound();
            }

            PointOfInterestDto? pointOfInterestToPatch = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (null == pointOfInterestToPatch)
            {
                return NotFound();
            }

            PatchPointOfInterest patchCommand = new() { Name = pointOfInterestToPatch.Name, Description = pointOfInterestToPatch.Description };
            patchDocument.ApplyTo(patchCommand, ModelState);

            if (!ModelState.IsValid || !TryValidateModel(patchCommand))
            {
                return BadRequest(ModelState);
            }

            pointOfInterestToPatch.Name = patchCommand.Name;
            pointOfInterestToPatch.Description = patchCommand.Description;

            return NoContent();
        }
    }
}
