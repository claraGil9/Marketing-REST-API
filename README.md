# Marketing REST API

___

## Overview

This project is a REST API built with ASP.NET Core 8 that generates:

- Personalized marketing emails (multi-language)
- Commercial proposal PDFs on demand

The API uses Excel files as a data source and applies data cleaning and transformation before generating outputs.

---

## Tech Stack
- .NET 8 (ASP.NET Core Web API)
- C#
- [ClosedXML](https://github.com/ClosedXML/ClosedXML) (Excel reading)
- [QuestPDF](https://www.questpdf.com) (PDF generation)
- [Swagger](https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-8.0) (Testing and Documentation)

---

## Architecture

The project follows a simplified Clean Architecture:

- Domain → Core entities (Lead, Sector)
- Application → Business logic and services
- Infrastructure → Excel reading, PDF and HTML generation
- Controllers → API endpoints
- Shared → Helpers, constants

---

## Data Source

Two Excel files are used:

- leads (2).xlsx
- sectors (2).xlsx

Data is loaded into memory and normalized to handle inconsistencies such as:

- Invalid budget formats
- Multiple boolean representations
- Language inconsistencies

---

## API Endpoints
- POST /api/mailing/send: Generates personalized emails for valid leads. Filters:
  - Active leads
  - Budget > 10,000

- GET /api/dossier/{id}: Generates a PDF dossier for a specific lead. Returns:
  - 200 → PDF file
  - 404 → Lead not found

---

## Data Normalization

The system includes a normalization layer to handle inconsistent Excel data:

- Budget parsing (currency symbols, strings, etc.)
- Boolean normalization (yes/true/1)
- Language mapping (ES, EN, AR + variations)

---

## How to Run
1. Clone the repository
2. Open in Visual Studio
3. Run the project
4. Access Swagger (it should open automatically): https://localhost:{port}/swagger

Use Swagger to test endpoints.

--- 

## Design Decisions
- Separation of concerns using layered architecture
- Dependency Injection for flexibility
- In-memory data to simulate database
- Multi-language support using enums and dictionaries