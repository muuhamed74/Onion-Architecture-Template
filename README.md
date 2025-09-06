# Onion Architecture Template

**A ready-to-use .NET Onion Architecture solution template** — Domain / Service Abstraction / Service (business logic) / Repo / API — scaffolded and wired with patterns already implemented (Specification pattern, Unit of Work, global error handling middleware, repository interfaces, EF migrations skeleton). Use this to start a new project in one command.

---


## Overview

This repository contains a full Onion Architecture skeleton intended to be used as a reusable `dotnet new` template. It models the dependency direction and separation of concerns typically expected from Onion/Hexagonal/Clean architecture. The solution in this template contains the following projects (exact names preserved):

* `OnionTemplate.Domain` — lowest-level layer: Entities, DTOs, repository interfaces, and a folder for Specification design pattern.
* `Service Abstraction` — abstract service interfaces (contracts). Implementations live in the Service layer.
* `OnionTemplate.Service` — concrete service implementations: contains business logic and implements the interfaces defined in `Service Abstraction`.
* `OnionTemplate.Repo` — infrastructure / data access: EF Core DbContext (in a `Data` folder), Configurations, Repositories (implementations for the Domain repository interfaces), and `Migrations`.
* `Onion-Architecture-Template` — the API project (controllers, helpers, middlewares). Contains:

  * `Controllers/` - API controllers and endpoints.
  * `Helpers/Errors/` - global error handling utilities.
  * `Middlewares/` - middleware pipeline (global error handler implemented here).
* `GitHub Actions` — CI workflows (optional) for build/test/publish.

> The dependency flow is: `API` → `Service` → `Service Abstraction`/`Domain` ← `Repo` (Repo implements Domain interfaces). Domain has no dependencies on other layers.

---

## Template features (what's already implemented)

* Entities, DTOs and repository interfaces in `OnionTemplate.Domain`.
* Specification design pattern implemented (folder under Domain + usage examples in Repositories).
* `Service Abstraction` holds the service contracts.
* `OnionTemplate.Service` contains business logic and implements service contracts.
* `OnionTemplate.Repo` contains `DbContext` (under `Data/`), EF Core `Configurations`, `Migrations` folder, repository implementations and a `UnitOfWork` implementation.
* Global error handling implemented via a central middleware in `Middlewares/` and helper classes under `Helpers/Errors/`.
* * `Helpers/MappingProfiles` folder contains all object-to-object mapping configurations (e.g., AutoMapper profiles).
* Basic DI wiring skeleton and example `Controllers` in the root API project.

---

## Quickstart

1. Download or clone this repository as a folder.
2. From the repository root, install the template locally:

### Tips

- Ensure the file `.template.config/template.json` exists in the repository root before running `dotnet new install`.
- After creating a new project from the template, open the generated solution in Visual Studio.
- Set the API project as the **Startup Project**.
- Update the connection string in `appsettings.json` (or via environment variables) before running migrations or starting the app.
- If you face `.vs` folder or permissions issues when committing, add `.vs/` to `.gitignore` and run:  
  ```bash
  git rm -r --cached .vs










