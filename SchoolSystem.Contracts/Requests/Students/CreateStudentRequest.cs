namespace SchoolSystem.Contracts.Requests.Students
{
    using System;

    public class CreateStudentRequest
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }
        public required string Address { get; init; }
        public required DateTime Birthday { get; init; }
        public string? FatherName { get; init; }
        public string? MotherName { get; init; }
    }
}
