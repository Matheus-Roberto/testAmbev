using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{/// <summary>
 /// Command for creating a new sale.
 /// </summary>
 /// <remarks>
 /// This command is used to capture the required data for creating a sale,
 /// including sale number, customer information, branch, and items.
 /// It implements <see cref="IRequest{TResponse}"/> to initiate the request
 /// that returns a <see cref="CreateSaleResult"/>.
 /// 
 /// The data provided in this command is validated using the
 /// <see cref="CreateSaleCommandValidator"/> which extends
 /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly
 /// populated and follow the required business rules.
 /// </remarks>
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        /// <summary>
        /// Gets or sets the unique sale number.
        /// </summary>
        /// <remarks>
        /// Must follow the format [A-Z0-9-]{6,20}
        /// </remarks>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        /// <remarks>
        /// Must be between 1 and 100 characters
        /// </remarks>
        public string Customer { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the branch name.
        /// </summary>
        /// <remarks>
        /// Must be between 1 and 50 characters
        /// </remarks>
        public string Branch { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of sale items.
        /// </summary>
        /// <remarks>
        /// Must contain at least one item and no more than 20 items
        /// </remarks>
        public List<CreateSaleItemCommand> Items { get; set; } = new List<CreateSaleItemCommand>();

        /// <summary>
        /// Gets or sets the initial status of the sale.
        /// </summary>
        /// <remarks>
        /// Defaults to Active
        /// </remarks>
        public SaleStatus Status { get; set; } = SaleStatus.Active;

        /// <summary>
        /// Validates the command using the CreateSaleCommandValidator.
        /// </summary>
        /// <returns>A ValidationResultDetail containing validation results.</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new CreateSaleCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
            };
        }
    }
}
