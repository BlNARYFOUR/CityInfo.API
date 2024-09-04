namespace CityInfo.API.Models
{
    public class PointOfInterestDto
    {
        private static int _id = 1;
        public int Id { get; set; } = _id++;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
