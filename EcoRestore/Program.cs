using EcoRestore.Data;
using EcoRestore.Services.Interfaces;
using EcoRestore.Services.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<EcoRestoreDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPlotService, PlotService>();
builder.Services.AddScoped<IPlantingPlanService, PlantingPlanService>();
builder.Services.AddHttpClient<ISoilDataService, SoilDataService>();
builder.Services.AddHttpClient<IVegetationDataService, VegetationDataService>();
builder.Services.AddScoped<IUrgencyCalculationService, UrgencyCalculationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EcoRestoreDbContext>();
    await DbSeeder.SeedAsync(db);
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();