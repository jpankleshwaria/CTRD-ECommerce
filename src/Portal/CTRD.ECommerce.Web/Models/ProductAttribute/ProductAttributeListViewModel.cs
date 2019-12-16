
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTRD.ECommerce.Web.Models.ProductAttribute
{
    public class ProductAttributeListViewModel
    {
        public List<ProductAttribute> ProductAttributeList { get; set; }

        public ProductAttributeListViewModel() { }

        public ProductAttributeListViewModel(List<ProductAttribute> ProductAttributeList)
        {
            this.ProductAttributeList = ProductAttributeList;
        }
    }
}
