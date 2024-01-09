namespace SchoolSystem.Application.Validators
{
    using FluentValidation;
    using SchoolSystem.Domain.Entities;
    using System;

    public class StudentValidator : AbstractValidator<StudentEntity>
    {
        public StudentValidator()
        {
            RuleFor(x => x.Birthday)
                .LessThan(DateTime.UtcNow.AddYears(-2))
                .WithMessage("Date must be at least 2 years old");

            RuleFor(x => x.Email)
                .EmailAddress();

            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();

            RuleFor(x => x.Address)
                .NotEmpty();
        }
    }
}
