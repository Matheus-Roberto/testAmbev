using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;


public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(item => item.ProductName)
            .NotEmpty().WithMessage("Product name is required")
            .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters");

        RuleFor(item => item.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero")
            .LessThanOrEqualTo(20).WithMessage("Cannot order more than 20 units of a single product");

        RuleFor(item => item.UnitPrice)
            .GreaterThan(0).WithMessage("Unit price must be greater than zero");

        RuleFor(item => item.TotalWithDiscount)
            .GreaterThan(0).WithMessage("Total with discount must be greater than zero")
            .Must((item, total) =>
            {
                var expectedTotal = item.Quantity * item.UnitPrice * (1 - item.Discount);
                return Math.Abs(total - expectedTotal) < 0.01m;
            })
            .WithMessage("Calculated total with discount is incorrect");
    }
}