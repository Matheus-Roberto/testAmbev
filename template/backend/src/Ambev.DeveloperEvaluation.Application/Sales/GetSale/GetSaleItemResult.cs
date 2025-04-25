

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleItemResult
    {
        /// <summary>
        /// The product name
        /// </summary>
        public string ProductName { get; init; } = string.Empty;

        /// <summary>
        /// The quantity purchased
        /// </summary>
        public int Quantity { get; init; }

        /// <summary>
        /// The unit price of the item
        /// </summary>
        public decimal UnitPrice { get; init; }

        /// <summary>
        /// The discount applied to this item
        /// </summary>
        public decimal Discount { get; init; }

        /// <summary>
        /// The total price for this item including discount
        /// </summary>
        public decimal TotalWithDiscount { get; init; }
    }
}
