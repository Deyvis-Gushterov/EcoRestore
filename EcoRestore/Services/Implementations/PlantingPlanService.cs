using EcoRestore.Data;
using EcoRestore.Models;
using EcoRestore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoRestore.Services.Implementations
{
    public class PlantingPlanService: IPlantingPlanService
    {
        private EcoRestoreDbContext context;

        public PlantingPlanService(EcoRestoreDbContext context)
        {
            this.context = context;
        }

        public async Task<List<PlantingPlan>> GetByPlotIdAsync(int plotId)
        {
            return await context.PlantingPlans
                .Where(p => p.PlotId == plotId)
                .ToListAsync();
        }

        public async Task<PlantingPlan> CreateAsync(PlantingPlan plan)
        {
            
            await context.PlantingPlans.AddAsync(plan);
            await context.SaveChangesAsync();
            return plan;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var plan = await context.PlantingPlans
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        
                if (plan == null) return false;
             context.Remove(plan);
            await context.SaveChangesAsync();
            return true;
        }
    }

}
