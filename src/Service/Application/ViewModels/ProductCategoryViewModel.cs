using Common.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTRD.ECommerce.Application.ViewModels
{
    public class ProductCategoryViewModel : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int ProdCatId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CategoryName { get; set; }
    }
}
