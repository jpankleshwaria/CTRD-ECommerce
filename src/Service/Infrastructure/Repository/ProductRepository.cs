using Dapper;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CTRD.ECommerce.Application.Commands;
using CTRD.ECommerce.Application.DTO;
using CTRD.ECommerce.Application.Interfaces;
using CTRD.ECommerce.Infrastructure.Interfaces;
using Common.Domain.Helper;
using CTRD.ECommerce.Application.ViewModels;
using CTRD.ECommerce.Application.Queries;

namespace CTRD.ECommerce.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConnectionFactory _connection;

        public ProductRepository(IConnectionFactory connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<CspListDTO>> GetAll()
        {
            return null;
        }

        #region Product Category
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductCategoryViewModel>> GetProductCategories(GetProductCategoryQuery request)
        {
            IEnumerable<ProductCategoryViewModel> result = null;
            using (var conn = _connection.GetConnection())
            {
                var dynamicParameters = SqlHelper.GetDynamicParmeters<GetProductCategoryQuery>(request);
                result = await SqlMapper.QueryAsync<ProductCategoryViewModel>(conn, "usp_GetProductCategories", dynamicParameters, null, null, CommandType.StoredProcedure);
            }
            return result;
        }
        #endregion

        #region Product Attribute Lookup
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductAttributeLookupViewModel>> GetProductAttributeLookups(GetProductAttributeLookupQuery request)
        {
            IEnumerable<ProductAttributeLookupViewModel> result = null;
            using (var conn = _connection.GetConnection())
            {
                var dynamicParameters = SqlHelper.GetDynamicParmeters<GetProductAttributeLookupQuery>(request);
                result = await SqlMapper.QueryAsync<ProductAttributeLookupViewModel>(conn, "usp_GetProductAttributeLookups", dynamicParameters, null, null, CommandType.StoredProcedure);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductAttributeLookupViewModel>> GetProductAttributeLookupsByProdCatId(GetProductAttributeLookupsByProdCatIdQuery request)
        {
            IEnumerable<ProductAttributeLookupViewModel> result = null;
            using (var conn = _connection.GetConnection())
            {
                var dynamicParameters = SqlHelper.GetDynamicParmeters<GetProductAttributeLookupsByProdCatIdQuery>(request);
                result = await SqlMapper.QueryAsync<ProductAttributeLookupViewModel>(conn, "usp_GetProductAttributeLookupsByProdCatId", dynamicParameters, null, null, CommandType.StoredProcedure);
            }
            return result;
        }
        #endregion

        #region Product
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductViewModel>> GetProducts(GetProductQuery request)
        {
            IEnumerable<ProductViewModel> result = null;
            using (var conn = _connection.GetConnection())
            {
                var dynamicParameters = SqlHelper.GetDynamicParmeters<GetProductQuery>(request);
                result = await SqlMapper.QueryAsync<ProductViewModel>(conn, "usp_GetProducts", dynamicParameters, null, null, CommandType.StoredProcedure);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductViewModel>> GetProductsByCatId(GetProductByCategoryQuery request)
        {
            IEnumerable<ProductViewModel> result = null;
            using (var conn = _connection.GetConnection())
            {
                var dynamicParameters = SqlHelper.GetDynamicParmeters<GetProductByCategoryQuery>(request);
                result = await SqlMapper.QueryAsync<ProductViewModel>(conn, "usp_GetProductsByCatId", dynamicParameters, null, null, CommandType.StoredProcedure);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductViewModel>> GetProductById(GetProductByIdQuery request)
        {
            IEnumerable<ProductViewModel> result = null;
            using (var conn = _connection.GetConnection())
            {
                var dynamicParameters = SqlHelper.GetDynamicParmeters<GetProductByIdQuery>(request);
                result = await SqlMapper.QueryAsync<ProductViewModel>(conn, "usp_GetProductById", dynamicParameters, null, null, CommandType.StoredProcedure);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> AddProduct(AddProductCommand request)
        {
            int productId = 0;
            var dynamicParameters = SqlHelper.GetDynamicParmeters<AddProductCommand>(request);
            using (var conn = _connection.GetConnection())
            {
                await SqlMapper.QueryAsync<ProductViewModel>(conn, "usp_AddProduct", dynamicParameters, null, null, CommandType.StoredProcedure);
                productId = dynamicParameters.Get<int>("ProductId");
            }

            return productId;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> UpdateProduct(UpdateProductCommand request)
        {
            var dynamicParameters = SqlHelper.GetDynamicParmeters<UpdateProductCommand>(request);
            using (var conn = _connection.GetConnection())
            {
                await SqlMapper.QueryAsync<ProductViewModel>(conn, "usp_UpdateProduct", dynamicParameters, null, null, CommandType.StoredProcedure);
            }

            return request.ProductId;

        }

        #endregion

        #region Product Attribute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductAttributeViewModel>> GetProductAttributes(GetProductAttributeQuery request)
        {
            IEnumerable<ProductAttributeViewModel> result = null;
            using (var conn = _connection.GetConnection())
            {
                var dynamicParameters = SqlHelper.GetDynamicParmeters<GetProductAttributeQuery>(request);
                result = await SqlMapper.QueryAsync<ProductAttributeViewModel>(conn, "usp_GetProductAttributes", dynamicParameters, null, null, CommandType.StoredProcedure);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductAttributeViewModel>> GetProductAttributeByProdId(GetProductAttributeByProdIdQuery request)
        {
            IEnumerable<ProductAttributeViewModel> result = null;
            using (var conn = _connection.GetConnection())
            {
                var dynamicParameters = SqlHelper.GetDynamicParmeters<GetProductAttributeByProdIdQuery>(request);
                result = await SqlMapper.QueryAsync<ProductAttributeViewModel>(conn, "usp_GetProductAttributeByProdId", dynamicParameters, null, null, CommandType.StoredProcedure);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductAttributeViewModel>> GetProductAttributeById(GetProductAttributeByIdQuery request)
        {
            IEnumerable<ProductAttributeViewModel> result = null;
            using (var conn = _connection.GetConnection())
            {
                var dynamicParameters = SqlHelper.GetDynamicParmeters<GetProductAttributeByIdQuery>(request);
                result = await SqlMapper.QueryAsync<ProductAttributeViewModel>(conn, "usp_GetProductAttributeById", dynamicParameters, null, null, CommandType.StoredProcedure);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> AddProductAttribute(AddProductAttributeCommand request)
        {
            int productId = 0;
            var dynamicParameters = SqlHelper.GetDynamicParmeters<AddProductAttributeCommand>(request);
            using (var conn = _connection.GetConnection())
            {
                await SqlMapper.QueryAsync<ProductAttributeViewModel>(conn, "usp_AddProductAttribute", dynamicParameters, null, null, CommandType.StoredProcedure);
                productId = dynamicParameters.Get<int>("ProductId");
            }

            return productId;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> UpdateProductAttribute(UpdateProductAttributeCommand request)
        {
            var dynamicParameters = SqlHelper.GetDynamicParmeters<UpdateProductAttributeCommand>(request);
            using (var conn = _connection.GetConnection())
            {
                await SqlMapper.QueryAsync<ProductAttributeViewModel>(conn, "usp_UpdateProductAttribute", dynamicParameters, null, null, CommandType.StoredProcedure);
            }

            return request.ProductId;

        }
        #endregion
    }
}
