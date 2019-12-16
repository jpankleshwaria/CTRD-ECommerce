using CTRD.ECommerce.Application.Interfaces;
using CTRD.ECommerce.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CTRD.ECommerce.Application.Queries
{
    public class GetProductAttributeLookupsByProdCatIdQuery : IRequest<IEnumerable<ProductAttributeLookupViewModel>>
    {
        /// <summary>
        /// 
        /// </summary>
        public int ProdCatId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prodCatId"></param>
        public GetProductAttributeLookupsByProdCatIdQuery(int prodCatId)
        {
            ProdCatId = prodCatId;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetProductAttributeLookupsByProdCatIdQueryHandler : IRequestHandler<GetProductAttributeLookupsByProdCatIdQuery, IEnumerable<ProductAttributeLookupViewModel>>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productRepository"></param>
        public GetProductAttributeLookupsByProdCatIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductAttributeLookupViewModel>> Handle(GetProductAttributeLookupsByProdCatIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductAttributeLookupsByProdCatId(request);
        }
    }
}
