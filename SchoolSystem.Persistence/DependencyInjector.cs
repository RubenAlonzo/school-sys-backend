namespace SchoolSystem.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using SchoolSystem.Persistence.Repositories;
    using SchoolSystem.Persistence.Repositories.Contracts;

    public static class DependencyInjector
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(opt =>
            {
                opt.UseNpgsql(connectionString, x => x.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));
            });
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IScheduleRepository, ScheduleRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            
            return services;
        }
    }
}
