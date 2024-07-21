using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class ProductBLVM
    {
        public ProductBLVM()
        {
            Products = new List<ProductBL>();
        }
        public List<ProductBL> Products { get; set; }
    }
}