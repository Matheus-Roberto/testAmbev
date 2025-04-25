using FluentValidation;


namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - SaleNumber: Required, must be 6-20 characters, alphanumeric with hyphens
        /// - Customer: Required, max 100 characters
        /// - Branch: Required, max 50 characters
        /// - Items: Must contain at least one item, max 20 items
        /// - Status: Must be a valid SaleStatus (not Unknown if enum exists)
        /// - Each Item:
        ///   - ProductName: Required, max 100 characters
        ///   - Quantity: Must be 1-20
        ///   - UnitPrice: Must be greater than 0
        /// </remarks>
        public CreateSaleCommandValidator()
        {
            RuleFor(sale => sale.SaleNumber)
                .NotEmpty().WithMessage("Sale number is required")
                .Length(6, 20).WithMessage("Sale number must be between 6 and 20 characters")
                .Matches(@"^[A-Z0-9-]+$").WithMessage("Sale number must contain only uppercase letters, numbers, and hyphens");

            RuleFor(sale => sale.Customer)
                .NotEmpty().WithMessage("Customer is required")
                .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters");

            RuleFor(sale => sale.Branch)
                .NotEmpty().WithMessage("Branch is required")
                .MaximumLength(50).WithMessage("Branch name cannot exceed 50 characters");

            RuleFor(sale => sale.Items)
                .NotEmpty().WithMessage("At least one sale item is required")
                .Must(items => items.Count <= 20).WithMessage("Cannot add more than 20 items to a single sale");

            // If you have an Unknown status in your SaleStatus enum
            // RuleFor(sale => sale.Status).NotEqual(SaleStatus.Unknown);

            RuleForEach(sale => sale.Items).SetValidator(new CreateSaleItemCommandValidator());
        }
    }
}
