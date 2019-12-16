using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTRD.ECommerce.Web.Models.Product
{
    public class ProductListViewModel
    {
        public List<Product> ProductList { get; set; }

        public ProductListViewModel() { }

        public ProductListViewModel(List<Product> ProductList)
        {
            this.ProductList = ProductList;
        }
    }
}
