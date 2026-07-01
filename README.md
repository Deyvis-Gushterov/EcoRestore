# 🌱 EcoRestore

A web app for planning land restoration. Mark a plot of land, get tree and fauna suggestions matched to its climate zone and soil, and see the estimated environmental impact — CO2 sequestration, oxygen production, and what changes would improve it.

## What it does

- Define a **plot** of land (area, location, soil type)
- Get **tree species suggestions** matched to the plot's climate zone and soil, with realistic CO2/O2 impact estimates
- Get **fauna suggestions** — species that would benefit from the proposed planting plan
- See projected environmental impact over time
- (Planned) Draw the plot directly on a map and get instant area calculation + visualization

## Tech stack

- ASP.NET Core (Razor Pages)
- PostgreSQL
- Entity Framework Core (Npgsql)
- Docker (local Postgres container)
- AI-assisted features via Groq / Gemini (used for explaining results and filling data gaps — not for core calculations)

## Current status

🚧 Early development — core data model and database are set up. Not yet functional end-to-end.

### Done
- [x] Project scaffolding
- [x] PostgreSQL running in Docker
- [x] Core data model: `Plot`, `TreeSpecies`, `SoilType`, `Fauna`, `PlantingPlan`
- [x] Relationships mapped and migrated (EF Core)

### Up next
- [ ] Seed reference data (tree species, soil types, fauna) for a handful of climate zones
- [ ] CRUD pages for `Plot`
- [ ] Core calculation engine (CO2/O2 projections based on species, count, soil, growth rate)
- [ ] Suggestion logic (recommend species/fauna based on plot's climate zone + soil)
- [ ] AI-assist layer for explaining results / filling data gaps
- [ ] Google Maps integration — draw a plot boundary on a map, auto-calculate area, visualize results
- [ ] Shareable "impact report" output (inspired by Ecosia's tree counter concept)

## Getting started

### Prerequisites
- .NET SDK
- Docker Desktop

### Run the database
```bash
docker run --name ecorestore-db -e POSTGRES_PASSWORD=yourpassword -e POSTGRES_DB=ecorestore -p 5433:5432 -d postgres
```

### Apply migrations
```powershell
Update-Database
```

### Run the app
```bash
dotnet run
```

## Why this project

Most carbon/reforestation calculators either oversimplify ("plant a tree, offset X kg CO2") or require expensive expert consultation. EcoRestore aims for a middle ground: a free, approachable tool that gives realistic, climate-zone-aware suggestions for restoring a piece of land — grounded in real reference data rather than guesses.
