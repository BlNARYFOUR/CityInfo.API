using CityInfo.API.Domain.Exceptions;
using CityInfo.API.Domain.Models;
using CityInfo.API.Domain.Repositories;
using CityInfo.API.Infrastructure.Services;

namespace CityInfo.API.Infrastructure.Repositories
{
    public class PointOfInterestRepository : IPointOfInterestRepository
    {
        public ICollection<PointOfInterest>? GetList(int cityId)
        {
            return CitiesDataStore.Instance
                .Cities.FirstOrDefault(c => c.Id == cityId)
                ?.PointsOfInterest;
        }

        public PointOfInterest? GetById(int cityId, int id)
        {
            return CitiesDataStore.Instance
                .Cities.FirstOrDefault(c => c.Id == cityId)
                ?.PointsOfInterest.FirstOrDefault(p => p.Id == id);
        }

        public PointOfInterest Create(int cityId, string name, string? description)
        {
            City city = CitiesDataStore.Instance.Cities.FirstOrDefault(c => cityId == c.Id) ?? throw CityNotFoundException.ForId(cityId);

            PointOfInterest pointOfInterest = new() { Id = ++CitiesDataStore.Instance.LastPointOfInterestId, Name = name, Description = description };
            city.PointsOfInterest.Add(pointOfInterest);

            return pointOfInterest;
        }
    }
}
