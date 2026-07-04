using System.ComponentModel.DataAnnotations;

namespace EcoRestore.Models.Dtos
{
    public class SoilDataResult
    {
        public decimal? OrganicCarbon { get; set; }
        public double? ClayContent { get; set; }
        public double? Ph { get; set; }
    }
}
