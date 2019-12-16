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
    public class GetProductCategoryQuery : IRequest<IEnumerable<ProductCategoryViewModel>>
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public class GetProductCategoryQueryHandler : IRequestHandler<GetProductCategoryQuery, IEnumerable<ProductCategoryViewModel>>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productRepository"></param>
        public GetProductCategoryQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductCategoryViewModel>> Handle(GetProductCategoryQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductCategories(request);
        }
    }
}
