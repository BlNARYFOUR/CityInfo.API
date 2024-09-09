using CityInfo.API.Domain.Models;
using CityInfo.API.Domain.Repositories;
using CityInfo.API.Infrastructure.Services;

namespace CityInfo.API.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        public ICollection<City> GetList()
        {
            return CitiesDataStore.Instance.Cities;
        }

        public City? GetById(int id)
        {
            return CitiesDataStore.Instance.Cities.FirstOrDefault(c => c.Id == id);
        }
    }
}
