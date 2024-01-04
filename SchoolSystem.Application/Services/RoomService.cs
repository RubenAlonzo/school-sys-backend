namespace SchoolSystem.Application.Services
{
    using SchoolSystem.Application.Services.Contracts;
    using SchoolSystem.Domain.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RoomService : IRoomService
    {
        private List<RoomEntity> _rooms = new List<RoomEntity>();
        private int _index = 1;
        public Task CreateAsync(RoomEntity room)
        {
            room.Id = _index++; 
            _rooms.Add(room);
            return Task.CompletedTask;
        }

        public Task<bool> DeleteAsync(int id)
        {
            var room = _rooms.FirstOrDefault(x => x.Id == id);
            if (room == null) return Task.FromResult(false);
            _rooms.Remove(room);
            return Task.FromResult(true);
        }

        public Task<RoomEntity?> GetByIdAsync(int id)
        {
            return Task.FromResult(_rooms.FirstOrDefault(x => x.Id == id));
        }

        public Task<RoomEntity?> GetByNameAsync(string name)
        {
            return Task.FromResult(_rooms.FirstOrDefault(x => x.Name == name));
        }

        public Task<IEnumerable<RoomEntity>> GetAsync()
        {
            return Task.FromResult(_rooms.AsEnumerable());
        }

        public Task<RoomEntity?> UpdateAsync(RoomEntity room)
        {
            var currentRoom = _rooms.FirstOrDefault(x => x.Id == room.Id);
            if (currentRoom is null) return Task.FromResult<RoomEntity?>(default);
            _rooms.Remove(currentRoom);
            _rooms.Add(room);
            return Task.FromResult<RoomEntity?>(room);
        }
    }
}
