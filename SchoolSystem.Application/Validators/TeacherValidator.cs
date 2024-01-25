namespace SchoolSystem.Application.Validators
{
    using FluentValidation;
    using SchoolSystem.Domain.Entities;

    public class TeacherValidator : AbstractValidator<TeacherEntity>
    {
        public TeacherValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName)
                .NotEmpty();

            RuleFor(x => x.Address)
                .NotEmpty();
        }
    }
}
