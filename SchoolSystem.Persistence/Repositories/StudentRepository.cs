namespace SchoolSystem.Persistence.Repositories
{
    using SchoolSystem.Domain.Entities;
    using SchoolSystem.Persistence.Repositories.Contracts;

    internal class StudentRepository : GenericRepository<StudentEntity>, IStudentRepository
    {
        public StudentRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
