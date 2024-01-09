namespace SchoolSystem.Api.Middlewares
{
    using FluentValidation;
    using SchoolSystem.Contracts.Responses;

    public class ValidationExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = 400;
                var validationFailureResponse = new ValidationFailureResponse
                {
                    Errors = ex.Errors.Select(x => new ValidationFailure
                    {
                        PropertyName = x.PropertyName,
                        Message = x.ErrorMessage,
                    })
                };

                await context.Response.WriteAsJsonAsync(validationFailureResponse);
            }
        }
    }
}
