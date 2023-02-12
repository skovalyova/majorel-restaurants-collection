# Restaurants Collection API

## Motivation

A company is launching a new service that provides details of restaurants spread across multiple cities. A 'restaurant collection' needs to be created, as well as a service to maintain this restaurant collection. Please refer to the `NET Developer Test.docx` document.

## Implementation notes

Stack:

- .NET 7
- Entity Framework
- MS SQL
- Mediatr
- Automapper
- XUnit, FluentAssertions

Changes in contracts:

- The `Update rating` endpoint was implemented using PATCH instead of PUT to highlight that the resource is updated partially.
- The `Get by ID` endpoint was implemented as `restaurant/{id}` rather than `restaurant/query?id={id}` to separate it from filtering endpoints and to better follow REST principles.

TODO:

- Remove commented code, cleanup of usings
- Describe changes in contracts
- Add validation to all endpoints (FluentValidation) - if time allows
- Test error handling middleware
- Configure and describe docker and docker compose
- Meaningful swagger samples
- Check the solution has no warnings

## Tests

API endpoints are covered with integration tests that send HTTP requests to the in-memory test API instance. For simplicity sake, there's in-memory provider instead of real SQL database.
However, it should be redesigned to use SQLite database or real SQL database to provide more stable solution.

## Quick start

You may follow any of two options below in order to start the application.

### Option 1 - Visual Studio

- Make sure you have the SQL database instance up and running.
- Use `appsettings.Development.json` or secret manager in order to set `ConnectionStrings->RestaurantsDatabase` connection string.
- Run the application in Visual Studio.
- Database is created automatically during the application startup.
- Navigate to the [https://localhost:7015/swagger](https://localhost:7015/swagger) to start exploring the API.

### Option 2 - Docker

- Open the command line and `cd` into the root repository catalog.
- Create an empty text file with the name `.env`.
- Paste the following `key=value` configuration settings to the `.env` file as shown below, feel free to change the value:
    - `MSSQL_SA_PASSWORD=S0meStr0ngP@$$w0rd`
    - Please note the password must be at least 8 characters including uppercase, lowercase letters, base-10 digits and/or non-alphanumeric symbols.
- Run `docker compose -p restaurants-collection-dev -f "docker-compose.dev.yml" up -d` command to spin up SQL database and API.
- Database is created automatically during the application startup.
- Navigate to the [http://localhost:5000/swagger](http://localhost:5000/swagger) to start exploring the API.

## Maintenance

### Install DB management tooling

Follow the [official EF Core documentation](https://docs.microsoft.com/en-us/ef/core/cli/dotnet#installing-the-tools).

### Adding a migration

If you have changed the database schema and need to create a migration, please use the following command:

- Open Package Manager Console in Visual Studio
- Set `Majorel.RestaurantsCollection.Infrastructure` as a default project
- Run the command ```Add-Migration <MigrationName> -OutputDir Persistence/Migrations```

#### Migrating the database

To create or update the database manually from migrations, please use the following command:

- Open Package Manager Console in Visual Studio
- Set `Majorel.RestaurantsCollection.Infrastructure` as a default project
- Run the command ```Update-Database```
