using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity, ISaleItem
    {
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public decimal Discount => Quantity switch
        {
            >= 10 and <= 20 => 0.20m,
            >= 4 and < 10 => 0.10m,
            < 4 => 0m,
            > 20 => throw new ArgumentException("Cannot sell more than 20 identical items."),
        };

        public decimal TotalWithDiscount => Quantity * UnitPrice * (1 - Discount);

        public SaleItem(string productName, int quantity, decimal unitPrice)
        {
            if (quantity > 20)
                throw new ArgumentException("Cannot sell more than 20 identical items.");

            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
