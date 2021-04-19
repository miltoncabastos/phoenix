using FluentValidation;
using Pheonix.Domain.Entities;

namespace Pheonix.Service.Validators
{
    public class StockValidator : AbstractValidator<Stock>
    {
        public StockValidator()
        {
            RuleFor(p => p.ClientId)                
                .GreaterThan(0).WithMessage("ClienteId deve ser informado");

            RuleFor(p => p.ProductId)
                .GreaterThan(0).WithMessage("ProductId deve ser informado");
        }
    }
}
