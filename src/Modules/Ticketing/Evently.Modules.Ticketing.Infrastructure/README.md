# Evently.Modules.Ticketing.Infrastructure

## Working with Entity Framework

### Add migration
```shell
dotnet ef migrations add MIGRATION_NAME --project .\src\Modules\Ticketing\Evently.Modules.Ticketing.Infrastructure\Evently.Modules.Ticketing.Infrastructure.csproj --startup-project .\src\API\Evently.Api\Evently.Api.csproj --output-dir Database/Migrations --context TicketingDbContext
```
