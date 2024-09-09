using CityInfo.API.Domain.Models;

namespace CityInfo.API.Domain.Repositories
{
    public interface ICityRepository
    {
        public ICollection<City> GetList();

        public City? GetById(int id);
    }
}
