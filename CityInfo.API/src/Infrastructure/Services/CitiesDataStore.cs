using CityInfo.API.Domain.Models;

namespace CityInfo.API.Infrastructure.Services
{
    public class CitiesDataStore
    {
        public ICollection<City> Cities { get; }
        public int LastCityId = 0;
        public int LastPointOfInterestId = 0;
        public static CitiesDataStore Instance { get { return _instance ??= new CitiesDataStore(); } }
        private static CitiesDataStore? _instance;

        private CitiesDataStore()
        {
            Cities = [
                new() {
                    Id = ++LastCityId,
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest = [
                        new(){ Id = ++LastPointOfInterestId, Name = "Central Park", Description = "The most visited urban park in the United States." },
                        new(){ Id = ++LastPointOfInterestId, Name = "Empire State Building", Description = "A 102-story skyscraper in Midtown Manhatten." },
                    ],
                }, new() {
                    Id = ++LastCityId,
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished.",
                     PointsOfInterest = [
                        new(){ Id = ++LastPointOfInterestId, Name = "Cathedral of Our Lady", Description = "A Gothic style cathedral, conceived by architects Jan and Pieter." },
                        new(){ Id = ++LastPointOfInterestId, Name = "Antwerp Central Station", Description = "The finest example of railway architecture in Belgium." },
                    ],
                }, new() {
                    Id = ++LastCityId,
                    Name = "Paris",
                    Description = "The one with that big tower.",
                     PointsOfInterest = [
                        new(){ Id = ++LastPointOfInterestId, Name = "Eiffel Tower", Description = "A wrought iron lattice tower on the Champ de Mars, named after the engineer Gustave Eiffel." },
                        new(){ Id = ++LastPointOfInterestId, Name = "The Louvre", Description = "The world's largest museum." },
                    ],
                },
            ];
        }
    }
}
