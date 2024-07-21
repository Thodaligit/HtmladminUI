using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class ProductBL
    {
        [Key]
        public int ProductId { get; set; }
        public int ProductSubcategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public string StoreDesignNo { get; set; }
        public string BrandDesignNo { get; set; }
        public Nullable<int> StockStartQuantity { get; set; }
        public Nullable<int> StockInQuantity { get; set; }

        public string ProductCategoryName { get; set; }
        public string ProductSubcategoryName { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductVideoUrl { get; set; }
        public string MediaFolderPath { get; set; }
        public string ProductDescription { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public bool IsNeedsToDelete { get; set; }
    }
}