namespace SchoolSystem.Application.Services.Contracts
{
    using SchoolSystem.Application.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IScheduleService
    {
        Task CreateAsync(ScheduleEntity schedule);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ScheduleEntity>> GetAsync();
        Task<ScheduleEntity?> GetByIdAsync(int id);
        Task<ScheduleEntity?> UpdateAsync(ScheduleEntity schedule);
    }
}
