namespace SchoolSystem.Persistence
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SchoolSystem.Domain.Entities;

    public class ApplicationContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
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