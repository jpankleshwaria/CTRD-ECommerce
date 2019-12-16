using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException()
        { }

        public DomainException(string message, Exception innerException)
           : base(message, innerException)
        { }
    }
}
