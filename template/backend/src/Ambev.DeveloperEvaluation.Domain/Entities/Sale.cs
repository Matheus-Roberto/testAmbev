using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity, ISale
    {
        public string SaleNumber { get; private set; }
        public DateTime Date { get; private set; }
        public string Customer { get; private set; }
        public string Branch { get; private set; }
        public SaleStatus Status { get; private set; }

        private readonly List<SaleItem> _items = new();
        public IReadOnlyCollection<SaleItem> Items => _items;

        public decimal TotalAmount => _items.Sum(i => i.TotalWithDiscount);
        public Sale(string saleNumber, string customer, string branch)
        {
            SaleNumber = saleNumber;
            Customer = customer;
            Branch = branch;
            Date = DateTime.UtcNow;
            Status = SaleStatus.Active;

            Validate();
        }
        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public void AddItem(string productName, int quantity, decimal unitPrice)
        {
            if (Status == SaleStatus.Cancelled)
                throw new InvalidOperationException("You cannot add items to a cancelled sale.");

            var item = new SaleItem(productName, quantity, unitPrice);
            _items.Add(item);
        }


        public void Cancel()
        {
            Status = SaleStatus.Cancelled;
        }
    }
}
