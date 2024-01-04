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
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IScheduleService, ScheduleService>();

            return services;
        }
    }
}
