namespace SchoolSystem.Application.Validators
{
    using FluentValidation;
    using SchoolSystem.Domain.Entities;

    public class RoomValidator : AbstractValidator<RoomEntity>
    {
        public RoomValidator()
        {
            RuleFor(x => x.Capacity)
                .GreaterThanOrEqualTo(0);
        }
    }
}
