using EcoRestore.Models;
using EcoRestore.Models.Dtos;

namespace EcoRestore.Services.Interfaces
{
    public interface IRecommendationService
    {
        public Task<PlotRecommendation> GetPlotRecommendationAsync (ClimateZone climateZone, SoilType? soilType);
    }
}
