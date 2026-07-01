using EcoRestore.Common;
using System.ComponentModel.DataAnnotations;

namespace EcoRestore.Models
{
    public class Fauna
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinFaunaNameLength)]
        [MaxLength(ValidationConstants.MaxFaunaNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        public FaunaType Type { get; set; }

        [Required]
        public ClimateZone ClimateZone { get; set; }

        public string? HabitatNotes { get; set; }

        public ICollection<PlantingPlan> PlantingPlans { get; set; } = new List<PlantingPlan>();
    }
}
