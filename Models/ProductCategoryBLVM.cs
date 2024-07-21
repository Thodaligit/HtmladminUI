using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class ProductCategoryBLVM
    {
        public ProductCategoryBLVM()
        {
            ProductCategories = new List<ProductCategoryBL>();
        }
        public List<ProductCategoryBL> ProductCategories { get; set; }
    }
}