using Common.Domain.Attributes;
using Common.Domain.Constants;
using Common.Domain.Interfaces;
using CTRD.ECommerce.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace CTRD.ECommerce.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class AddProductAttributeCommand : IValidationRequest<int>
    {
        /// <summary>
        /// 
        /// </summary>
        [DbParam(Direction = ParamDirection.Output)]
        [JsonIgnore]
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
    public class AddProductAttributeCommandHandler : IRequestHandler<AddProductAttributeCommand, int>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productRepository"></param>
        public AddProductAttributeCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(AddProductAttributeCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.AddProductAttribute(request);
        }
    }
}
