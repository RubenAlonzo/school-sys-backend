namespace SchoolSystem.Application.Services.Contracts
{
    using SchoolSystem.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IScheduleService
    {
        Task CreateAsync(ScheduleEntity schedule);
        Task<bool> DeleteAsync(int id);
        IEnumerable<ScheduleEntity> GetAll();
        ScheduleEntity? GetById(int id);
        Task<ScheduleEntity?> UpdateAsync(ScheduleEntity schedule);
    }
}
