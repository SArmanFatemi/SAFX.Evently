# Evently.Modules.Events.Api

## Working with Entity Framework

### Add migration
```shell
dotnet ef migrations add MIGRATION_NAME --project .\src\Modules\Events\Evently.Modules.Events.Infrastructure\Evently.Modules.Events.Infrastructure.csproj --startup-project .\src\API\Evently.Api\Evently.Api.csproj --output-dir Database/Migrations --context EventsDbContext
```
