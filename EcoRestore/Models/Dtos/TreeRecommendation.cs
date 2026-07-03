using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace EcoRestore.Models.Dtos
{
    public class TreeRecommendation
    {
        public ICollection<TreeSpecies> Trees { get; set; } = new List<TreeSpecies>();

        [Required]
        public string Reason { get; set; } = null!;
    }
}
