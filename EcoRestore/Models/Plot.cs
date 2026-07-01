using System.ComponentModel.DataAnnotations;
using EcoRestore.Common;
namespace EcoRestore.Models
{
    public class Plot
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinPlotNameLength)]
        [MaxLength(ValidationConstants.MaxPlotNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        public double AreaHectares { get; set; }
        public string? Location {  get; set; }
        public int? SoilTypeId { get; set; }
        public SoilType? SoilType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<PlantingPlan> PlantingPlans { get; set; } = new List<PlantingPlan>();
    }
}
