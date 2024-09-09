using CityInfo.API.Domain.Models;
using CityInfo.API.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Application.Controllers.Cities
{
    [Tags("Cities")]
    [Route("api/cities")]
    [ApiController]
    public class GetListController(ICityRepository repository) : ControllerBase
    {
        private readonly ICityRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        [HttpGet]
        public ActionResult<IEnumerable<City>> GetCities()
        {
            return Ok(_repository.GetList());
        }
    }
}
