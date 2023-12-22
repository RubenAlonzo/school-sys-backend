namespace SchoolSystem.Application.Services.Contracts
{
    using SchoolSystem.Application.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRoomService
    {
        Task CreateRoomAsync(RoomEntity room);
        Task<bool> DeleteRoomAsync(int id);
        Task<RoomEntity?> GetRoomAsync(int id);
        Task<IEnumerable<RoomEntity>> GetRoomsAsync();
        Task<RoomEntity?> UpdateRoomAsync(RoomEntity room);
    }
}
