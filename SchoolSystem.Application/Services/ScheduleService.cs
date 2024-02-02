namespace SchoolSystem.Application.Services
{
    using FluentValidation;
    using SchoolSystem.Application.Services.Contracts;
    using SchoolSystem.Domain.Entities;
    using SchoolSystem.Persistence.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class ScheduleService : IScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<ScheduleEntity> _validator;

        public ScheduleService(IUnitOfWork unitOfWork, IValidator<ScheduleEntity> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task CreateAsync(ScheduleEntity schedule, CancellationToken cancellationToken = default)
        {
            _validator.ValidateAndThrow(schedule);
            _unitOfWork.Schedules.Add(schedule);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        public async Task CreateAsync(ScheduleEntity schedule, IEnumerable<int> studentIds, CancellationToken cancellationToken = default)
        {
            _validator.ValidateAndThrow(schedule);
            var students = _unitOfWork.Students.Where(x => studentIds.Contains(x.Id));
            schedule.Students = students.ToList();
            _unitOfWork.Schedules.Add(schedule);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var schedule = _unitOfWork.Schedules.FirstOrDefault(x => x.Id == id);
            if (schedule is null) return false;
            _unitOfWork.Schedules.Remove(schedule);
            return (await _unitOfWork.SaveChangesAsync(cancellationToken)) > 0;
        }

        public IEnumerable<ScheduleEntity> GetAll()
        {
            return _unitOfWork.Schedules.GetAll();
        }

        public ScheduleEntity? GetById(int id)
        {
            var schedule = _unitOfWork.Schedules.FirstOrDefault(x => x.Id == id);
            return schedule;
        }

        public async Task<ScheduleEntity?> UpdateAsync(ScheduleEntity schedule, CancellationToken cancellationToken = default)
        {
            _validator.ValidateAndThrow(schedule);
            var currentSchedule = _unitOfWork.Schedules.FirstOrDefault(x => x.Id == schedule.Id);
            if (currentSchedule is null) return null;
            _unitOfWork.Schedules.Remove(currentSchedule);
            _unitOfWork.Schedules.Add(schedule);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return schedule;
        }

        public async Task<ScheduleEntity?> UpdateAsync(ScheduleEntity schedule, IEnumerable<int> studentIds, CancellationToken cancellationToken = default)
        {
            _validator.ValidateAndThrow(schedule);
            var currentSchedule = _unitOfWork.Schedules.FirstOrDefault(x => x.Id == schedule.Id);
            if (currentSchedule is null) return null;
            var students = _unitOfWork.Students.Where(x => studentIds.Contains(x.Id));
            schedule.Students = students.ToList(); 
            currentSchedule = schedule; // If changes schedule students doesnt exists, removes current students. Might be ok
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return schedule;
        }
    }
}
