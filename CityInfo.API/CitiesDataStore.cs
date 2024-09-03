using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; }
        public static CitiesDataStore Instance { get { return _instance ??= new CitiesDataStore(); }}
        private static CitiesDataStore? _instance;

        private CitiesDataStore()
        {
            Cities = [
                new() {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest = [
                        new(){ Id = 1, Name = "Central Park", Description = "The most visited urban park in the United States." },
                        new(){ Id = 2, Name = "Empire State Building", Description = "A 102-story skyscraper in Midtown Manhatten." },
                    ],
                }, new() {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished.",
                     PointsOfInterest = [
                        new(){ Id = 3, Name = "Cathedral of Our Lady", Description = "A Gothic style cathedral, conceived by architects Jan and Pieter." },
                        new(){ Id = 4, Name = "Antwerp Central Station", Description = "The finest example of railway architecture in Belgium." },
                    ],
                }, new() {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with that big tower.",
                     PointsOfInterest = [
                        new(){ Id = 5, Name = "Eiffel Tower", Description = "A wrought iron lattice tower on the Champ de Mars, named after the engineer Gustave Eiffel." },
                        new(){ Id = 6, Name = "The Louvre", Description = "The world's largest museum." },
                    ],
                },
            ];
        }
    }
}
