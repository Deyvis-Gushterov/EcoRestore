using EcoRestore.Models;

namespace EcoRestore.Services.Interfaces
{
    public interface IUrgencyCalculationService
    {
        public Task<UrgencyLevel> CalculateUrgencyAsync(double latitude, double longitude);
    }
}
