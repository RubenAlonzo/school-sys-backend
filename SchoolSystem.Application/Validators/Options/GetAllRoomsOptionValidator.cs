namespace SchoolSystem.Application.Validators.Options
{
    using FluentValidation;
    using SchoolSystem.Persistence.Options;

    public class GetAllRoomsOptionValidator : AbstractValidator<GetAllRoomsOption>
    {
        public static readonly string[] AcceptableSortFields = { "location", "capacity" };
        public GetAllRoomsOptionValidator()
        {
            RuleFor(x => x.Capacity)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.SortField)
                .Must(x => x is null || AcceptableSortFields.Contains(x))
                .WithMessage("You can only sort by 'location' and 'capacity'");
        }
    }
}
