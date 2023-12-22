namespace SchoolSystem.Application.Entities
{
    using System;

    public class StudentEntity
    {
        public int Id { get; init; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public string RegistrationNumber => $"MAT-{DateTime.Now.Year}-{Id}";
        public required DateTime Birthday { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
    }
}
