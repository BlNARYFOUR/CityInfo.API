using CityInfo.API.Commands;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            CityDto? city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => c.Id == cityId);

            if (null == city)
            {
                return NotFound();
            }

            return Ok(city.PointsOfInterest);
        }

        [HttpGet("{id}", Name = "GetPointOfInterest")]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointOfInterest(int cityId, int id)
        {
            CityDto? city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => c.Id == cityId);

            if (null == city)
            {
                return NotFound();
            }

            PointOfInterestDto? pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (null == pointOfInterest)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

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

        [HttpPut("{id}")]
        public ActionResult<PointOfInterestDto> UpdatePointOfInterest(int cityId, int id, UpdatePointOfInterest updateComnand)
        {
            CityDto? city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => cityId == c.Id);

            if (null == city)
            {
                return NotFound();
            }

            PointOfInterestDto? pointOfInterestToUpdate = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (null == pointOfInterestToUpdate)
            {
                return NotFound();
            }

            pointOfInterestToUpdate.Name = updateComnand.Name;
            pointOfInterestToUpdate.Description = updateComnand.Description;

            return NoContent();
        }

        [HttpPatch("{id}")]
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
