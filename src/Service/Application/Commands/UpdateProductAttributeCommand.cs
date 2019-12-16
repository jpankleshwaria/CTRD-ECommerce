using Common.Domain.Interfaces;
using CTRD.ECommerce.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CTRD.ECommerce.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateProductAttributeCommand : IValidationRequest<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public int ProdAttrId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AttributeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AttributeValue { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdateProductAttributeCommandHandler : IRequestHandler<UpdateProductAttributeCommand, int>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productRepository"></param>
        public UpdateProductAttributeCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(UpdateProductAttributeCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.UpdateProductAttribute(request);
        }
    }
}
