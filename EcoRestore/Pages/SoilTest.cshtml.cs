using EcoRestore.Models.Dtos;
using EcoRestore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoRestore.Pages
{
    public class SoilTestModel : PageModel
    {
        private readonly ISoilDataService soilDataService;

        public SoilTestModel(ISoilDataService soilDataService)
        {
            this.soilDataService = soilDataService;
        }

        [BindProperty(SupportsGet = true)]
        public double Latitude { get; set; } = 42.13;

        [BindProperty(SupportsGet = true)]
        public double Longitude { get; set; } = 23.09;

        public SoilDataResult? Result { get; set; }
        public bool Searched { get; set; } = false;

        public async Task OnGetAsync()
        {
            if (Request.Query.ContainsKey("Latitude"))
            {
                Searched = true;
                Result = await soilDataService.GetSoilDataAsync(Latitude, Longitude);
            }
        }
    }
}