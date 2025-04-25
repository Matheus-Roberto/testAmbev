namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface ISaleItem
    {
        public string ProductName { get; }
        public int Quantity { get; }
        public decimal UnitPrice { get; }
        public decimal Discount { get; }
        public decimal TotalWithDiscount { get; }
    }
}