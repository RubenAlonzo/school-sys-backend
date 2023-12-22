namespace SchoolSystem.Contracts.Requests.Rooms
{
    public class UpdateRoomRequest
    {
        public required int Capacity { get; init; }
        public required string Location { get; init; }
    }
}
