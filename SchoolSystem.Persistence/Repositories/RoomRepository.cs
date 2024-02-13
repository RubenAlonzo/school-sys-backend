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

            if (options.SortField != null)
            {
                rooms = options.SortOrder switch
                {
                    SortOrder.Ascending when options.SortField == "location" => rooms.OrderBy(x => x.Location),
                    SortOrder.Descending when options.SortField == "location" => rooms.OrderByDescending(x => x.Location),
                    SortOrder.Ascending when options.SortField == "capacity" => rooms.OrderBy(x => x.Capacity),
                    SortOrder.Descending when options.SortField == "capacity" => rooms.OrderByDescending(x => x.Capacity),
                    _ => rooms,
                };
            }

            return rooms;
        }
    }
}
