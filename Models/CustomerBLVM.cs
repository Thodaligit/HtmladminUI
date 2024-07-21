using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class CustomerBLVM
    {
        public CustomerBLVM()
        {
            ObjCustomerBLList = new List<CustomerBL>();
        }
        public List<CustomerBL> ObjCustomerBLList { get; set; }
    }
}