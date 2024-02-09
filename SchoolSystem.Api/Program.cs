using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SchoolSystem.Api.Middlewares;
using SchoolSystem.Application;
using SchoolSystem.Domain.Entities;
using SchoolSystem.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration.GetConnectionString("WebApiDatabase")!);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // NOTE: As we don't indicate the time zone from our dates, we should use the unespecified timezone. Refer to: https://www.npgsql.org/doc/types/datetime.html#timestamps-and-timezones

// Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Auth
builder.Services.AddAuthorization(x =>
{
    x.FallbackPolicy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
});
builder.Services
    .AddIdentityApiEndpoints<UserEntity>()
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<ApplicationContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ValidationExceptionMiddleware>();

app.MapGroup("/api/account")
    .MapIdentityApi<UserEntity>()
    .AllowAnonymous();

app.MapControllers();

app.Run();
