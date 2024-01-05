namespace SchoolSystem.Persistence.Repositories
{
    using SchoolSystem.Persistence.Repositories.Contracts;
    using System.Threading.Tasks;

    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public IRoomRepository Rooms { get; }
        public IScheduleRepository Schedules { get; }

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Rooms = new RoomRepository(context);
            Schedules = new ScheduleRepository(context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
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
