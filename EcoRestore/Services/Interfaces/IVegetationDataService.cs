namespace EcoRestore.Services.Interfaces
{
    public interface IVegetationDataService
    {
        Task<double?> GetNdviAsync(double latitude, double longitude);
    }
}
