using System.ComponentModel.DataAnnotations;
using EcoRestore.Common;

namespace EcoRestore.Models
{
    public class SoilType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinSoilNameLength)]
        [MaxLength(ValidationConstants.MaxSoilNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        public double FertilityRate { get; set; }

        [Required]
        public string RecommendedAmendment { get; set; } = null!;

    }
}
