namespace SchoolSystem.Application.Validators
{
    using FluentValidation;
    using SchoolSystem.Domain.Entities;
    using SchoolSystem.Persistence.Repositories.Contracts;
    using System;

    public class ScheduleValidator : AbstractValidator<ScheduleEntity>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScheduleValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.StartTime)
                .NotEmpty()
                .GreaterThanOrEqualTo(new TimeOnly(8, 0));

            RuleFor(x => x.FinishTime)
                .NotEmpty()
                .LessThanOrEqualTo(new TimeOnly(15, 0));

            RuleFor(x => x)
                .Must(x => x.FinishTime > x.StartTime)
                .WithMessage("Finish time must be greater than start time");

            RuleFor(x => x.Day)
                .NotEmpty()
                .Must(ValidateDay)
                .WithMessage("Day must be a week day");

            RuleFor(x => x)
                .Must(ValidateNoOverlap)
                .WithMessage("There's an overlap with this schedule");

            RuleFor(x => x)
                .Must(ValidateRoomExists)
                .WithMessage("The room is not valid");

            RuleFor(x => x)
                .Must(ValidateTeacherExists)
                .WithMessage("The teacher is not valid");
        }

        private bool ValidateRoomExists(ScheduleEntity entity)
        {
            var room = _unitOfWork.Rooms.FirstOrDefault(x => x.Id == entity.RoomId);
            if (room == null) return false;

            entity.Room = room;
            return true;
        }
        
        private bool ValidateTeacherExists(ScheduleEntity entity)
        {
            var teacher = _unitOfWork.Teachers.FirstOrDefault(x => x.Id == entity.TeacherId);
            if (teacher == null) return false;

            entity.Teacher = teacher;
            return true;
        }

        private bool ValidateNoOverlap(ScheduleEntity entity)
        {
            var schedules = _unitOfWork.Schedules.Where(x => x.RoomId == entity.RoomId && x.Day == entity.Day);
            if (!schedules.Any()) return true;

            foreach (var schedule in schedules)
            {
                var isTimeOverlapped = (schedule.StartTime < entity.FinishTime && entity.StartTime < schedule.FinishTime) && schedule.Id != entity.Id;
                if(isTimeOverlapped) return false;
            }

            return true;
        }

        private bool ValidateDay(DayOfWeek day)
        {
            var validDays = new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
            return validDays.Contains(day);
        }
    }
}
