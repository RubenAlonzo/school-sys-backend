namespace SchoolSystem.Application.Services.Contracts
{
    using SchoolSystem.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRoomService
    {
        Task CreateAsync(RoomEntity room);
        Task<bool> DeleteAsync(int id);
        RoomEntity? GetById(int id);
        RoomEntity? GetByName(string name);
        IEnumerable<RoomEntity> GetAll();
        Task<RoomEntity?> UpdateAsync(RoomEntity room);
    }
}
