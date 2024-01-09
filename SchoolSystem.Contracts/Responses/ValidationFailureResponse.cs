namespace SchoolSystem.Contracts.Responses
{
    using System.Collections.Generic;

    public class ValidationFailureResponse
    {
        public required IEnumerable<ValidationFailure> Errors { get; set; }
    }

    public class ValidationFailure
    {
        public required string PropertyName { get; set; }
        public required string Message { get; set; }
    }
}
