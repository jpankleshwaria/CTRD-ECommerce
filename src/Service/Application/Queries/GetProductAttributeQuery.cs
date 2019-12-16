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
    /// <summary>
    /// 
    /// </summary>
    public class GetProductAttributeQuery : IRequest<IEnumerable<ProductAttributeViewModel>>
    {
        /// <summary>
        /// 
        /// </summary>
        public string SearchVal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productName"></param>
        public GetProductAttributeQuery(string searchVal)
        {
            SearchVal = searchVal;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetProductAttributeQueryHandler : IRequestHandler<GetProductAttributeQuery, IEnumerable<ProductAttributeViewModel>>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productRepository"></param>
        public GetProductAttributeQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductAttributeViewModel>> Handle(GetProductAttributeQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductAttributes(request);
        }
    }
}
