using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Exceptions
{
    public class DomainValidationException : DomainException
    {
        public DomainValidationException(ValidationResult validation) : base()
        {

        }

        public DomainValidationException(string message, Exception innerException)
           : base(message, innerException)
        { }
    }
}
