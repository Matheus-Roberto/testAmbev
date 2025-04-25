

namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface ISale
    {
        public Guid Id { get; }
        public string SaleNumber { get; }
        public DateTime Date { get; }
        public string Customer { get; }
        public string Branch { get; }
        public decimal TotalAmount { get; }

        void AddItem(string productName, int quantity, decimal unitPrice);
        void Cancel();
    }
}
