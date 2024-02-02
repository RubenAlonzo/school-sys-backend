namespace SchoolSystem.Application.Services.Contracts
{
    using SchoolSystem.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IScheduleService
    {
        Task CreateAsync(ScheduleEntity schedule, CancellationToken cancellationToken = default);
        Task CreateAsync(ScheduleEntity schedule, IEnumerable<int> studentIds, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
        IEnumerable<ScheduleEntity> GetAll();
        ScheduleEntity? GetById(int id);
        Task<ScheduleEntity?> UpdateAsync(ScheduleEntity schedule, CancellationToken cancellationToken = default);
        Task<ScheduleEntity?> UpdateAsync(ScheduleEntity schedule, IEnumerable<int> studentIds, CancellationToken cancellationToken = default);
    }
}
