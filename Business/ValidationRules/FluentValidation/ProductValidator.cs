using System.Text.RegularExpressions;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.CategoryId).NotEmpty().GreaterThan(0);
            RuleFor(p => p.ProductName).NotEmpty().NotNull().MinimumLength(2);
            RuleFor(p => p.ProductName).Matches(new Regex(@"^[A-Za-z]+\s{0,2}[A-Za-z]+$"))
                .WithMessage("Product Name must be start and end with letter.Can inlude up to 2 spaces");
            RuleFor(p => p.UnitPrice).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 1);
        }
    }
}