namespace SchoolSystem.Persistence.Repositories
{
    using SchoolSystem.Domain.Entities;
    using SchoolSystem.Persistence.Extensions;
    using SchoolSystem.Persistence.Repositories.Contracts;
    using System.Linq.Expressions;

    internal class StudentRepository : GenericRepository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(ApplicationContext context) : base(context)
        {
        }

        public override IQueryable<StudentEntity> GetAll()
        {
            return _context.Set<StudentEntity>()
                .IncludeMultiple(x => x.User!);
        }

        public override IQueryable<StudentEntity> Where(Expression<Func<StudentEntity, bool>> expression)
        {
            return _context.Set<StudentEntity>()
                .IncludeMultiple(x => x.User!)
                .Where(expression);
        }

        public override StudentEntity? FirstOrDefault(Func<StudentEntity, bool> predicate)
        {
            return _context.Set<StudentEntity>()
                .IncludeMultiple(x => x.User!)
                .FirstOrDefault(predicate);
        }
    }
}
