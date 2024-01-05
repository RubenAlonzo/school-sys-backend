namespace SchoolSystem.Persistence.Repositories
{
    using SchoolSystem.Domain.Entities;
    using SchoolSystem.Persistence.Repositories.Contracts;

    internal class TeacherRepository : GenericRepository<TeacherEntity>, ITeacherRepository
    {
        public TeacherRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
