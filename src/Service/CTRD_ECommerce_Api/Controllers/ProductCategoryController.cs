using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTRD.ECommerce.Application.Queries;
using CTRD.ECommerce.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CTRD.ECommerce.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductCategoryController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCategoryController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="logger">The logger.</param>
        public ProductCategoryController(IMediator mediator, ILogger<ProductCategoryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProductCategories")]
        public async Task<ActionResult<IEnumerable<ProductCategoryViewModel>>> GetProductCategories()
        {
            return Ok(await _mediator.Send(new GetProductCategoryQuery()));
        }
    }
}