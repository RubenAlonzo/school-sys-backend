namespace SchoolSystem.Application.Services
{
    using SchoolSystem.Application.Entities;
    using SchoolSystem.Application.Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RoomService : IRoomService
    {
        private List<RoomEntity> _rooms = new List<RoomEntity>();
        private int _index = 1;
        public Task CreateRoomAsync(RoomEntity room)
        {
            room.Id = _index++; 
            _rooms.Add(room);
            return Task.CompletedTask;
        }

        public Task<bool> DeleteRoomAsync(int id)
        {
            var room = _rooms.FirstOrDefault(x => x.Id == id);
            if (room == null) return Task.FromResult(false);
            _rooms.Remove(room);
            return Task.FromResult(true);
        }

        public Task<RoomEntity?> GetRoomAsync(int id)
        {
            return Task.FromResult(_rooms.FirstOrDefault(x => x.Id == id));
        }

        public Task<IEnumerable<RoomEntity>> GetRoomsAsync()
        {
            return Task.FromResult(_rooms.AsEnumerable());
        }

        public Task<RoomEntity?> UpdateRoomAsync(RoomEntity room)
        {
            var currentRoom = _rooms.FirstOrDefault(x => x.Id == room.Id);
            if (currentRoom is null) return Task.FromResult<RoomEntity?>(default);
            _rooms.Remove(currentRoom);
            _rooms.Add(room);
            return Task.FromResult<RoomEntity?>(room);
        }
    }
}
