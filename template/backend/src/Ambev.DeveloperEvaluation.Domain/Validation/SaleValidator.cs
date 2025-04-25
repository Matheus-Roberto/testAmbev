using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.SaleNumber)
            .NotEmpty().WithMessage("Sale number is required")
            .Length(6, 20).WithMessage("Sale number must be between 6 and 20 characters")
            .Matches(@"^[A-Z0-9-]+$").WithMessage("Sale number can only contain uppercase letters, numbers, and hyphens");

        RuleFor(sale => sale.Customer)
            .NotEmpty().WithMessage("Customer is required")
            .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters");

        RuleFor(sale => sale.Branch)
            .NotEmpty().WithMessage("Branch is required")
            .MaximumLength(50).WithMessage("Branch name cannot exceed 50 characters");

        RuleFor(sale => sale.Status)
            .IsInEnum().WithMessage("Invalid sale status");

        RuleFor(sale => sale.Items)
            .NotEmpty().WithMessage("Sale must contain at least one item")
            .Must(items => items.Count <= 20).WithMessage("Cannot add more than 20 items to a single sale")
            .ForEach(item => item.SetValidator(new SaleItemValidator()));

        RuleFor(sale => sale.TotalAmount)
            .GreaterThan(0).WithMessage("Total amount must be greater than zero")
            .Must((sale, total) => Math.Abs(total - sale.Items.Sum(i => i.TotalWithDiscount)) < 0.01m)
            .WithMessage("Total amount does not match the sum of items");

        When(sale => sale.Status == SaleStatus.Cancelled, () =>
        {
            RuleFor(sale => sale.Items)
                .Must(items => items.Count == 0)
                .WithMessage("Cannot have items in a cancelled sale");
        });
    }
}