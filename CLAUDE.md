# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

Two independent projects intended to form an invoices app, currently both at framework-scaffold stage:

- **`Invoices.Api/`** — ASP.NET Core minimal-API backend (.NET 10). Still the default template: exposes only `GET /weatherforecast` from [Program.cs](Invoices.Api/Program.cs). No invoice domain code yet.
- **`invoices-web/`** — Vite + React 19 frontend (JSX, no TypeScript). Still the default Vite landing page in [App.jsx](invoices-web/src/App.jsx). No API client wired up yet.

The two are not connected — there is no proxy config, CORS setup, or shared contract between them. Wiring the frontend to the API is expected greenfield work.

## Project Structure

Keep this tree updated as the project grows.

```
invoicesPlayground/
├── CLAUDE.md
├── Invoices.Api/                  # ASP.NET Core minimal-API backend (.NET 10)
│   ├── Invoices.Api.csproj        # project file / NuGet deps
│   ├── Program.cs                 # entry point + endpoint definitions
│   ├── Invoices.Api.http          # sample HTTP requests for manual testing
│   ├── appsettings.json           # base config
│   ├── appsettings.Development.json
│   └── Properties/
│       └── launchSettings.json    # local run profiles / ports
└── invoices-web/                  # Vite + React 19 frontend (JSX)
    ├── index.html                 # app HTML shell
    ├── package.json               # scripts / deps
    ├── vite.config.js             # Vite + React plugin config
    ├── eslint.config.js           # ESLint flat config
    ├── public/                    # static assets served as-is (favicon, icons)
    └── src/
        ├── main.jsx               # React entry / root render
        ├── App.jsx                # root component
        ├── App.css, index.css     # styles
        └── assets/                # bundled images (logos, hero)
```

## Commands

### Backend (`Invoices.Api/`)

- Run (HTTP): `dotnet run` — serves on `http://localhost:5129`
- Run (HTTPS): `dotnet run --launch-profile https` — adds `https://localhost:7157`
- Build: `dotnet build`
- OpenAPI doc is mapped only in Development at `/openapi/v1.json`.

### Frontend (`invoices-web/`)

- Dev server (HMR): `npm run dev`
- Build: `npm run build`
- Lint: `npm run lint` (ESLint flat config in [eslint.config.js](invoices-web/eslint.config.js))
- Preview production build: `npm run preview`

No test runner is configured in either project yet.
