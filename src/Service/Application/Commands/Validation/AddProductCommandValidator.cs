using Common.Domain.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTRD.ECommerce.Application.Commands.Validation
{
    /// <summary>
    /// 
    /// </summary>
    class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        public AddProductCommandValidator()
        {
            RuleFor(x => x.ProdName)
                            .Must(x => !string.IsNullOrEmpty(x)).WithMessage(string.Format(ValidationMessages.IsRequired, "Product Name"))
                            .MaximumLength(50).WithMessage(string.Format(ValidationMessages.MaxLength, "Product Name", 50));
        }
    }
}
