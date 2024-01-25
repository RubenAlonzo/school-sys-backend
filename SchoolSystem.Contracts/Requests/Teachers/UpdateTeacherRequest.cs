namespace SchoolSystem.Contracts.Requests.Teachers
{
    public class UpdateTeacherRequest
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Address { get; init; }
        public required string Subject { get; init; }
        public string? Expertise { get; init; }
    }
}
