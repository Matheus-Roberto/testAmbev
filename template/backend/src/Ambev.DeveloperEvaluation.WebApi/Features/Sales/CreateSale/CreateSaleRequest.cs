using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new user in the system.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// Unique sale number (format: [A-Z0-9-]{6,20})
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// Customer name (1-100 characters)
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// Branch name (1-50 characters)
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// List of sale items (1-20 items)
    /// </summary>
    public List<SaleItemRequest> Items { get; set; } = new List<SaleItemRequest>();
}