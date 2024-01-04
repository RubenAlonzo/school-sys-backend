namespace SchoolSystem.Application.Services
{
    using SchoolSystem.Application.Services.Contracts;
    using SchoolSystem.Domain.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal class ScheduleService : IScheduleService
    {
        private readonly List<ScheduleEntity> _schedules = new();
        private int _index = 1;

        public Task CreateAsync(ScheduleEntity schedule)
        {
            schedule.Id = _index++;
            _schedules.Add(schedule);
            return Task.CompletedTask;
        }

        public Task<bool> DeleteAsync(int id)
        {
            var schedule = _schedules.FirstOrDefault(x => x.Id == id);
            if (schedule is null) return Task.FromResult(false);
            _schedules.Remove(schedule);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<ScheduleEntity>> GetAsync()
        {
            return Task.FromResult(_schedules.AsEnumerable());
        }

        public Task<ScheduleEntity?> GetByIdAsync(int id)
        {
            var schedule = _schedules.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(schedule);
        }

        public Task<ScheduleEntity?> UpdateAsync(ScheduleEntity schedule)
        {
            var currentSchedule = _schedules.FirstOrDefault(x => x.Id == schedule.Id);
            if (currentSchedule is null) return Task.FromResult<ScheduleEntity?>(null);
            _schedules.Remove(currentSchedule);
            _schedules.Add(schedule);
            return Task.FromResult<ScheduleEntity?>(schedule);
        }
    }
}
