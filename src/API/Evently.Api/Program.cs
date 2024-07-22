using Evently.Modules.Events.Infrastructure;
using Evently.Modules.Events.Infrastructure.Database.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEventsModule(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	
	app.ApplyDatabaseMigrations();
}

EventsModule.MapEndpoint(app);
await app.RunAsync();
