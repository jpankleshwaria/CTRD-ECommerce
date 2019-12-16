using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTRD.ECommerce.Application.Commands;
using CTRD.ECommerce.Application.Queries;
using CTRD.ECommerce.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CTRD.ECommerce.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductAttributeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductAttributeController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="logger">The logger.</param>
        public ProductAttributeController(IMediator mediator, ILogger<ProductAttributeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #region ProductAttribute
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProductAttributes")]
        public async Task<ActionResult<IEnumerable<ProductAttributeViewModel>>> GetProductAttributes(string searchVal)
        {
            return Ok(await _mediator.Send(new GetProductAttributeQuery(searchVal)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProductAttributeByProdId")]
        public async Task<ActionResult<ProductAttributeViewModel>> GetProductAttributeByProdId(int prodId)
        {
            return Ok(await _mediator.Send(new GetProductAttributeByProdIdQuery(prodId)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProductAttributeById")]
        public async Task<ActionResult<ProductAttributeViewModel>> GetProductAttributeById(int prodId, int prodAttributeId)
        {
            return Ok(await _mediator.Send(new GetProductAttributeByIdQuery(prodId, prodAttributeId)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addProductAttributeCommand"></param>
        /// <returns></returns>
        [HttpPost("AddProductAttribute")]
        public async Task<ActionResult<int>> AddProduct([FromBody] AddProductAttributeCommand addProductAttributeCommand)
        {
            return Ok(await _mediator.Send(addProductAttributeCommand));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateProductAttributeCommand"></param>
        /// <returns></returns>
        [HttpPut("UpdateProductAttribute")]
        public async Task<ActionResult<int>> UpdateProductAttribute([FromBody] UpdateProductAttributeCommand updateProductAttributeCommand)
        {
            return Ok(await _mediator.Send(updateProductAttributeCommand));
        }
        #endregion
    }
}