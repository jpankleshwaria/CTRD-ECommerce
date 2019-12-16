using Common.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTRD.ECommerce.Application.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductAttributeViewModel : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int ProdAttrId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AttributeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AttributeValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProdName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AttributeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProdCatId { get; set; }
    }
}
