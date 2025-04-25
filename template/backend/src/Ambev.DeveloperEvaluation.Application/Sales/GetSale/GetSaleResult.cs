
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public record GetSaleResult
    {
        /// <summary>
        /// The ID of the sale
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// The sale number
        /// </summary>
        public string SaleNumber { get; init; } = string.Empty;

        /// <summary>
        /// The date/time when the sale was created
        /// </summary>
        public DateTime Date { get; init; }

        /// <summary>
        /// The customer name
        /// </summary>
        public string Customer { get; init; } = string.Empty;

        /// <summary>
        /// The branch name
        /// </summary>
        public string Branch { get; init; } = string.Empty;

        /// <summary>
        /// The current status of the sale
        /// </summary>
        public SaleStatus Status { get; init; }

        /// <summary>
        /// The total amount of the sale
        /// </summary>
        public decimal TotalAmount { get; init; }

        /// <summary>
        /// The items in the sale
        /// </summary>
        public List<GetSaleItemResult> Items { get; init; } = new List<GetSaleItemResult>();
    }
}
