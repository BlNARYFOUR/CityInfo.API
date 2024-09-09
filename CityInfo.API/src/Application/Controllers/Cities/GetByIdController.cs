using CityInfo.API.Domain.Models;
using CityInfo.API.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Application.Controllers.Cities
{
    [Tags("Cities")]
    [Route("api/cities/{id}")]
    [ApiController]
    public class GetByIdController(ICityRepository repository) : ControllerBase
    {
        private readonly ICityRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        [HttpGet]
        public ActionResult<City> GetCity(int id)
        {
            City? city = _repository.GetById(id);

            if (null == city)
            {
                return NotFound();
            }

            return Ok(city);
        }
    }
}
