using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CTRD.ECommerce.Web.Models.Product
{
    public class ProductCategory
    {
        public int ProdCatId { get; set; }

        public string CategoryName { get; set; }
    }
}
