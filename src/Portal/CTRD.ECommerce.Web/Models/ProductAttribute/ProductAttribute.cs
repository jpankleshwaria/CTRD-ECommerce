using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTRD.ECommerce.Web.Models.ProductAttribute
{
    public class ProductAttribute
    {
        public int ProdAttrId { get; set; }

        [Display(Name = "Prod Id")]
        public int ProductId { get; set; }

        [Display(Name = "Attribute Id")]
        public int AttributeId { get; set; }

        [Display(Name = "Attribute Value")]
        public string AttributeValue { get; set; }

        [Display(Name = "Prod Name")]
        public string ProdName { get; set; }

        [Display(Name = "Attribute Name")]
        public string AttributeName { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public string ProdCatId { get; set; }
    }
}
