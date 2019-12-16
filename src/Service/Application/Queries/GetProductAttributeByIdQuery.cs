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
    public class GetProductAttributeByIdQuery : IRequest<IEnumerable<ProductAttributeViewModel>>
    {
        /// <summary>
        /// 
        /// </summary>
        public int ProdId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AttrId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prodId"></param>
        /// <param name="attId"></param>
        public GetProductAttributeByIdQuery(int prodId, int attId)
        {
            ProdId = prodId;
            AttrId = attId;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetProductAttributeByIdQueryHandler : IRequestHandler<GetProductAttributeByIdQuery, IEnumerable<ProductAttributeViewModel>>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productRepository"></param>
        public GetProductAttributeByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductAttributeViewModel>> Handle(GetProductAttributeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductAttributeById(request);
        }
    }
}
