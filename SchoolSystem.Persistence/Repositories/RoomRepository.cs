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

        public int Count(GetAllRoomsOption options)
        {
            var rooms = ApplyFilters(options);
            return rooms.Count();
        }

        public IQueryable<RoomEntity> GetAll(GetAllRoomsOption options)
        {
            var rooms = ApplyFilters(options);
            rooms = ApplySorting(rooms, options);
            rooms = rooms
                .Skip((options.Page - 1) * options.PageSize)
                .Take(options.PageSize);

            return rooms;
        }

        private IQueryable<RoomEntity> ApplyFilters(GetAllRoomsOption options)
        {
            var rooms = _context.Set<RoomEntity>().AsQueryable();

            rooms = options.Capacity.HasValue ? rooms.Where(x => x.Capacity >= options.Capacity) : rooms;
            rooms = !string.IsNullOrEmpty(options.Location) ? rooms.Where(x => x.Location.ToLower().Contains(options.Location.ToLower())) : rooms;

            return rooms;
        }

        private IQueryable<RoomEntity> ApplySorting(IQueryable<RoomEntity> rooms, GetAllRoomsOption options)
        {
            if (options.SortField != null)
            {
                return options.SortOrder switch
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
