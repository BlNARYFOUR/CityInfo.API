using CityInfo.API.Domain.Models;

namespace CityInfo.API.Domain.Repositories
{
    public interface IPointOfInterestRepository
    {
        public ICollection<PointOfInterest>? GetList(int cityId);
        public PointOfInterest? GetById(int cityId, int id);
        /// <exception cref="Exceptions.CityNotFoundException" />
        public PointOfInterest Create(int cityId, string name, string? description);
    }
}
