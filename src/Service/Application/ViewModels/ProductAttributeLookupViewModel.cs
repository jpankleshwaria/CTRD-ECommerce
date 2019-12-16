using Common.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTRD.ECommerce.Application.ViewModels
{
    public class ProductAttributeLookupViewModel : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int AttributeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProdCatId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AttributeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CategoryName { get; set; }
    }
}
