namespace EcoRestore.Models.Dtos
{
    public class PlotRecommendation
    {
        public ClimateZone ClimateZone { get; set; }
        public TreeRecommendation RecommendedTrees { get; set; } = null!;
        public FaunaRecommendation RecommendedFauna { get; set; } = null!;
    }
}
