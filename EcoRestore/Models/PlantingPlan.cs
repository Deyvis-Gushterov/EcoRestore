using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoRestore.Models
{
    public class PlantingPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PlotId { get; set; }
        [ForeignKey("PlotId")]
        public Plot Plot { get; set; } = null!;

        [Required]
        public int TreeSpeciesId { get; set; }
        [ForeignKey("TreeSpeciesId")]
        public TreeSpecies Tree { get; set; } = null!;

        [Required]
        public int NumberOfTrees { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Fauna> SuggestedFauna { get; set; } = new List<Fauna>();
    }
}
