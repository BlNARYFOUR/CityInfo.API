using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers.Cities
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
