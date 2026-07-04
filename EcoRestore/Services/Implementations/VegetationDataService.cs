using EcoRestore.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;

namespace EcoRestore.Services.Implementations
{
    public class VegetationDataService: IVegetationDataService
    {

        private readonly HttpClient httpClient;

        public VegetationDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<double?> GetNdviAsync(double latitude, double longitude)
        {
            try
            {
                var targetDate = DateTime.UtcNow.AddDays(-40);
                string modisDate = $"A{targetDate.Year}{targetDate.DayOfYear:D3}";

                string url = $"https://modis.ornl.gov/rst/api/v1/MOD13Q1/subset?latitude={latitude}&longitude={longitude}&startDate={modisDate}&endDate={modisDate}&kmAboveBelow=0&kmLeftRight=0";

                var response = await httpClient.GetAsync(url);
                if (!response.IsSuccessStatusCode) return null;

                string json = await response.Content.ReadAsStringAsync();

                using JsonDocument doc = JsonDocument.Parse(json);
                var subset = doc.RootElement.GetProperty("subset");

                double? rawNdvi = null;

                foreach (var entry in subset.EnumerateArray())
                {
                    string band = entry.GetProperty("band").GetString();

                    if (band == "250m_16_days_NDVI")
                    {
                        rawNdvi = entry.GetProperty("data")[0].GetDouble();
                    }
                }

                if (rawNdvi.HasValue)
                {
                    return rawNdvi.Value / 10000;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

    }
}
