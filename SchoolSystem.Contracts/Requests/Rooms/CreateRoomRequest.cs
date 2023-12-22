namespace SchoolSystem.Contracts.Requests.Rooms
{
    public class CreateRoomRequest
    {
        public required int Capacity { get; init; }
        public required string Location { get; init; }
    }
}
