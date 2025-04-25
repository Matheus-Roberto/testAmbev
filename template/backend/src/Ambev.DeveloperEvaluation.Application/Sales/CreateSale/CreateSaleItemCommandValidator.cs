using FluentValidation;


namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleItemCommandValidator : AbstractValidator<CreateSaleItemCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleItemCommandValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - ProductName: Required, max 100 characters
        /// - Quantity: Must be between 1-20
        /// - UnitPrice: Must be greater than 0
        /// </remarks>
        public CreateSaleItemCommandValidator()
        {
            RuleFor(item => item.ProductName)
                .NotEmpty().WithMessage("Product name is required")
                .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters");

            RuleFor(item => item.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0")
                .LessThanOrEqualTo(20).WithMessage("Maximum quantity per item is 20");

            RuleFor(item => item.UnitPrice)
                .GreaterThan(0).WithMessage("Unit price must be greater than 0");
        }
    }
}
