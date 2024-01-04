namespace SchoolSystem.Persistence.Repositories
{
    using SchoolSystem.Application.Entities;
    using SchoolSystem.Persistence.Repositories.Contracts;

    internal class RoomRepository : GenericRepository<RoomEntity>, IRoomRepository
    {
        public RoomRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
