

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleItemCommand
    {
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        /// <remarks>
        /// Must be between 1 and 100 characters
        /// </remarks>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the quantity of the product.
        /// </summary>
        /// <remarks>
        /// Must be between 1 and 20 units
        /// </remarks>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// </summary>
        /// <remarks>
        /// Must be greater than zero
        /// </remarks>
        public decimal UnitPrice { get; set; }
    }
}
