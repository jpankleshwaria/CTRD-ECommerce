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
    public class ProductAttributeLookupController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductAttributeLookupController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAttributeLookupController"/> class.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="logger">The logger.</param>
        public ProductAttributeLookupController(IMediator mediator, ILogger<ProductAttributeLookupController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProductAttributeLookups")]
        public async Task<ActionResult<IEnumerable<ProductAttributeLookupViewModel>>> GetProductAttributeLookups()
        {
            return Ok(await _mediator.Send(new GetProductAttributeLookupQuery()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProductAttributeLookupsByProdCatId")]
        public async Task<ActionResult<ProductAttributeLookupViewModel>> GetProductAttributeLookupsByProdCatId(int prodCatId)
        {
            return Ok(await _mediator.Send(new GetProductAttributeLookupsByProdCatIdQuery(prodCatId)));
        }
    }
}