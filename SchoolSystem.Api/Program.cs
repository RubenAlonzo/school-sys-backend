using SchoolSystem.Api.Middlewares;
using SchoolSystem.Application;
using SchoolSystem.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration.GetConnectionString("WebApiDatabase")!);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // NOTE: As we don't indicate the time zone from our dates, we should use the unespecified timezone. Refer to: https://www.npgsql.org/doc/types/datetime.html#timestamps-and-timezones

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ValidationExceptionMiddleware>();

app.MapControllers();

app.Run();
