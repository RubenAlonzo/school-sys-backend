namespace SchoolSystem.Application
{
    using FluentValidation;
    using Microsoft.Extensions.DependencyInjection;
    using SchoolSystem.Application.Services;
    using SchoolSystem.Application.Services.Contracts;

    public static class DependencyInjector
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<IApplicationMarker>(ServiceLifetime.Transient);
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IScheduleService, ScheduleService>();

            return services;
        }
    }
}
