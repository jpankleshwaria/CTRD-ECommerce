using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.Interfaces
{
    /// <summary>
    /// this request implementes for which command's have validation
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public interface IValidationRequest<TResponse> : IRequest<TResponse>
    {

    }
}
