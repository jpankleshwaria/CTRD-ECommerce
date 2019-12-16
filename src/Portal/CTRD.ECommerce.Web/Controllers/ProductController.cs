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
    public class ProductController : Controller
    {
        private readonly HttpClient client;

        public ProductController(IHttpClientAccessor httpClientAccessor)
        {
            client = httpClientAccessor.Client;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("ProductList")]
        public async Task<ActionResult> ProductList(string productname)
        {
            await AddAccessTokenAsync();
            var apiResponse = await client.GetAsync(Constants.AdminAPIURL + string.Format(APIEndPoints_Product.ProductList, productname));
            if (apiResponse.IsSuccessStatusCode)
            {
                var serviceList = apiResponse.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                return Json(serviceList);
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
        public async Task<ActionResult> Add(Product productData)
        {
            if (ModelState.IsValid)
            {
                await AddAccessTokenAsync();
                if (productData.ProductId > 0)
                {
                    var apiResponse = await client.PutAsJsonAsync(
                    Constants.AdminAPIURL + string.Format(APIEndPoints_Product.Product_Update), productData);

                    return new ApiResponse().GetObjectResult(apiResponse, "Product Data updated successfully");
                }
                else
                {
                    var apiResponse = await client.PostAsJsonAsync(
                    Constants.AdminAPIURL + string.Format(APIEndPoints_Product.Product_Add), productData);

                    return new ApiResponse().GetObjectResult(apiResponse, "Product Data saved successfully");
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
        [Route("GetProductsByCatId")]
        public async Task<ActionResult> GetProductsByCatId(string prodCatId)
        {
            await AddAccessTokenAsync();
            var apiResponse = await client.GetAsync(Constants.AdminAPIURL + string.Format(APIEndPoints_Product.GetProductByCatId, prodCatId));
            if (apiResponse.IsSuccessStatusCode)
            {
                var productList = apiResponse.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                return Json(productList);
            }
            else
                return new ApiResponse().GetObjectResult(apiResponse, string.Empty);
        }

        [HttpGet]
        [Route("GetProductById")]
        public async Task<ActionResult> GetProductById(string productId)
        {
            await AddAccessTokenAsync();
            var apiResponse = await client.GetAsync(Constants.AdminAPIURL + string.Format(APIEndPoints_Product.GetProductById, productId));
            if (apiResponse.IsSuccessStatusCode)
            {
                var productList = apiResponse.Content.ReadAsAsync<IEnumerable<Product>>().Result;
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