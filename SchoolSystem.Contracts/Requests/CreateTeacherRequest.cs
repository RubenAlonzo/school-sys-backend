namespace SchoolSystem.Contracts.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreateTeacherRequest
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }
        public required string Address { get; init; }
        public required string Subject { get; init; }
        public string? Expertise { get; init; }
    }
}
