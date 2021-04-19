using FluentValidation;
using Pheonix.Domain.Entities;

namespace Pheonix.Service.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome deve ser preenchido")
                .NotNull().WithMessage("Por favor, preencha o nome");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O e-mail deve ser preenchido")
                .NotNull().WithMessage("Por favor, preencha o e-mail");
        }
    }
}
