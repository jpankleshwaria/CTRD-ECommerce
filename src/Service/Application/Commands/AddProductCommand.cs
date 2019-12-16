using Newtonsoft.Json;
using Common.Domain.Attributes;
using Common.Domain.Constants;
using MediatR;
using Common.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using CTRD.ECommerce.Application.Interfaces;
using System;

namespace CTRD.ECommerce.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class AddProductCommand : IValidationRequest<int>
    {
        /// <summary>
        /// 
        /// </summary>
        [DbParam(Direction = ParamDirection.Output)]
        [JsonIgnore]
        public int ProductId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProdCatId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProdName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProdDescription { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productRepository"></param>
        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.AddProduct(request);
        }
    }
}
