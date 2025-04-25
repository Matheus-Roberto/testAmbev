using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    /// <summary>
    /// Command to cancel an existing sale
    /// </summary>
    public record CancelSaleCommand : IRequest<CancelSaleResult>
    {
        /// <summary>
        /// The unique identifier of the sale to cancel
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Initializes a new instance of CancelSaleCommand
        /// </summary>
        /// <param name="id">The ID of the sale to cancel</param>
        public CancelSaleCommand(Guid id)
        {
            Id = id;
        }
    }
}
