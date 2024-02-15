namespace SchoolSystem.Persistence.Repositories.Contracts
{
    using SchoolSystem.Domain.Entities;
    using SchoolSystem.Persistence.Options;

    public interface IRoomRepository : IGenericRepository<RoomEntity>
    {
        IQueryable<RoomEntity> GetAll(GetAllRoomsOption options);
        int Count(GetAllRoomsOption options);
    }
}
