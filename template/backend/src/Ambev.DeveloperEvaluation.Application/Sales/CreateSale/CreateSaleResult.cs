using Ambev.DeveloperEvaluation.Domain.Enums;


namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
 /// <summary>
 /// Result returned after creating a sale
 /// </summary>
    public class CreateSaleResult
    {
        /// <summary>
        /// ID of the created sale
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// Sale number
        /// </summary>
        public string SaleNumber { get; set; } = string.Empty;

        /// <summary>
        /// Total amount of the sale
        /// </summary>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Status of the sale
        /// </summary>
        public SaleStatus Status { get; set; }
    }
}
