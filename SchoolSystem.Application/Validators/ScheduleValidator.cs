namespace SchoolSystem.Application.Validators
{
    using FluentValidation;
    using SchoolSystem.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ScheduleValidator : AbstractValidator<ScheduleEntity>
    {
        public ScheduleValidator()
        {
            RuleFor(x => x.StartTime)
                .NotEmpty();

            RuleFor(x => x)
                .Must(x => x.FinishTime > x.StartTime)
                .WithMessage("Finish time must be greater than start time");
        }
    }
}
