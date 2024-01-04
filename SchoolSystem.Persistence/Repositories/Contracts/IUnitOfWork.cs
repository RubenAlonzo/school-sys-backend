namespace SchoolSystem.Persistence.Repositories.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        public IRoomRepository Rooms { get; }

        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
