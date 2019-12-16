using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CTRD.ECommerce.Web.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CTRD.ECommerce.Web.Helper;
using CTRD.ECommerce.Web.Models.Product;

namespace CTRD.ECommerce.Web.Controllers
{
    [Route("[controller]")]
    public class ProductAttributeLookupController : Controller
    {
        private readonly HttpClient client;

        public ProductAttributeLookupController(IHttpClientAccessor httpClientAccessor)
        {
            client = httpClientAccessor.Client;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("ProductAttributeLookupList")]
        public async Task<ActionResult> ProductAttributeLookupList()
        {
            await AddAccessTokenAsync();
            var apiResponse = await client.GetAsync(Constants.AdminAPIURL + APIEndPoints_ProductAttribute.ProductAttributeLookupList);
            if (apiResponse.IsSuccessStatusCode)
            {
                var lookupList = apiResponse.Content.ReadAsAsync<IEnumerable<ProductAttributeLookup>>().Result;
                return Json(lookupList);
            }
            else
                return new ApiResponse().GetObjectResult(apiResponse, string.Empty);
        }

        [HttpGet]
        [Route("GetProductAttributeLookupsByProdCatId")]
        public async Task<ActionResult> GetProductAttributeLookupsByProdCatId(int prodCatId)
        {
            await AddAccessTokenAsync();
            var apiResponse = await client.GetAsync(Constants.AdminAPIURL + string.Format(APIEndPoints_ProductAttribute.ProductAttributeLookupByProdCatIdList, prodCatId));
            if (apiResponse.IsSuccessStatusCode)
            {
                var lookupList = apiResponse.Content.ReadAsAsync<IEnumerable<ProductAttributeLookup>>().Result;
                return Json(lookupList);
            }
            else
                return new ApiResponse().GetObjectResult(apiResponse, string.Empty);
        }

        private async Task AddAccessTokenAsync()
        {
            var accessToken = await HttpContext.GetTokenAsync(Constants.AcessToken);

            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue(Constants.BEARER, accessToken);

        }
    }
}