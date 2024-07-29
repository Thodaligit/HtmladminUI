using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class MasterProductCategoryBLVM
    {
        public MasterProductCategoryBLVM()
        {
            MasterProductCategories = new List<MasterProductCategoryBL>();
        }
        public List<MasterProductCategoryBL> MasterProductCategories { get; set; }
    }
}