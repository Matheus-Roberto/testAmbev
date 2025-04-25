namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class SaleItemRequest
    {
        /// <summary>
        /// Product name (1-100 characters)
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Quantity (1-20 units)
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Unit price (> 0)
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}
