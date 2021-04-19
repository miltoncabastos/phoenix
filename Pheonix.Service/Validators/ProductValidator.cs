using FluentValidation;
using Pheonix.Domain.Entities;

namespace Pheonix.Service.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("A descrição deve ser preenchido")
                .NotNull().WithMessage("Por favor, preencha a descrição");
        }
    }
}
