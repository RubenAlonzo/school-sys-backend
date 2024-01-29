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
            
            RuleFor(x => x.User)
                .NotNull();

            RuleFor(x => x.User!.Email)
                .EmailAddress();
        }
    }
}
