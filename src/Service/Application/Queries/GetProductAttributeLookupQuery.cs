using CTRD.ECommerce.Application.ViewModels;
using CTRD.ECommerce.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CTRD.ECommerce.Application.Queries
{
    public class GetProductAttributeLookupQuery : IRequest<IEnumerable<ProductAttributeLookupViewModel>>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetProductAttributeLookupQueryHandler : IRequestHandler<GetProductAttributeLookupQuery, IEnumerable<ProductAttributeLookupViewModel>>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productRepository"></param>
        public GetProductAttributeLookupQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductAttributeLookupViewModel>> Handle(GetProductAttributeLookupQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductAttributeLookups(request);
        }
    }
}
