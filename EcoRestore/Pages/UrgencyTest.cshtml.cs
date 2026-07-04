using EcoRestore.Models;
using EcoRestore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcoRestore.Pages
{
    public class UrgencyTestModel : PageModel
    {
        private readonly IUrgencyCalculationService urgencyCalculationService;

        public UrgencyTestModel(IUrgencyCalculationService urgencyCalculationService)
        {
            this.urgencyCalculationService = urgencyCalculationService;
        }

        [BindProperty(SupportsGet = true)]
        public double Latitude { get; set; } = 42.02;

        [BindProperty(SupportsGet = true)]
        public double Longitude { get; set; } = 23.09;

        public UrgencyLevel? Urgency { get; set; }
        public bool Searched { get; set; } = false;

        public double? Ndvi { get; set; }
        public decimal? OrganicCarbon { get; set; }

        public async Task OnGetAsync()
        {
            if (Request.Query.ContainsKey("Latitude"))
            {
                Searched = true;
                Urgency = await urgencyCalculationService.CalculateUrgencyAsync(Latitude, Longitude);
            }
        }
    }
}