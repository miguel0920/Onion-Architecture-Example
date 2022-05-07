using FluentValidation;

namespace Application.Features.Customer.Commands.UpdateCustomerCommand
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");

            RuleFor(p => p.BirthdayDate)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");

            RuleFor(p => p.Phone)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .Matches(@"^\d{10,10}$").WithMessage("{PropertyName} debe cumplir el formato 0000000000")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .EmailAddress().WithMessage("{PropertyName} debe ser una dirección de email valida.")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(80).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");
        }
    }
}