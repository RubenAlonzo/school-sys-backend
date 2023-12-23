namespace SchoolSystem.Application.Services.Contracts
{
    using SchoolSystem.Application.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRoomService
    {
        Task CreateAsync(RoomEntity room);
        Task<bool> DeleteAsync(int id);
        Task<RoomEntity?> GetByIdAsync(int id);
        Task<IEnumerable<RoomEntity>> GetAsync();
        Task<RoomEntity?> UpdateAsync(RoomEntity room);
    }
}
