namespace SchoolSystem.Application.Entities
{
    public class RoomEntity
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public required string Location { get; set; }
        public string Name => $"xyz-{Id}";
    }
}
