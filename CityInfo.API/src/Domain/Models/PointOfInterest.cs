using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Domain.Models
{
    public class PointOfInterest
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(256)]
        public string? Description { get; set; }
    }
}
