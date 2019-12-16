using CTRD.ECommerce.Application.DTO;
using CTRD.ECommerce.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CTRD.ECommerce.Application.Queries
{
    /// <summary>
    /// Get Csp List DTO Query
    /// </summary>
    public class GetCspListDTOQuery : IRequest<IEnumerable<CspListDTO>>
    {
    }
    /// <summary>
    /// Get Csp List CSP Query Handler
    /// </summary>
    public class GetCspListDTOQueryHandler : IRequestHandler<GetCspListDTOQuery, IEnumerable<CspListDTO>>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCspListDTOQueryHandler"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// 
        public GetCspListDTOQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<CspListDTO>> Handle(GetCspListDTOQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAll();
        }
    }
}
