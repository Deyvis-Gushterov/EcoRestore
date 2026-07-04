using EcoRestore.Models.Dtos;

namespace EcoRestore.Services.Interfaces
{
    public interface ISoilDataService
    {
        public Task<SoilDataResult?> GetSoilDataAsync(double latitude, double longitude);
    }
}
