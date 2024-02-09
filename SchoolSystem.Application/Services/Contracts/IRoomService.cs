namespace SchoolSystem.Application.Services.Contracts
{
    using SchoolSystem.Persistence.Options;
    using SchoolSystem.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRoomService
    {
        Task CreateAsync(RoomEntity room, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
        RoomEntity? GetById(int id);
        RoomEntity? GetByName(string name);
        IEnumerable<RoomEntity> GetAll(GetAllRoomsOption options);
        Task<RoomEntity?> UpdateAsync(RoomEntity room, CancellationToken cancellationToken = default);
    }
}
