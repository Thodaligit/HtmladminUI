using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class ProductSubcategoryBLVM
    {
        public ProductSubcategoryBLVM()
        {
            ProductSubcategories = new List<ProductSubcategoryBL>();
        }
        public List<ProductSubcategoryBL> ProductSubcategories { get; set; }
    }
}