using CityInfo.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok(CitiesDataStore.GetInstance().Cities);
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id)
        {
            CityDto? city = CitiesDataStore.GetInstance().Cities.FirstOrDefault(c => c.Id == id);

            if (null == city)
            {
                return NotFound();
            }

            return Ok(city);
        }
    }
}
