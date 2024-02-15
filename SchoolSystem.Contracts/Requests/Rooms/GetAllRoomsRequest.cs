namespace SchoolSystem.Contracts.Requests.Rooms
{
    public class GetAllRoomsRequest : PagedRequest
    {
        public required int? Capacity { get; init; }
        public required string? Location { get; init; }
        public required string? SortBy { get; init; }
    }

}
