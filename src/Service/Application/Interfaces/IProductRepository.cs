using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CTRD.ECommerce.Application.Commands;
using CTRD.ECommerce.Application.DTO;
using CTRD.ECommerce.Application.Queries;
using CTRD.ECommerce.Application.ViewModels;

namespace CTRD.ECommerce.Application.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CspListDTO>> GetAll();

        #region Product Category
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<ProductCategoryViewModel>> GetProductCategories(GetProductCategoryQuery request);
        #endregion

        #region Product Attribute Lookup
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<ProductAttributeLookupViewModel>> GetProductAttributeLookups(GetProductAttributeLookupQuery request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<ProductAttributeLookupViewModel>> GetProductAttributeLookupsByProdCatId(GetProductAttributeLookupsByProdCatIdQuery request);

        #endregion

        #region Product
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<ProductViewModel>> GetProducts(GetProductQuery request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<ProductViewModel>> GetProductsByCatId(GetProductByCategoryQuery request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<ProductViewModel>> GetProductById(GetProductByIdQuery request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<int> AddProduct(AddProductCommand request);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<int> UpdateProduct(UpdateProductCommand request);

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //Task<bool> DeleteCustomer(DeleteCustomerCommand request);

        #endregion

        #region Product Attribute

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<ProductAttributeViewModel>> GetProductAttributes(GetProductAttributeQuery request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<ProductAttributeViewModel>> GetProductAttributeByProdId(GetProductAttributeByProdIdQuery request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IEnumerable<ProductAttributeViewModel>> GetProductAttributeById(GetProductAttributeByIdQuery request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<int> AddProductAttribute(AddProductAttributeCommand request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<int> UpdateProductAttribute(UpdateProductAttributeCommand request);

        #endregion
    }
}
