using Microsoft.EntityFrameworkCore;

namespace SchoolSystem.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using SchoolSystem.Application.Entities;

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<ScheduleEntity> Schedules { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
    }
}