namespace SchoolSystem.Persistence.Repositories
{
    using SchoolSystem.Domain.Entities;
    using SchoolSystem.Persistence.Extensions;
    using SchoolSystem.Persistence.Repositories.Contracts;
    using System.Linq.Expressions;

    internal class TeacherRepository : GenericRepository<TeacherEntity>, ITeacherRepository
    {
        public TeacherRepository(ApplicationContext context) : base(context)
        {
        }

        public override IQueryable<TeacherEntity> GetAll()
        {
            return _context.Set<TeacherEntity>()
                .IncludeMultiple(x => x.User!);
        }

        public override IQueryable<TeacherEntity> Find(Expression<Func<TeacherEntity, bool>> expression)
        {
            return _context.Set<TeacherEntity>()
                .IncludeMultiple(x => x.User!)
                .Where(expression);
        }

        public override TeacherEntity? FirstOrDefault(Func<TeacherEntity, bool> predicate)
        {
            return _context.Set<TeacherEntity>()
                .IncludeMultiple(x => x.User!)
                .FirstOrDefault(predicate);
        }
    }
}
