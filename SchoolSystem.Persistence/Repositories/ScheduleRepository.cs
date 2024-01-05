namespace SchoolSystem.Persistence.Repositories
{
    using SchoolSystem.Domain.Entities;
    using SchoolSystem.Persistence.Repositories.Contracts;

    internal class ScheduleRepository : GenericRepository<ScheduleEntity>, IScheduleRepository
    {
        public ScheduleRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
