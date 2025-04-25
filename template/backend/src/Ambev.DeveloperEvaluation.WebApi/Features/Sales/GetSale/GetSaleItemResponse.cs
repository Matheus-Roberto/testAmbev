namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleItemResponse
    {
        /// <summary>
        /// Product name
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Unit price
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Applied discount
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Total with discount
        /// </summary>
        public decimal TotalWithDiscount { get; set; }
    }
}
