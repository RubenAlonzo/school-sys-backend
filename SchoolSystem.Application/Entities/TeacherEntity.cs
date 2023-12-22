namespace SchoolSystem.Application.Entities
{
    public class TeacherEntity
    {
        public int Id { get; init; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string Subject { get; init; }
        public string? Expertise { get; init; }
    }
}
