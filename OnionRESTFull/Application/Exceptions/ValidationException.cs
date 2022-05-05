using Application.Wrappers;
using FluentValidation.Results;

namespace Application.Exceptions
{
    public class ValidationException : Exception
    {
        public Response<string> Errors { get; }

        public ValidationException() : base("Se ha producido uno o más errores de validación.")
        {
            Errors = new Response<string>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : base("Se ha producido uno o más errores de validación.")
        {
            Errors = new Response<string>();
            List<string> messages = new();
            foreach (var failure in failures)
            {
                messages.Add(failure.ErrorMessage);
            }
            Errors.Errors = messages;
            Errors.Succeeded = false;
        }
    }
}