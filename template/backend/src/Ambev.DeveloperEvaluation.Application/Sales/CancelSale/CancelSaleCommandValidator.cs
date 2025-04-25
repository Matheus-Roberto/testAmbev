﻿using FluentValidation;


namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    /// <summary>
    /// Validator for CancelSaleCommand
    /// </summary>
    public class CancelSaleCommandValidator : AbstractValidator<CancelSaleCommand>
    {
        /// <summary>
        /// Initializes validation rules
        /// </summary>
        public CancelSaleCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Sale ID is required");
        }
    }
}
