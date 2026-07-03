using EcoRestore.Models;

namespace EcoRestore.Services.Interfaces
{
    public interface IPlantingPlanService
    {
        public Task<List<PlantingPlan>> GetByPlotIdAsync(int plotId);
        public Task<PlantingPlan> CreateAsync(PlantingPlan plan);
        public Task<bool> DeleteAsync(int id);
    }
}
