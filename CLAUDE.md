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
├── package.json                   # root: `npm start` runs API + web together (concurrently)
├── .vscode/                       # F5 debug config (launch.json) + build task (tasks.json)
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

### Run everything (root)

- `npm install` once at the root (installs `concurrently`), plus deps in each project (`npm run install:all` does both).
- `npm start` — runs the API and web dev server together via `concurrently` (labelled `api`/`web`). API uses `dotnet watch` (hot reload). API on `http://localhost:5129`, web on `http://localhost:5173`.
- `npm run build` — builds the API then the web bundle.

`npm start` is for spinning up the full stack (smoke tests, demos). For active debugging, run the two separately (below) so you can attach a debugger and restart each independently.

### Backend (`Invoices.Api/`)

- Hot reload: `dotnet watch --project Invoices.Api`
- Breakpoint debugging: VS Code → Run and Debug → **Debug API (.NET)** (F5). Config in [.vscode/launch.json](.vscode/launch.json).
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
