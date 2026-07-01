using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EcoRestore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faunas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ClimateZone = table.Column<int>(type: "integer", nullable: false),
                    HabitatNotes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faunas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoilTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    FertilityRate = table.Column<double>(type: "double precision", nullable: false),
                    RecommendedAmendment = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoilTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TreeSpecies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ScientificName = table.Column<string>(type: "text", nullable: true),
                    CO2SequestrationKgPerYear = table.Column<decimal>(type: "numeric", nullable: false),
                    ClimateZone = table.Column<int>(type: "integer", nullable: false),
                    GrowthRateCategory = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeSpecies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    AreaHectares = table.Column<double>(type: "double precision", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    SoilTypeId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plots_SoilTypes_SoilTypeId",
                        column: x => x.SoilTypeId,
                        principalTable: "SoilTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlantingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlotId = table.Column<int>(type: "integer", nullable: false),
                    TreeSpeciesId = table.Column<int>(type: "integer", nullable: false),
                    NumberOfTrees = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantingPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantingPlans_Plots_PlotId",
                        column: x => x.PlotId,
                        principalTable: "Plots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantingPlans_TreeSpecies_TreeSpeciesId",
                        column: x => x.TreeSpeciesId,
                        principalTable: "TreeSpecies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FaunaPlantingPlan",
                columns: table => new
                {
                    PlantingPlansId = table.Column<int>(type: "integer", nullable: false),
                    SuggestedFaunaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaunaPlantingPlan", x => new { x.PlantingPlansId, x.SuggestedFaunaId });
                    table.ForeignKey(
                        name: "FK_FaunaPlantingPlan_Faunas_SuggestedFaunaId",
                        column: x => x.SuggestedFaunaId,
                        principalTable: "Faunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaunaPlantingPlan_PlantingPlans_PlantingPlansId",
                        column: x => x.PlantingPlansId,
                        principalTable: "PlantingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FaunaPlantingPlan_SuggestedFaunaId",
                table: "FaunaPlantingPlan",
                column: "SuggestedFaunaId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingPlans_PlotId",
                table: "PlantingPlans",
                column: "PlotId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingPlans_TreeSpeciesId",
                table: "PlantingPlans",
                column: "TreeSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Plots_SoilTypeId",
                table: "Plots",
                column: "SoilTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FaunaPlantingPlan");

            migrationBuilder.DropTable(
                name: "Faunas");

            migrationBuilder.DropTable(
                name: "PlantingPlans");

            migrationBuilder.DropTable(
                name: "Plots");

            migrationBuilder.DropTable(
                name: "TreeSpecies");

            migrationBuilder.DropTable(
                name: "SoilTypes");
        }
    }
}
