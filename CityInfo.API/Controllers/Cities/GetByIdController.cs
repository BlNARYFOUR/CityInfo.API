using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers.Cities
{
    [ApiController]
    [Route("api/cities/{id}")]
    public class GetByIdController : ControllerBase
    {
        [HttpGet]
        public ActionResult<CityDto> GetCity(int id)
        {
            CityDto? city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => c.Id == id);

            if (null == city)
            {
                return NotFound();
            }

            return Ok(city);
        }
    }
}
