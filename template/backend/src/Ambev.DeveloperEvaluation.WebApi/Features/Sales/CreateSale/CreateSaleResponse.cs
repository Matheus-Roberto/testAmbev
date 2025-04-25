using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// API response model for CreateUser operation
/// </summary>
public class CreateSaleResponse
{
    /// <summary>
    /// Sale ID
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Sale number
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// Creation date
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Customer name
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// Branch name
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Current status
    /// </summary>
    public SaleStatus Status { get; set; }

    /// <summary>
    /// Total amount with discounts
    /// </summary>
    public decimal TotalAmount { get; set; }
}
