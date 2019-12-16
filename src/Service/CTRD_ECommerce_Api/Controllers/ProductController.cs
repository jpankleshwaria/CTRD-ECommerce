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
    /// Product Controller
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="logger">The logger.</param>
        public ProductController(IMediator mediator, ILogger<ProductController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #region Product
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProducts")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProducts(string productName)
        {
            return Ok(await _mediator.Send(new GetProductQuery(productName)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProductsByCatId")]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProductsByCatId(int productCatId)
        {
            return Ok(await _mediator.Send(new GetProductByCategoryQuery(productCatId)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProductById")]
        public async Task<ActionResult<ProductViewModel>> GetProductById(int prodId)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery(prodId)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addProductCommand"></param>
        /// <returns></returns>
        [HttpPost("AddProduct")]
        public async Task<ActionResult<int>> AddProduct([FromBody] AddProductCommand addProductCommand)
        {
            return Ok(await _mediator.Send(addProductCommand));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateProductCommand"></param>
        /// <returns></returns>
        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<int>> UpdateProduct([FromBody] UpdateProductCommand updateProductCommand)
        {
            return Ok(await _mediator.Send(updateProductCommand));
        }
        #endregion
    }
}
