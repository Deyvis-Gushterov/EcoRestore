using EcoRestore.Models.Dtos;
using EcoRestore.Services.Interfaces;
using System.Text.Json;

namespace EcoRestore.Services.Implementations
{
    public class SoilDataService: ISoilDataService
    {
        private readonly HttpClient httpClient;

        public SoilDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<SoilDataResult?> GetSoilDataAsync(double latitude, double longitude)
        {
            try
            {
                string url = $"https://rest.isric.org/soilgrids/v2.0/properties/query?lon={longitude}&lat={latitude}&property=soc&property=phh2o&property=clay&depth=0-5cm&value=mean";

                var response = await httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode) return null;

                string json = await response.Content.ReadAsStringAsync();

                using JsonDocument doc = JsonDocument.Parse(json);
                var layers = doc.RootElement.GetProperty("properties").GetProperty("layers");

                double? soc = null;
                double? ph = null;
                double? clay = null;

                foreach (var layer in layers.EnumerateArray())
                {
                    string name = layer.GetProperty("name").GetString();
                    double meanValue = layer.GetProperty("depths")[0].GetProperty("values").GetProperty("mean").GetDouble();

                    if (name == "soc") soc = meanValue;
                    if (name == "phh2o") ph = meanValue;
                    if (name == "clay") clay = meanValue;
                }

                return new SoilDataResult
                {
                    OrganicCarbon = soc.HasValue ? (decimal)(soc.Value / 10) : null,
                    Ph = ph.HasValue ? ph.Value / 10 : null,
                    ClayContent = clay.HasValue ? clay.Value / 10 : null
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
