using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTRD.ECommerce.Web.Helper
{
    public class Constants
    {
        /// <summary>
        /// Page size constant
        /// </summary>
        public const int PageSize = 15;
        /// <summary>
        /// Page number constant
        /// </summary>
        public const int PageNumber = 1;

        /// <summary>
        /// Access token constant
        /// </summary>
        public const string AcessToken = "access_token";
        /// <summary>
        /// The system user
        /// </summary>
        public const string SystemUser = "System";

        public static string AdminAPIURL;

        public const string GetCspListAPIEndpoint = "api/v1/Admin/cspservices";

        public const string GetProductAPIEndpoint = "api/v1/product/{0}";

        public const string DefaultDateFormat = "{0:dd-MMM-yyyy}";

        public const string DefaultDatetimeFormat = "{0:dd-MMM-yyyy HH:mm:ss}";

        public const string FilenameDatetimeFormat = "{0:yyyyMMdd_HHmmss}";

        public const string DecimalFormat = "{0:C2}";

        public const string PercentageFormat = "{0:N2}";

        public static string ClientURL;

        public const string BEARER = "Bearer";
    }

    public class APIEndPoints_Product
    {
        public const string ProductList = "/Product/GetProducts?productName={0}";
        public const string Product_Add = "/Product/AddProduct";
        public const string Product_Update = "/Product/UpdateProduct";
        public const string GetProductById = "/Product/GetProductById?prodId={0}";
        public const string GetProductByCatId = "/Product/GetProductsByCatId?productCatId={0}";

        public const string ProductCategoryList = "/ProductCategory/GetProductCategories";
    }

    public class APIEndPoints_ProductAttribute
    {
        public const string ProductAttributeList = "/ProductAttribute/GetProductAttributes?searchVal={0}";
        public const string ProductAttribute_Add = "/ProductAttribute/AddProductAttribute";
        public const string ProductAttribute_Update = "/ProductAttribute/UpdateProductAttribute";
        public const string GetProductAttributeById = "/ProductAttribute/GetProductAttributeById?prodId={0}&prodAttributeId={1}";
        public const string GetProductAttributeByProdId = "/ProductAttribute/GetProductAttributeByProdId?ProdId={0}";

        public const string ProductAttributeLookupList = "/ProductAttributeLookup/GetProductAttributeLookups";
        public const string ProductAttributeLookupByProdCatIdList = "/ProductAttributeLookup/GetProductAttributeLookupsByProdCatId?prodCatId={0}";
    }
}
