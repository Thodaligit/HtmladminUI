
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminUI.Models
{
    public class PublishBLVM
    {
        public PublishBLVM()
        {
            ObjPublishBLList = new List<PublishBL>();
        }
        public List<PublishBL> ObjPublishBLList { get; set; }
    }
}