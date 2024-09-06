using CityInfo.API.Domain.Models;
using CityInfo.API.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Infrastructure.Controllers.Cities
{
    [Route("api/cities/{id}")]
    [ApiController]
    [Tags("Cities")]
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
