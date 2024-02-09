namespace SchoolSystem.Application.Validators.Options
{
    using FluentValidation;
    using SchoolSystem.Persistence.Options;

    public class GetAllRoomsOptionValidator : AbstractValidator<GetAllRoomsOption>
    {
        public GetAllRoomsOptionValidator()
        {
            RuleFor(x => x.Capacity)
                .GreaterThanOrEqualTo(0);
        }
    }
}
