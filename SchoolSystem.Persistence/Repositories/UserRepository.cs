namespace SchoolSystem.Persistence.Repositories
{
    using SchoolSystem.Domain.Entities;
    using SchoolSystem.Persistence.Repositories.Contracts;

    internal class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
