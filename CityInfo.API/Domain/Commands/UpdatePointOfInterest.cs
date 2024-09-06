using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Domain.Commands
{
    public class UpdatePointOfInterest
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(256)]
        public string? Description { get; set; }
    }
}
