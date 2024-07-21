using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class ProductSubcategoryBL
    {
        [Key]
        public int ProductSubcategoryId { get; set; }
        public string ProductSubcategoryName { get; set; }
        public string ProductCategoryName { get; set; }
        public Nullable<int> ProductCategoryId { get; set; }
        public string Description { get; set; }
        public bool IsNeedsToDelete { get; set; }

    }
}