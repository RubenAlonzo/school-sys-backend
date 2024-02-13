namespace SchoolSystem.Persistence.Options
{
    using System.Globalization;

    public class GetAllRoomsOption
    {
        public required int? Capacity { get; init; }
        public required string? Location { get; init; }
        public required string? SortField { get; init; }
        public required SortOrder? SortOrder { get; init; }
    }

    public enum SortOrder
    {
        UnSorted,
        Ascending,
        Descending,
    }
}
