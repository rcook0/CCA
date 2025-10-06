# Recovery Merge Changelog

- Source of truth: full.zip (user)
- Additive donor: mycca-reconstructed.zip
- Conflict policy: keep larger file on same path

## Notable adds/patches
- added: MyCCA.sln
- added: docker-compose.yml
- added: src/Core/Core.csproj
- added: src/Core/Entities/User.cs
- added: src/Core/Entities/TargetEntity.cs
- added: src/Core/Entities/Application.cs
- added: src/Core/Entities/Milestone.cs
- added: src/Core/Entities/Decision.cs
- added: src/Core/Entities/Assessment.cs
- added: src/Infrastructure/Infrastructure.csproj
- added: src/Infrastructure/Data/AppDbContext.cs
- added: src/WebApi/Program.cs
- added: src/WebApi/WebApi.csproj
- added: src/WebApi/Dockerfile
- added: src/WebApi/Api/ProgramExtensions.cs
- added: src/WebApi/Api/HealthEndpoints.cs
- added: src/WebApi/Api/SecurityHeadersMiddleware.cs
- added: src/WebApi/Api/RateLimitingExtensions.cs
- added: src/WebApi/Api/V2Endpoints.cs
- added: src/Frontend/Dockerfile
- added: src/Frontend/package.json
- added: src/Frontend/package-lock.json
- added: src/Frontend/pages/index.js
