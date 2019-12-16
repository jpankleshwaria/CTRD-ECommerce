using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTRD.ECommerce.Web.Models.Product
{
    public class ProductAttributeLookup
    {
        public int AttributeId { get; set; }

        public int ProdCatId { get; set; }

        public string AttributeName { get; set; }

        public string CategoryName { get; set; }
    }
}
