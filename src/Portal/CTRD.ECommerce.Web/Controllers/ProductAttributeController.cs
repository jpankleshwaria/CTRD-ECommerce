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
using CTRD.ECommerce.Web.Models.ProductAttribute;

namespace CTRD.ECommerce.Web.Controllers
{
    [Route("[controller]")]
    public class ProductAttributeController : Controller
    {
        private readonly HttpClient client;

        public ProductAttributeController(IHttpClientAccessor httpClientAccessor)
        {
            client = httpClientAccessor.Client;
        }

        // GET: ProductAttribute
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("ProductAttributeList")]
        public async Task<ActionResult> ProductAttributeList()
        {
            await AddAccessTokenAsync();
            var apiResponse = await client.GetAsync(Constants.AdminAPIURL + string.Format(APIEndPoints_ProductAttribute.ProductAttributeList, ""));
            if (apiResponse.IsSuccessStatusCode)
            {
                var lookupList = apiResponse.Content.ReadAsAsync<IEnumerable<ProductAttribute>>().Result;
                return Json(lookupList);
            }
            else
                return new ApiResponse().GetObjectResult(apiResponse, string.Empty);
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            return PartialView("_Add");
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add(ProductAttribute productAttributeData)
        {
            if (ModelState.IsValid)
            {
                await AddAccessTokenAsync();
                if (productAttributeData.ProdAttrId > 0)
                {
                    var apiResponse = await client.PutAsJsonAsync(
                    Constants.AdminAPIURL + string.Format(APIEndPoints_ProductAttribute.ProductAttribute_Update), productAttributeData);

                    return new ApiResponse().GetObjectResult(apiResponse, "Product Attribute Data saved successfully");
                }
                else
                {
                    var apiResponse = await client.PostAsJsonAsync(
                    Constants.AdminAPIURL + string.Format(APIEndPoints_ProductAttribute.ProductAttribute_Add), productAttributeData);

                    return new ApiResponse().GetObjectResult(apiResponse, "Product Attribute Data saved successfully");
                }

            }
            else
            {
                return new BadRequestObjectResult(ModelState.Values);
            }
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit()
        {
            return PartialView("_Edit");
        }

        [HttpGet]
        [Route("GetProductAttributeById")]
        public async Task<ActionResult> GetProductAttributeById(int productId, int prodAttributeId)
        {
            await AddAccessTokenAsync();
            var apiResponse = await client.GetAsync(Constants.AdminAPIURL + string.Format(APIEndPoints_ProductAttribute.GetProductAttributeById, productId, prodAttributeId));
            if (apiResponse.IsSuccessStatusCode)
            {
                var productList = apiResponse.Content.ReadAsAsync<IEnumerable<ProductAttribute>>().Result;
                return Json(productList);
            }
            else
                return new ApiResponse().GetObjectResult(apiResponse, string.Empty);
        }

        [HttpGet]
        [Route("GetProductAttributeByProdId")]
        public async Task<ActionResult> GetProductAttributeByProdId(int productId)
        {
            await AddAccessTokenAsync();
            var apiResponse = await client.GetAsync(Constants.AdminAPIURL + string.Format(APIEndPoints_ProductAttribute.GetProductAttributeByProdId, productId));
            if (apiResponse.IsSuccessStatusCode)
            {
                var productList = apiResponse.Content.ReadAsAsync<IEnumerable<ProductAttribute>>().Result;
                return Json(productList);
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