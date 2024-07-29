using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminUI.Models.Orders
{
    public class OrderBLVM
    {
        public OrderBLVM()
        {
            ObjOrderBLList = new List<OrderBL>();
        }
        public List<OrderBL> ObjOrderBLList { get; set; }
    }
}