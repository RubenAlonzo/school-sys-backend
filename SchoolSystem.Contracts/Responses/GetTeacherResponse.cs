namespace SchoolSystem.Contracts.Responses
{
    public class GetTeacherResponse
    {
        public required int Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Address { get; init; }
        public required string Subject { get; init; }
        public string? Expertise { get; init; }
    }
}
