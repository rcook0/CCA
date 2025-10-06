# Test Quickstart

## Backend
```bash
dotnet test backend/tests/Mycca.Api.Tests.csproj
```

## Frontend E2E (Playwright)
```bash
cd frontend/tests
npm i
npx playwright install
BASE_URL=http://localhost:3000 npm run test:e2e
```

## Perf (k6)
```bash
k6 run -e API_URL=http://localhost:5000 tests/perf/load.k6.js
```
