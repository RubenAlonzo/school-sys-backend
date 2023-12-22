namespace SchoolSystem.Contracts.Responses
{
    using System;

    public class GetStudentResponse
    {
        public required int Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }
        public required string Address { get; init; }
        public required string RegistrationNumber { get; init; }
        public required DateTime Birthday { get; init; }
        public string? FatherName { get; init; }
        public string? MotherName { get; init; }
    }
}
