using System.ComponentModel.DataAnnotations;
using EcoRestore.Common;

namespace EcoRestore.Models
{
    public class TreeSpecies
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinTreeNameLength)]
        [MaxLength(ValidationConstants.MaxTreeNameLength)]
        public string Name { get; set; } = null!;

        public string? ScientificName { get; set; }

        [Required]
        public decimal CO2SequestrationKgPerYear { get; set; }

        [Required]
        public ClimateZone ClimateZone { get; set; }

        [Required]
        public GrowthRateCategory GrowthRateCategory { get; set; }
    }
}
