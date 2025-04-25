using Ambev.DeveloperEvaluation.Domain.Enums;

public class CancelSaleResult
{
    public Guid SaleId { get; set; }
    public SaleStatus Status { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTime CancelledAt { get; set; }
}