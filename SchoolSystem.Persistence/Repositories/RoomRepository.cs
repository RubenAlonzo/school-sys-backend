namespace SchoolSystem.Persistence.Repositories
{
    using SchoolSystem.Domain.Entities;
    using SchoolSystem.Persistence.Options;
    using SchoolSystem.Persistence.Repositories.Contracts;

    internal class RoomRepository : GenericRepository<RoomEntity>, IRoomRepository
    {
        public RoomRepository(ApplicationContext context) : base(context)
        {
        }

        IQueryable<RoomEntity> IRoomRepository.GetAll(GetAllRoomsOption options)
        {
            var rooms = _context.Set<RoomEntity>().AsQueryable();

            rooms = options.Capacity.HasValue ? rooms.Where(x => x.Capacity >= options.Capacity) : rooms;
            rooms = !string.IsNullOrEmpty(options.Location) ? rooms.Where(x => x.Location.Contains(options.Location)) : rooms;

            return rooms;
        }
    }
}
