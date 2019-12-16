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
    public class GetProductQuery : IRequest<IEnumerable<ProductViewModel>>
    {
        /// <summary>
        /// 
        /// </summary>
        public string prodName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productName"></param>
        public GetProductQuery(string productName)
        {
            prodName = productName;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IEnumerable<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productRepository"></param>
        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductViewModel>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProducts(request);
        }
    }
}
