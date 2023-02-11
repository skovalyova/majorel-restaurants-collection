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

TBD - how to connect to the database, update schema and run the app

## Maintenance

### Install DB management tooling

Follow the [official EF Core documentation](https://docs.microsoft.com/en-us/ef/core/cli/dotnet#installing-the-tools).

### Adding a migration

If you have changed the database schema and need to create a migration, please use the following command:

- Open Package Manager Console in Visual Studio
- Set `Majorel.RestaurantsCollection.Infrastructure` as a default project
- Run the command ```Add-Migration <MigrationName> -OutputDir Persistence/Migrations```

#### Create and update database

To create or update the database manually from migrations, please use the following command:

- Open Package Manager Console in Visual Studio
- Set `Majorel.RestaurantsCollection.Infrastructure` as a default project
- Run the command ```Update-Database```
