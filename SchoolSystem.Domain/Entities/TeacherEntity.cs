namespace SchoolSystem.Domain.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class TeacherEntity
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }
        public required string Subject { get; set; }
        public ICollection<ScheduleEntity>? Schedule { get; set; }
        public string? Expertise { get; set; }
        public int UserId { get; set; }
        public UserEntity? User { get; set; }
    }
}
