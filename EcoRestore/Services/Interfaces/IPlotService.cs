using EcoRestore.Models;

namespace EcoRestore.Services.Interfaces
{
    public interface IPlotService
    {
        public Task<List<Plot>> GetAllAsync();
        public Task<Plot?> GetByIdAsync(int id);
        public Task<Plot?> CreateAsync(Plot plot);
        public Task<Plot?> UpdateAsync(Plot plot);
        public Task<bool> DeleteAsync(int id);
    }
}
