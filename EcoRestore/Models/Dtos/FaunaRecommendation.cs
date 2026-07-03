using System.ComponentModel.DataAnnotations;

namespace EcoRestore.Models.Dtos
{
    public class FaunaRecommendation
    {
        public ICollection<Fauna> Fauna { get; set; } = new List<Fauna>();

        [Required]
        public string Reason { get; set; } = null!;
    }
}
