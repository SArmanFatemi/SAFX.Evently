# Evently.Modules.Attendance.Api

## Working with Entity Framework

### Add migration
```shell
dotnet ef migrations add Init --project .\src\Modules\Attendance\Evently.Modules.Attendance.Infrastructure\Evently.Modules.Attendance.Infrastructure.csproj --startup-project .\src\API\Evently.Api\Evently.Api.csproj --output-dir Database/Migrations --context AttendanceDbContext
```
