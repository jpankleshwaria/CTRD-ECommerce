using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CTRD.ECommerce.Web.Models.Product
{
    public class Product
    {
        [Display(Name = "ID")]
        public int ProductId { get; set; }

        public int ProdCatId { get; set; }

        [Display(Name = "Prod Category")]
        public string ProdCatName { get; set; }

        [Display(Name = "Prod Name")]
        public string ProdName { get; set; }

        [Display(Name = "Prod Desc")]
        public string ProdDescription { get; set; }
    }
}
