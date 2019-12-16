using Common.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTRD.ECommerce.Application.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductViewModel : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProdCatId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProdCatName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProdName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProdDescription { get; set; }
    }
}
