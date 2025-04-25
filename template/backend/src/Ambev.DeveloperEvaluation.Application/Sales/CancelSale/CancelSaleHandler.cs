using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    /// <summary>
    /// Handler for processing CancelSaleCommand requests
    /// </summary>
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, CancelSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CancelSaleHandler
        /// </summary>
        /// <param name="saleRepository">The sale repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public CancelSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the CancelSaleCommand request
        /// </summary>
        /// <param name="request">The cancel sale command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A CancelSaleResponse containing the cancellation result</returns>
        public async Task<CancelSaleResult> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new CancelSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
            if (sale == null)
                throw new KeyNotFoundException($"Sale with ID {request.Id} not found");

            if (sale.Status == SaleStatus.Cancelled)
            {
                return new CancelSaleResult
                {
                    SaleId = sale.Id,
                    Status = sale.Status,
                    Message = "Sale was already cancelled"
                };
            }

            sale.Cancel();
            await _saleRepository.UpdateAsync(sale, cancellationToken);

            return new CancelSaleResult
            {
                SaleId = sale.Id,
                Status = sale.Status,
                Message = "Sale cancelled successfully",
                CancelledAt = DateTime.UtcNow
            };
        }
    }
}