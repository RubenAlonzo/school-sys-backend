namespace SchoolSystem.Application
{
    using Microsoft.Extensions.DependencyInjection;
    using SchoolSystem.Application.Services;
    using SchoolSystem.Application.Services.Contracts;

    public static class DependencyInjector
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // TODO: Change to scoped after DB configured
            services.AddSingleton<IRoomService, RoomService>();

            return services;
        }
    }
}
