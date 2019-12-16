using System.Threading.Tasks;
using CTRD.ECommerce.Web.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CTRD.ECommerce.Web.Helper;
using CTRD.ECommerce.Web.Models.Product;
using System.Collections.Generic;
using System.Net.Http;

namespace CTRD.ECommerce.Web.Controllers
{
    [Route("[controller]")]
    public class ProductCategoryController : Controller
    {
        private readonly HttpClient client;

        public ProductCategoryController(IHttpClientAccessor httpClientAccessor)
        {
            client = httpClientAccessor.Client;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("ProductCategoryList")]
        public async Task<ActionResult> ProductCategoryList()
        {
            await AddAccessTokenAsync();
            var apiResponse = await client.GetAsync(Constants.AdminAPIURL + APIEndPoints_Product.ProductCategoryList);
            if (apiResponse.IsSuccessStatusCode)
            {
                var productCategoryList = apiResponse.Content.ReadAsAsync<IEnumerable<ProductCategory>>().Result;
                return Json(productCategoryList);
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