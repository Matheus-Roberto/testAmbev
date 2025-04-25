using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateUserRequest that defines validation rules for user creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(x => x.SaleNumber)
            .NotEmpty().WithMessage("Sale number is required")
            .Length(6, 20).WithMessage("Sale number must be between 6 and 20 characters")
            .Matches(@"^[A-Z0-9-]+$").WithMessage("Sale number must contain only uppercase letters, numbers, and hyphens");

        RuleFor(x => x.Customer)
            .NotEmpty().WithMessage("Customer name is required")
            .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters");

        RuleFor(x => x.Branch)
            .NotEmpty().WithMessage("Branch is required")
            .MaximumLength(50).WithMessage("Branch name cannot exceed 50 characters");

        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("At least one sale item is required")
            .Must(items => items.Count <= 20).WithMessage("Cannot add more than 20 items to a single sale");


        RuleForEach(x => x.Items).SetValidator(new CreateSaleItemRequestValidator());
    }
}
