using EcoRestore.Data;
using EcoRestore.Models;
using EcoRestore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoRestore.Services.Implementations
{
    public class PlotService: IPlotService
    {
        private EcoRestoreDbContext context;

        public PlotService(EcoRestoreDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Plot>> GetAllAsync()
        {
            return await context.Plots.ToListAsync();
        }

        public async Task<Plot?> GetByIdAsync(int id)
        {
            return await context.Plots
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

        }

        public async Task<Plot?> CreateAsync(Plot plot)
        {

            await context.Plots.AddAsync(plot);
            await context.SaveChangesAsync();
            return plot;
        }

        public async Task<Plot?> UpdateAsync(Plot plot)
        {
            if (plot == null) return null;

            var oldPlot = await context.Plots
                .Where(p => p.Id == plot.Id)
                .FirstOrDefaultAsync();

            if (oldPlot == null) return null;

            oldPlot.Name = plot.Name;
            oldPlot.AreaHectares = plot.AreaHectares;
            oldPlot.Location = plot.Location;
            oldPlot.SoilTypeId = plot.SoilTypeId;

            await context.SaveChangesAsync();
            return oldPlot;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var plot = await context.Plots
                 .Where(p => p.Id == id)
                 .FirstOrDefaultAsync();

            if (plot == null) return false;

            context.Plots.Remove(plot);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
