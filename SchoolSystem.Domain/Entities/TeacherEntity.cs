namespace SchoolSystem.Domain.Entities
{
    public class TeacherEntity
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string Subject { get; set; }
        public IEnumerable<ScheduleEntity>? Schedule { get; set; }
        public string? Expertise { get; set; }
    }
}
