namespace SchoolSystem.Persistence.Repositories.Contracts
{
    using System;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        public IRoomRepository Rooms { get; }
        public IScheduleRepository Schedules { get; }
        public IStudentRepository Students { get; }

        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
