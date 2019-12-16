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
    public class GetProductByIdQuery : IRequest<IEnumerable<ProductViewModel>>
    {
        /// <summary>
        /// 
        /// </summary>
        public int ProdId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prodId"></param>
        public GetProductByIdQuery(int prodId)
        {
            ProdId = prodId;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, IEnumerable<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productRepository"></param>
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductViewModel>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductById(request);
        }
    }
}
