namespace SchoolSystem.Persistence.Repositories
{
    using SchoolSystem.Domain.Entities;
    using SchoolSystem.Persistence.Extensions;
    using SchoolSystem.Persistence.Repositories.Contracts;
    using System.Linq.Expressions;

    internal class ScheduleRepository : GenericRepository<ScheduleEntity>, IScheduleRepository
    {
        public ScheduleRepository(ApplicationContext context) : base(context)
        {
        }

        public override IQueryable<ScheduleEntity> GetAll()
        {
            return _context.Set<ScheduleEntity>()
                .IncludeMultiple(x => x.Students!);
        }

        public override IQueryable<ScheduleEntity> Where(Expression<Func<ScheduleEntity, bool>> expression)
        {
            return _context.Set<ScheduleEntity>()
                .IncludeMultiple(x => x.Students!)
                .Where(expression);
        }

        public override ScheduleEntity? FirstOrDefault(Func<ScheduleEntity, bool> predicate)
        {
            return _context.Set<ScheduleEntity>()
                .IncludeMultiple(x => x.Students!)
                .FirstOrDefault(predicate);
        }
    }
}
