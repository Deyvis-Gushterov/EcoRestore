using EcoRestore.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoRestore.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(EcoRestoreDbContext context)
        {
            await SeedSoilTypesAsync(context);
            await SeedTreeSpeciesAsync(context);
            await SeedFaunaAsync(context);
        }


        private static async Task SeedSoilTypesAsync(EcoRestoreDbContext context)
        {
            if (await context.SoilTypes.AnyAsync())
                return;

            var soilTypes = new List<SoilType>
            {
                new SoilType { Name = "Loam", FertilityRate = 8, RecommendedAmendment = "Minimal amendment needed - good structure and fertility" },
                new SoilType { Name = "Clay", FertilityRate = 5, RecommendedAmendment = "Add organic matter/compost to improve drainage" },
                new SoilType { Name = "Sandy", FertilityRate = 3, RecommendedAmendment = "Add compost and mulch to improve water/nutrient retention" },
                new SoilType { Name = "Chalky", FertilityRate = 4, RecommendedAmendment = "Add organic matter; correct alkalinity with sulfur if needed" },
                new SoilType { Name = "Degraded/Poor", FertilityRate = 2, RecommendedAmendment = "Add compost, biochar, and nitrogen-fixing cover crops" },
            };

            await context.SoilTypes.AddRangeAsync(soilTypes);
            await context.SaveChangesAsync();
        }

        private static async Task SeedTreeSpeciesAsync(EcoRestoreDbContext context)
        {
            // check if data exists, if not, insert tree species rows
            if (await context.TreeSpecies.AnyAsync())
                return;

            var treeSpecies = new List<TreeSpecies>
            {
                new TreeSpecies {Name = "English Oak", ScientificName = "Quercus robur", CO2SequestrationKgPerYear = 22, ClimateZone = ClimateZone.Cfb, GrowthRateCategory = GrowthRateCategory.Slow},
                new TreeSpecies {Name = "European Beech", ScientificName = "Fagus sylvatica", CO2SequestrationKgPerYear = 20, ClimateZone = ClimateZone.Cfb, GrowthRateCategory = GrowthRateCategory.Slow},
                new TreeSpecies {Name = "Silver Birch", ScientificName = "Betula pendula", CO2SequestrationKgPerYear = 15, ClimateZone = ClimateZone.Cfb, GrowthRateCategory = GrowthRateCategory.Fast},
                new TreeSpecies {Name = "Scots Pine", ScientificName = "Pinus sylvestris", CO2SequestrationKgPerYear = 18, ClimateZone = ClimateZone.Cfb, GrowthRateCategory = GrowthRateCategory.Medium},
                new TreeSpecies {Name = "Common Alder", ScientificName = "Alnus glutinosa", CO2SequestrationKgPerYear = 17, ClimateZone = ClimateZone.Cfb, GrowthRateCategory = GrowthRateCategory.Fast},
                new TreeSpecies {Name = "Norway Spruce", ScientificName = "Picea abies", CO2SequestrationKgPerYear = 20, ClimateZone = ClimateZone.Dfb, GrowthRateCategory = GrowthRateCategory.Medium},
                new TreeSpecies {Name = "Small-leaved Lime", ScientificName = "Tilia cordata", CO2SequestrationKgPerYear = 19, ClimateZone = ClimateZone.Dfb, GrowthRateCategory = GrowthRateCategory.Slow},
                new TreeSpecies {Name = "European Aspen", ScientificName = "Populus tremula", CO2SequestrationKgPerYear =  16, ClimateZone = ClimateZone.Dfb, GrowthRateCategory = GrowthRateCategory.Fast},
                new TreeSpecies {Name = "Sessile Oak", ScientificName = "Quercus petraea", CO2SequestrationKgPerYear = 21, ClimateZone = ClimateZone.Dfb, GrowthRateCategory = GrowthRateCategory.Slow},
            };

            await context.TreeSpecies.AddRangeAsync(treeSpecies);
            await context.SaveChangesAsync();
        }

        private static async Task SeedFaunaAsync(EcoRestoreDbContext context)
        {
            // check if data exists, if not, insert fauna rows
            if (await context.Faunas.AnyAsync())
                return;

            var fauna = new List<Fauna>
            {
                new Fauna {Name = "European Hedgehog", Type = FaunaType.Mammal, ClimateZone = ClimateZone.Cfb, HabitatNotes = "Needs hedgerows, log piles, undergrowth"},
                new Fauna {Name = "Eurasian Red Squirrel", Type = FaunaType.Mammal, ClimateZone = ClimateZone.Cfb, HabitatNotes = "Needs mature conifer/broadleaf cover"},
                new Fauna {Name = "European Robin", Type = FaunaType.Bird, ClimateZone = ClimateZone.Cfb, HabitatNotes = "Woodland edges, shrubs"},
                new Fauna {Name = "Common Blackbird", Type = FaunaType.Bird, ClimateZone = ClimateZone.Cfb, HabitatNotes = "Woodland and shrub understory"},
                new Fauna {Name = "Honeybee", Type = FaunaType.Pollinator, ClimateZone = ClimateZone.Cfb, HabitatNotes = "Needs flowering understory plants"},
                new Fauna {Name = "Roe Deer", Type = FaunaType.Mammal, ClimateZone = ClimateZone.Dfb, HabitatNotes = "Needs mixed forest with clearings"},
                new Fauna {Name = "Red Fox", Type = FaunaType.Mammal, ClimateZone = ClimateZone.Dfb, HabitatNotes = "Adaptable, needs cover and prey base"},
                new Fauna {Name = "Eurasian Jay", Type = FaunaType.Bird, ClimateZone = ClimateZone.Dfb, HabitatNotes = "Oak/mixed woodland, spreads acorns"},
                new Fauna {Name = "Great Tit", Type = FaunaType.Bird, ClimateZone = ClimateZone.Dfb, HabitatNotes = "Woodland, nest cavities"},
                new Fauna {Name = "Bumblebee", Type = FaunaType.Pollinator, ClimateZone = ClimateZone.Dfb, HabitatNotes = "Needs flowering plants, undisturbed ground for nesting"},
            };

            await context.Faunas.AddRangeAsync(fauna);
            await context.SaveChangesAsync();
        }
    }


}


