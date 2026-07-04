using EcoRestore.Models;
using EcoRestore.Services.Interfaces;

namespace EcoRestore.Services.Implementations
{
    public class UrgencyCalculationService: IUrgencyCalculationService
    {
        private readonly ISoilDataService soilDataService;
        private readonly IVegetationDataService vegetationDataService;

        public UrgencyCalculationService(ISoilDataService soilDataService, IVegetationDataService vegetationDataService)
        {
            this.soilDataService = soilDataService;
            this.vegetationDataService = vegetationDataService;
        }

        public async Task<UrgencyLevel> CalculateUrgencyAsync(double latitude, double longitude)
        {
            var soilData = await soilDataService.GetSoilDataAsync(latitude, longitude);
            var ndvi = await vegetationDataService.GetNdviAsync(latitude, longitude);

            double ndviScore;
            if (ndvi.HasValue)
            {
                double clamped = Math.Clamp(ndvi.Value, 0.1, 0.6);
                ndviScore = 1 - ((clamped - 0.1) / (0.6 - 0.1));
            }
            else
            {
                ndviScore = 0.5; // unknown, assuming medium
            }

            double socScore;
            if (soilData?.OrganicCarbon.HasValue == true)
            {
                double clamped = (double)Math.Clamp(soilData.OrganicCarbon.Value, 5, 30);
                socScore = 1 - ((clamped - 5) / (30 - 5));
            }
            else
            {
                socScore = 0.5;
            }

            double degradationScore = (ndviScore + socScore) / 2;

            if (degradationScore >= 0.66) return UrgencyLevel.High;
            if (degradationScore >= 0.33) return UrgencyLevel.Medium;
            return UrgencyLevel.Low;
        }
    }
}
