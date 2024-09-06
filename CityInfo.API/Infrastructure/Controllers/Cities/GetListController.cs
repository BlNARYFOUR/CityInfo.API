using CityInfo.API.Domain.Models;
using CityInfo.API.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Infrastructure.Controllers.Cities
{
    [Route("api/cities")]
    [ApiController]
    [Tags("Cities")]
    public class GetListController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok(CitiesDataStore.Instance.Cities);
        }
    }
}
