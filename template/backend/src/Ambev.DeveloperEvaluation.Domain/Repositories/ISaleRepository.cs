using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<Sale>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(Sale sale, CancellationToken cancellationToken = default);
        Task UpdateAsync(Sale sale, CancellationToken cancellationToken = default);
        Task DeleteAsync(Sale sale, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels the sale and updates its status.
        /// </summary>
        /// <param name="sale">The sale to cancel</param>
        Task CancelAsync(Sale sale, CancellationToken cancellationToken = default);
    }
}
