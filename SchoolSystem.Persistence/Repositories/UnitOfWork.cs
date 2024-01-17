namespace SchoolSystem.Persistence.Repositories
{
    using SchoolSystem.Persistence.Repositories.Contracts;
    using System.Threading.Tasks;

    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public IRoomRepository Rooms { get; }
        public IScheduleRepository Schedules { get; }
        public IStudentRepository Students { get; }
        public ITeacherRepository Teachers { get; }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Rooms = new RoomRepository(context);
            Schedules = new ScheduleRepository(context);
            Students = new StudentRepository(context);
            Teachers = new TeacherRepository(context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }
    }
}
