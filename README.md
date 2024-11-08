# CepediFullStackChallenge

A .NET API project structured following Clean Architecture principles. This application was developed as a suggested challenge for the ResTic36 FullStack folks. The goal is to implement an API following best practices to ensure quality, maintainability, and scalability. The project is organized into four main layers: Domain, Application, Infrastructure, and API.

## Table of Contents

- [Project Structure](#project-structure)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Database Setup](#database-setup)
  - [Running the API](#running-the-api)
- [Project Structure Overview](#project-structure-overview)

## Project Structure

This project uses Clean Architecture, structured as follows:

1. **Domain**: Contains core entities, interfaces, and domain logic.
2. **Application**: Includes application services and use cases.
3. **Infrastructure**: Implements data access with Entity Framework Core.
4. **Presentation (API)**: ASP.NET Core MVC API that handles HTTP requests and responses.

## Technologies Used

- **.NET 8** - Core framework for building the API.
- **Entity Framework Core** - ORM for database access.
- **SQLite** - Database provider (configured via connection string).
- **Dependency Injection** - For managing service lifetimes and dependencies.
  
## Getting Started

### Prerequisites

- [.NET SDK 8.x](https://dotnet.microsoft.com/download) or higher
- [Entity Framework CLI](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) (optional but recommended)

### Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/v1tor2003/cepedi-fullstackapi-challenge.git
    cd cepedi-fullstackapi-challenge
    ```

2. **Add necessary packages (if not installed):**

   Run this command in each project to install required dependencies:

    ```bash
    dotnet restore
    ```

### Database Setup

1. **Configure Database Connection:** (optional)

   Update the connection string to point to another .db file if you want, in `CepediFullStack.Presentation/appsettings.json` with the file name.

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Data Source=path/to/newdbfile"
   }
   ```

2. **Apply Migrations:**

   Navigate to the `Infrastructure` project and run the following commands to create and apply the initial migration:

    ```bash
    # Move to Infrastructure folder
    cd CepediFullStack.Infrastructure

    # Add the initial migration
    dotnet ef migrations add InitialCreate -s ../CepediFullStack.Presentation -p .

    # Update the database
    dotnet ef database update -s ../CepediFullStack.Presentation -p .
    ```

   This will create the necessary tables in your database.

### Running the API

To run the API, use the following command:

```bash
dotnet run --project CepediFullStack.Presentation
```

The API will be available at `http://localhost:5000` by default (or `http://localhost:5001` for HTTPS). You can configure the port in the `launchSettings.json` file within the API project.

### Testing the API

Use tools like [Postman](https://www.postman.com/) or [Swagger UI](https://swagger.io/tools/swagger-ui/) to test API endpoints. Swagger is set up by default and can be accessed at:

```
http://localhost:5000/swagger
```

## Project Structure Overview

- **Domain Layer**: Contains domain entities and interfaces.
- **Application Layer**: Holds the application's business logic and service layer.
- **Infrastructure Layer**: Implements repository interfaces and data access using Entity Framework Core.
- **API Layer**: ASP.NET Core Web API project, containing controllers and presentation logic.

Feel free to explore each layer for a better understanding of the project's architecture.
