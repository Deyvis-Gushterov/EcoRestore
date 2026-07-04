using EcoRestore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoRestore.Pages
{
    public class VegetationTestModel : PageModel
    {
        private readonly IVegetationDataService vegetationDataService;

        public VegetationTestModel(IVegetationDataService vegetationDataService)
        {
            this.vegetationDataService = vegetationDataService;
        }

        [BindProperty(SupportsGet = true)]
        public double Latitude { get; set; } = 42.02;

        [BindProperty(SupportsGet = true)]
        public double Longitude { get; set; } = 23.09;

        public double? Ndvi { get; set; }
        public bool Searched { get; set; } = false;

        public async Task OnGetAsync()
        {
            if (Request.Query.ContainsKey("Latitude"))
            {
                Searched = true;
                Ndvi = await vegetationDataService.GetNdviAsync(Latitude, Longitude);
            }
        }
    }
}