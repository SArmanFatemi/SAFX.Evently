# Evently.Modules.Events.Api

## Working with Entity Framework

### Add migration
```shell
dotnet ef migrations add Init --project .\src\Modules\Users\Evently.Modules.Users.Infrastructure\Evently.Modules.Users.Infrastructure.csproj --startup-project .\src\API\Evently.Api\Evently.Api.csproj --output-dir Database/Migrations --context UsersDbContext
```
